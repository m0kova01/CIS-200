// Program 1B
// CIS 200-01
// Fall 2019
// Due: 10/02/2019
// Grading ID: M1610

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Luke Skywalker", "123 Desert Rd",
                "Tattoine", "TA", 20495); // Test Address 5
            Address a6 = new Address("Darth Vader", "1 Death Star Rd",
                   "Death Star", "DS", 05953); // Test Address 6
            Address a7 = new Address("Obi-Wan Kenobi", "69 Hello There St.",
                    "Judland Wastes", "TA", 95302); // Test Address 7
            Address a8 = new Address("Padme Amidala", "10 Will To Live Dr.",
                    "Mustafar", "MU", 20193); // Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            Letter letter2 = new Letter(a2, a1, 4.8M);                            // Letter test object
            Letter letter3 = new Letter(a3, a7, 6.99M);                            // Letter test object

            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            GroundPackage gp2 = new GroundPackage(a3, a4, 4, 1, 2, 1.5);        // Ground test object
            GroundPackage gp3 = new GroundPackage(a3, a4, 32, 33, 13, 23);        // Ground test object

            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a4, a6, 55, 14, 155,    // Next Day test object
                8, 7.50M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a7, a8, 25, 3, 12,    // Next Day test object
                82, 7.50M);

            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a8, a3, 4.5, 34, 44, // Two Day test object
                20.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a4, a5, 20.5, 32.5, 20, // Two Day test object
                50.5, TwoDayAirPackage.Delivery.Saver);


            List<Parcel> parcels = new List<Parcel>();       // List of test parcels

            // Populate list
            parcels.Add(letter1);
            parcels.Add(letter2);
            parcels.Add(letter3);

            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(gp3);

            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);

            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(tdap3);

            //Selects all Parcels and orders by destination zip (descending)
            var byZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            //Selects all Parcels and orders by cost (ascending)
            var byCost =
                from p in parcels
                orderby p.CalcCost()//orders by cost using CalcCost method
                select p;

            //Selects all Parcels and orders them by type (ascending), and then cost (descending
            var byTypeThenCost =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            //Selects all AirPackages that are heavy and orders them by weight (descending)
            var heavyByWeight =
                from p in parcels
                where ((p is AirPackage) && (p as AirPackage).IsHeavy()) //making sure only airpackages that are heavy show up
                let ap = p as AirPackage
                where (ap != null) && ap.IsHeavy() //filtering so that no null airpackages show up and they are heavy
                orderby ap.Weight descending
                select ap;

            //displaying the output of byZip
            foreach (var p in byZip)
            {
                WriteLine(p);
                WriteLine("=================");
            }
            WriteLine("========================================================");
            //displaying the output of byCost
            foreach (var p in byCost)
            {
                WriteLine(p);
                WriteLine("=================");
            }
            WriteLine("========================================================");
            //displaying the output of byTypeThenCost
            foreach (var p in byTypeThenCost)
            {
                WriteLine(p);
                WriteLine("=================");
            }
            WriteLine("========================================================");
            //displaying the output of heavyByWeight
            foreach (var p in heavyByWeight)
            {
                WriteLine(p);
                WriteLine("=================");
            }
            Pause();
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
