// Program 1A
// CIS 200-01
// Fall 2019
// Due: 9/23/2019
// Grading ID: M1610
// File: NextDayAirPackage.cs
// This file is derived from AirPackage.cs. It validates the express fee and calculates the cost of next day air packages.
using System;

class NextDayAirPackage : AirPackage
{
    const double SIZE_COST_FACTOR = .30; //the size cost factor stored as a const
    const double WEIGHT_COST_FACTOR = .25; //the weight cost factor stored as a const
    const int MINIMUM_FEE = 0; //the mininmum fee stored as a const

    private decimal _expressFee; //the backing field for the express fee

    // Precondition:  the express fee must be > than the minimum fee
    // Postcondition: the next day air package is created with values passed in from its base class.
    public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal expressFee)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        ExpressFee = expressFee;
    }

    public decimal ExpressFee
    {
        // Precondition:  None
        // Postcondition: The express fee is returned
        get
        {
            return _expressFee;
        }
        // Precondition:  value > maximum fee
        // Postcondition: the express fee is set to value
        private set
        {
            if (value < MINIMUM_FEE)
                throw new ArgumentOutOfRangeException("ExpressFee", value,
                    "Express Fee must be >= 0");
            else
                _expressFee = value;
        }
    }

    // Precondition:  None
    // Postcondition: The package's cost has been returned
    public override decimal CalcCost()
    {
        double WEIGHT_CHARGE = .20 * (Weight); //constant for the weight charge
        double SIZE_CHARGE = .20 * (Length + Width + Height); //constant for the size charge

        double Cost = SIZE_COST_FACTOR * (Length + Width + Height) + WEIGHT_COST_FACTOR * (Weight) + (double)ExpressFee; //the cost calculated and stored as Cost double

        //determining if the package is heavy
        if (base.IsHeavy())
            Cost += WEIGHT_CHARGE;
        //determining if the package is large
        if (base.IsLarge())
            Cost += SIZE_CHARGE;

        return (decimal)Cost;
    }

    // Precondition:  None
    // Postcondition: A String with the package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine;
        return $"Next Day Air{NL}{base.ToString()}{NL}Express Fee: {ExpressFee:C}";
    }
}