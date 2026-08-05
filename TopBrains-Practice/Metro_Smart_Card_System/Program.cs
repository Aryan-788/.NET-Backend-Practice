using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] first = Console.ReadLine().Split();

        int numberOfRequests = int.Parse(first[0]);
        double baseFare = double.Parse(first[1]);
        double perKmRate = double.Parse(first[2]);
        double maxDailyCap = double.Parse(first[3]);

        int stationCount = int.Parse(Console.ReadLine());

        List<Station> stationList = new List<Station>();

        for (int i = 0; i < stationCount; i++)
        {
            string[] s = Console.ReadLine().Split();

            stationList.Add(new Station()
            {
                stationId = int.Parse(s[0]),
                stationName = s[1],
                zone = int.Parse(s[2]),
                latitude = double.Parse(s[3]),
                longitude = double.Parse(s[4])
            });
        }

        MetroCardManager manager = new MetroCardManager(stationList, baseFare, perKmRate, maxDailyCap);

        for (int i = 0; i < numberOfRequests; i++)
        {
            string line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                i--;
                continue;
            }

            string[] parts = line.Split();

            switch (parts[0])
            {
                case "issueCard":

                    manager.issueCard(
                        int.Parse(parts[1]),
                        parts[2],
                        parts[3]);

                    break;

                case "tapIn":

                    Console.WriteLine(

                        manager.tapIn(

                        int.Parse(parts[1]),

                        int.Parse(parts[2]),

                        long.Parse(parts[3])

                        ));

                    break;

                case "tapOut":

                    Console.WriteLine(

                        manager.tapOut(

                        int.Parse(parts[1]),

                        int.Parse(parts[2]),

                        long.Parse(parts[3])

                        ));

                    break;

                case "commuterInfo":

                    Commuter c =
                        manager.getCommuterInfo(
                        int.Parse(parts[1]));

                    if (c != null)
                    {
                        Console.WriteLine(
                            c.cardNumber + " " +
                            c.commuterName + " " +
                            c.commuterType + " " +
                            c.travelSummary.lastEntryStation + " " +
                            c.travelSummary.lastExitStation + " " +
                            c.travelSummary.lastEntryTime + " " +
                            c.travelSummary.lastExitTime + " " +
                            c.travelSummary.totalFarePaid + " " +
                            c.travelSummary.totalTrips + " " +
                            c.travelSummary.averageFarePerTrip);
                    }

                    break;

                case "fareHistory":

                    List<double> fares =
                        manager.fareHistory(
                        int.Parse(parts[1]));

                    foreach (double fare in fares)
                        Console.WriteLine(fare);

                    break;

                case "zoneRevenue":

                    Dictionary<string, double> revenue =
                        manager.getZoneWiseRevenue(

                        long.Parse(parts[1]),

                        long.Parse(parts[2]));

                    foreach (var item in revenue)
                    {
                        Console.WriteLine(
                            item.Key + ":" + item.Value);
                    }

                    break;

                case "frequentRoute":

                    List<string> routes =
                        manager.getFrequentRoute(
                        int.Parse(parts[1]));

                    foreach (string route in routes)
                    {
                        Console.WriteLine(route);
                    }

                    break;

                case "dailySavings":

                    Console.WriteLine(

                        manager.getDailyPassSavings(

                        int.Parse(parts[1]),

                        long.Parse(parts[2])

                        ));

                    break;
            }
        }
    }
}