//Grading ID: M1610
//Program Number: 0
//Due Date: 9/9/19
//Course Section: 01
/*Class description: This class is the base class Parcel. All types of parcels are derived from it. It stores the origin and destination address for each parcel, calculates the cost, and
then displays the content into the console.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    abstract class Parcel
    {
        private Address _originAddress; //The origin address stored as an Address object. This is a has-a relationship.
        private Address _destinationAddress; //The destination address stored as an Address object. This is a has-a relationship.

        //precondition: The originAddress and destinationAddress objects have to be validated through their respective classes.
        //postcondition: the address objects are set to the parameters' values.

        public Parcel (Address originAddress, Address destinationAddress)
        {
            //parameters passed to Properties to avoid lazy programming.
            OriginAddress = originAddress;
            DestinationAddress = destinationAddress;
        }

        public Address OriginAddress
        {
            //precondition: none
            //postcondition: origin address has been returned
            get
            {
                return _originAddress;
            }
            //precondition: none
            //postcondition: origin address has been set
            set
            {
                _originAddress = value;
            }
        }
        public Address DestinationAddress
        {
            //precondition: none
            //postcondition: destination address has been returned
            get
            {
                return _destinationAddress;
            }
            //precondition: none
            //postcondition: destination address address has been set
            set
            {
                _destinationAddress = value;
            }
        }

        //abstract method to calculate the cost. It's abstract because we don't know how to calculate it yet.
        public abstract decimal CalcCost();

        //method to return the origin address, destination address, and cost as a string.
        public override string ToString() =>
            $"Origin Address: {OriginAddress}\n" +
            $"Destination Address: {DestinationAddress}\n" +
            $"Total cost: {CalcCost():C}\n" +
            $"\n..............................\n";
    }
}
