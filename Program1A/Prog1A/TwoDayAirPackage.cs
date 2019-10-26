// Program 1A
// CIS 200-01
// Fall 2019
// Due: 9/23/2019
// Grading ID: M1610
// File: TwoDayAirPackage.cs
// Package is the base class for the package heirarchy.
using System;

class TwoDayAirPackage : AirPackage
{
    const double SIZE_COST_FACTOR = .20; //size cost factor stored as a const
    const double WEIGHT_COST_FACTOR = .20; //weight cost factor stored as a const
    const double SAVER_DISCOUNT = .85; //the saver discount stored as a const

    public enum Delivery { Early, Saver }; //the delivery types stored as enums
    private Delivery _deliveryType; //the backing field for the delivry type

    // Precondition:  the delivery types must match the options in the delivery enumeration
    // Postcondition: the two day air package is created with values passed in from its base class.
    public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, Delivery deliveryType)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        DeliveryType = deliveryType;
    }

    public Delivery DeliveryType
    {
        // Precondition:  None
        // Postcondition: The delivery type is returned
        get
        { return _deliveryType; }
        // Precondition:  the delivery type must be either early or saver
        // Postcondition: the deliverytype is set to value
        private set
        {
            if ((value == Delivery.Early) || (value == Delivery.Saver))
                _deliveryType = value;
            else
                throw new ArgumentOutOfRangeException("DeliveryType", value,
                    "Delivery Type must be either early or saver.");
        }
    }

    // Precondition:  None
    // Postcondition: The package's cost has been returned
    public override decimal CalcCost()
    {
        double Cost = SIZE_COST_FACTOR * (Length + Width + Height) + WEIGHT_COST_FACTOR * (Weight); //the cost calculated and stored as Cost double
        //if the deliverytype is saver the discount is applied
        if (DeliveryType == Delivery.Saver)
        {
            Cost = (Cost * SAVER_DISCOUNT);
        }
        return (decimal)Cost;
    }

    // Precondition:  None
    // Postcondition: A String with the package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; //new line shortcut
        return $"Two Day Air{NL}Delivery Type: {DeliveryType}{NL}{base.ToString()}";
    }
}
