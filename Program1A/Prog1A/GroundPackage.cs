// Program 1A
// CIS 200-01
// Fall 2019
// Due: 9/23/2019
// Grading ID: M1610
// File: GroundPackage.cs
// This file calculates the cost of ground packages and the zone distance values. It is derived from Package.cs
using System;

class GroundPackage : Package
{
    const double SIZE_COST_FACTOR = .25; //the size cost factor as a constant
    const double WEIGHT_COST_FACTOR = .45; //the weight cost factor as a constant

    // Precondition:  none
    // Postcondition: the groundpackage is created with values passed in from its base class.
    public GroundPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress, length, width, height, weight) { }

    private int ZoneDistance
    {
        // Precondition:  None
        // Postcondition: The ground package's zone distance is returned.
        //                The zone distance is the positive difference between the
        //                first digit of the origin zip code and the first
        //                digit of the destination zip code.
        get
        {
            const int FIRST_DIGIT_FACTOR = 10000; // Denominator to extract 1st digit
            int diff = (OriginAddress.Zip / FIRST_DIGIT_FACTOR) - (DestinationAddress.Zip / FIRST_DIGIT_FACTOR);// Calculated zone difference
                            
            return Math.Abs(diff); // Absolute value in case negative
        }
    }

    // Precondition:  None
    // Postcondition: The package's cost has been returned
    public override decimal CalcCost()
    {
        double Cost = SIZE_COST_FACTOR * (Length + Width + Height) + WEIGHT_COST_FACTOR * (ZoneDistance + 1) * (Weight); //the cost calculated and stored as the Cost double.

        return (decimal)Cost; //returns the cost cast as a decimal
    }

    // Precondition:  None
    // Postcondition: A String with the package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Ground Package{NL}{base.ToString()}{NL}Zone Distance: {ZoneDistance}";
    }
}
