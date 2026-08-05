public class MetroCardManager : MetroOperations
{
    private Dictionary<int, Commuter> commuters;

    private Dictionary<int, Station> stations;

    private Dictionary<int, Journey> activeJourneys;

    private Dictionary<int, List<double>> commuterFareHistory;

    private Dictionary<int, List<JourneyRecord>> commuterJourneys;
    private Dictionary<int, Dictionary<long, double>> dailyFare;

    private double baseFare;

    private double perKmRate;

    private double maxDailyCap;

    public MetroCardManager(List<Station> stationList, double baseFare, double perKmRate, double maxDailyCap)
    {
        commuters = new Dictionary<int, Commuter>();

        stations = new Dictionary<int, Station>();

        activeJourneys = new Dictionary<int, Journey>();
        dailyFare = new Dictionary<int, Dictionary<long, double>>();

        commuterFareHistory = new Dictionary<int, List<double>>();

        commuterJourneys = new Dictionary<int, List<JourneyRecord>>();

        foreach (Station station in stationList)
        {
            stations[station.stationId] = station;
        }

        this.baseFare = baseFare;
        this.perKmRate = perKmRate;
        this.maxDailyCap = maxDailyCap;
    }

    public void issueCard(int cardNumber, string commuterName, string commuterType)
    {
        // Card already exists
        if (commuters.ContainsKey(cardNumber))
            return;

        TravelSummary summary = new TravelSummary()
        {
            lastEntryStation = 0,
            lastExitStation = 0,
            lastEntryTime = 0,
            lastExitTime = 0,
            totalFarePaid = 0,
            totalTrips = 0,
            averageFarePerTrip = 0
        };

        Commuter commuter = new Commuter()
        {
            cardNumber = cardNumber,
            commuterName = commuterName,
            commuterType = commuterType.ToUpper(),
            travelSummary = summary
        };

        commuters.Add(cardNumber, commuter);

        commuterFareHistory[cardNumber] = new List<double>();

        commuterJourneys[cardNumber] = new List<JourneyRecord>();

        dailyFare[cardNumber] =  new Dictionary<long, double>();
    }

    public bool tapIn(int cardNumber, int stationId, long epochTime)
    {
        if (!commuters.ContainsKey(cardNumber))
            return false;

        if (!stations.ContainsKey(stationId))
            return false;

        if (activeJourneys.ContainsKey(cardNumber))
            return false;

        activeJourneys[cardNumber] =
            new Journey(stationId, epochTime);

        commuters[cardNumber].travelSummary.lastEntryStation = stationId;
        commuters[cardNumber].travelSummary.lastEntryTime = epochTime;

        return true;
    }

    public bool tapOut(int cardNumber, int stationId, long epochTime)
    {
        if (!commuters.ContainsKey(cardNumber))
            return false;

        if (!activeJourneys.ContainsKey(cardNumber))
            return false;

        if (!stations.ContainsKey(stationId))
            return false;

        Journey journey = activeJourneys[cardNumber];

        if (journey.EntryStation == stationId)
            return false;

        if (epochTime <= journey.EntryTime)
            return false;

        Station entryStation = stations[journey.EntryStation];
        Station exitStation = stations[stationId];

        double distance = CalculateDistance(entryStation, exitStation);

        double duration =
            (epochTime - journey.EntryTime) / (1000.0 * 60);

        double fare;

        if (duration > 120)
            fare = baseFare * 3;
        else
            fare = baseFare + (distance * perKmRate);

        fare *= GetDiscountMultiplier(commuters[cardNumber].commuterType);

        long day = journey.EntryTime / 86400000;

        if (!dailyFare[cardNumber].ContainsKey(day))
            dailyFare[cardNumber][day] = 0;

        double spent = dailyFare[cardNumber][day];

        if (spent >= maxDailyCap)
            fare = 0;
        else if (spent + fare > maxDailyCap)
            fare = maxDailyCap - spent;

        dailyFare[cardNumber][day] += fare;

        Commuter commuter = commuters[cardNumber];

        commuter.travelSummary.lastExitStation = stationId;
        commuter.travelSummary.lastExitTime = epochTime;
        commuter.travelSummary.totalFarePaid += fare;
        commuter.travelSummary.totalTrips++;

        commuter.travelSummary.averageFarePerTrip =
            commuter.travelSummary.totalFarePaid /
            commuter.travelSummary.totalTrips;

        commuterFareHistory[cardNumber].Add(fare);

        JourneyRecord record = new JourneyRecord()
        {
            EntryStation = journey.EntryStation,
            ExitStation = stationId,
            EntryTime = journey.EntryTime,
            ExitTime = epochTime,
            Fare = fare
        };

        commuterJourneys[cardNumber].Add(record);

        activeJourneys.Remove(cardNumber);

        return true;
    }

    public Commuter getCommuterInfo(int cardNumber)
    {
        if (!commuters.ContainsKey(cardNumber))
            return null;

        return commuters[cardNumber];
    }

    private double CalculateDistance(Station s1, Station s2)
    {
        double lat1 = Math.PI * s1.latitude / 180.0;
        double lon1 = Math.PI * s1.longitude / 180.0;

        double lat2 = Math.PI * s2.latitude / 180.0;
        double lon2 = Math.PI * s2.longitude / 180.0;

        double dLat = lat2 - lat1;
        double dLon = lon2 - lon1;

        double a =
            Math.Pow(Math.Sin(dLat / 2), 2) +
            Math.Cos(lat1) *
            Math.Cos(lat2) *
            Math.Pow(Math.Sin(dLon / 2), 2);

        double c = 2 * Math.Asin(Math.Sqrt(a));

        double radius = 6371;

        return radius * c;
    }

    private double GetDiscountMultiplier(string commuterType)
    {
        commuterType = commuterType.ToUpper();

        switch (commuterType)
        {
            case "SENIOR":
                return 0.50;

            case "STUDENT":
                return 0.75;

            case "CHILD":
                return 0.25;

            default:
                return 1.00;
        }
    }

    public List<double> fareHistory(int cardNumber)
    {
        List<double> result = new List<double>();

        if (!commuters.ContainsKey(cardNumber))
            return result;

        result.AddRange(commuterFareHistory[cardNumber]);

        result.Sort();

        result.Reverse();

        if (result.Count > 5)
        {
            result = result.GetRange(0, 5);
        }

        return result;
    }

    public Dictionary<string, double> getZoneWiseRevenue(long startTime, long endTime)
    {
        Dictionary<string, double> revenue = new Dictionary<string, double>();

        foreach (var pair in commuterJourneys)
        {
            foreach (JourneyRecord record in pair.Value)
            {
                if (record.EntryTime >= startTime && record.ExitTime <= endTime)
                {
                    Station s1 = stations[record.EntryStation];
                    Station s2 = stations[record.ExitStation];

                    string key = "Zone" + s1.zone + "-Zone" + s2.zone;

                    if (!revenue.ContainsKey(key))
                        revenue[key] = 0;

                    revenue[key] += record.Fare;
                }
            }
        }

        return revenue.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    public List<string> getFrequentRoute(int cardNumber)
    {
        List<string> answer = new List<string>();

        if (!commuters.ContainsKey(cardNumber))
            return answer;

        Dictionary<string, int> routeCount = new Dictionary<string, int>();

        foreach (JourneyRecord journey in commuterJourneys[cardNumber])
        {
            string route =
                stations[journey.EntryStation].stationName +
                " to " +
                stations[journey.ExitStation].stationName;

            if (!routeCount.ContainsKey(route))
                routeCount[route] = 0;

            routeCount[route]++;
        }

        answer = routeCount.OrderByDescending(x => x.Value).Take(3).Select(x => x.Key).ToList();

        return answer;
    }

    public double getDailyPassSavings(int cardNumber, long date)
    {
        if (!commuters.ContainsKey(cardNumber))
            return 0;

        if (!dailyFare.ContainsKey(cardNumber))
            return 0;

        if (!dailyFare[cardNumber].ContainsKey(date))
            return 0;

        double actual = dailyFare[cardNumber][date];

        double passCost = maxDailyCap * 0.8;

        double savings = actual - passCost;

        if (savings < 0)
            return 0;

        return savings;
    }


}