// Program 1A
// CIS 200-01
// Fall 2019
// Due: 9/23/2019
// Grading ID: M1610
// File: AirPackage.cs
// This file is derived from the Package class and determines whether the package is large or heavy or both.
using System;


abstract class AirPackage : Package
{
    const int HEAVY_WEIGHT = 50; // constant that represents the limit for heavy weights
    const int LARGE_PACKAGE = 75;// constant that represents the limit for large packages

    // Precondition:  none
    // Postcondition: the air package is created with values passed in from its base class.

    public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
    : base(originAddress, destAddress, length, width, height, weight) { }

    // Precondition:  None
    // Postcondition: A bool is returned depending on if the package was heavy or not
    protected bool IsHeavy()
    {
        if (Weight >= HEAVY_WEIGHT)
            return true;
        else
            return false;
    }

    // Precondition:  None
    // Postcondition: A bool is returned depending on if the package was large or not
    protected bool IsLarge()
    {
        if ((Length + Height + Width) >= LARGE_PACKAGE)
            return true;
        else
            return false;
    }

    // Precondition:  None
    // Postcondition: A String with the package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; //New line shortcut

        return $"{base.ToString()}{NL}Is Heavy? {IsHeavy()}{NL}Is Large? {IsLarge()}";
    }
}
