// Program 1A
// CIS 200-01
// Fall 2019
// Due: 9/23/2019
// Grading ID: M1610
// File: Package.cs
// Package is the base class for the package heirarchy.
using System;

abstract class Package : Parcel
{
    private double _length; //represents the length of the package
    private double _width; //represents the width of the package
    private double _height; //represents the height of the package
    private double _weight; //represents the weight of the package

    // Precondition:  length, width, height, and weight > 0
    // Postcondition: The package is created with the specified values for
    //                origin address, destination address, and cost
    public Package(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress)
    {
        //the properties for validation
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
    }

    protected double Length
    {
        //Precondition: none.
        //Postcondition: The length is returned
        get
        {
            return _length;
        }
        //Precondition: the length is > 0
        //Postcondition: the length is set to the value
        private set
        {

            if (value > 0)
                _length = value;
            else
                throw new ArgumentOutOfRangeException("Length", value,
                    "Length must be > 0");
        }
    }
    protected double Width
    {
        //Precondition: none.
        //Postcondition: The width is returned
        get
        {
            return _width;
        }
        //Precondition: the width is > 0
        //Postcondition: the width is set to the value
        private set
        {
            if (value > 0)
                _width = value;
            else
                throw new ArgumentOutOfRangeException("Width", value,
                    "Width must be > 0");
        }
    }
    protected double Height
    {
        //Precondition: none.
        //Postcondition: The height is returned
        get
        {
            return _height;
        }
        //Precondition: the height is > 0
        //Postcondition: the height is set to the value
        private set
        {
            if (value > 0)
                _height = value;
            else
                throw new ArgumentOutOfRangeException("Height", value,
                    "Height must be > 0");
        }
    }
    protected double Weight
    {
        //Precondition: none.
        //Postcondition: The weight is returned
        get
        {
            return _weight;
        }
        //Precondition: the weight is > 0
        //Postcondition: the weight is set to the value
        private set
        {
            if (value > 0)
                _weight = value;
            else
                throw new ArgumentOutOfRangeException("Weight", value,
                    "Weight must be > 0");
        }
    }

    // Precondition:  None
    // Postcondition: A String with the package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Length: {Length}{NL}Width: {Width}{NL}Height: {Height}{NL}Weight: {Weight}{NL}{NL}{base.ToString()}";
    }

}
