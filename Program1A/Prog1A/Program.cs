// Program 1A
// CIS 200-01
// Fall 2019
// Due: 9/23/2019
// Grading ID: M1610
// File: Program.cs
// Simple test program for initial Parcel classes

using System.Collections.Generic;
using static System.Console;


class Program
{
    // Precondition:  None
    // Postcondition: Small list of Parcels is created and displayed
    static void Main(string[] args)
    {
        Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
            "  Louisville   ", "  KY   ", 40202); // Test Address 1
        Address a2 = new Address("Jane Doe", "987 Main St.",
            "Beverly Hills", "CA", 90210); // Test Address 2
        Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
            "El Paso", "TX", 79901); // Test Address 3
        Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
            "Portland", "ME", 04101); // Test Address 4



        GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);
        GroundPackage gp2 = new GroundPackage(a1, a3, 10, 12, 2, 50);
        GroundPackage gp3 = new GroundPackage(a2, a1, 100, 15, 7, 20);
        GroundPackage gp4 = new GroundPackage(a4, a2, 5, 2, 11, 2);

        NextDayAirPackage na1 = new NextDayAirPackage(a1, a3, 25, 15, 15, 85, 7.5m);
        NextDayAirPackage na2 = new NextDayAirPackage(a2, a1, 10, 10, 10, 10, 10m);
        NextDayAirPackage na3 = new NextDayAirPackage(a3, a4, 45, 125, 15, 85, 0m);
        NextDayAirPackage na4 = new NextDayAirPackage(a4, a2, 25, 5, 5, 15, 50m);


        TwoDayAirPackage ta1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28, 80.5, TwoDayAirPackage.Delivery.Saver);
        TwoDayAirPackage ta2 = new TwoDayAirPackage(a1, a3, 10, 10, 10, 10, TwoDayAirPackage.Delivery.Early);
        TwoDayAirPackage ta3 = new TwoDayAirPackage(a2, a4, 5, 5, 5, 50, TwoDayAirPackage.Delivery.Saver);
        TwoDayAirPackage ta4 = new TwoDayAirPackage(a3, a2, 30, 40, 28, 20, TwoDayAirPackage.Delivery.Early);

        List<GroundPackage> groundPackages = new List<GroundPackage>(); // Test list of parcels
        List<NextDayAirPackage> nextDayAirPackages = new List<NextDayAirPackage>(); // Test list of parcels
        List<TwoDayAirPackage> twoDayAirPackages = new List<TwoDayAirPackage>(); // Test list of parcels


        groundPackages.Add(gp1);
        groundPackages.Add(gp2);
        groundPackages.Add(gp3);
        groundPackages.Add(gp4);

        nextDayAirPackages.Add(na1);
        nextDayAirPackages.Add(na2);
        nextDayAirPackages.Add(na3);
        nextDayAirPackages.Add(na4);

        twoDayAirPackages.Add(ta1);
        twoDayAirPackages.Add(ta2);
        twoDayAirPackages.Add(ta3);
        twoDayAirPackages.Add(ta4);

        foreach (GroundPackage p in groundPackages)
        {
            WriteLine(p);
            WriteLine("--------------------");
        }
        WriteLine("//////////////////////////////////////////////////////////////////////////");
        foreach (NextDayAirPackage p in nextDayAirPackages)
        {
            WriteLine(p);
            WriteLine("--------------------");
        }
        WriteLine("//////////////////////////////////////////////////////////////////////////");
        foreach (TwoDayAirPackage p in twoDayAirPackages)
        {
            WriteLine(p);
            WriteLine("--------------------");
        }
    }
}
