//Grading ID: M1610
//Program Number: 0
//Due Date: 9/9/19
//Course Section: 01
//Class description: This class is responsible for letters in the program. It stores and validates the letters' fixed cost, as well as calculates the final cost and outputs the results into the console.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class Letter : Parcel //letter IS-A parcel
    {
        private decimal _fixedCost; //storing the fixed cost of the letter

        //precondition: Address objects were already validated.
        //              fixedCost >= 0.
        //postcondition: The letter class has been created with the parameters' values
        public Letter(Address originAddress, Address destinationAddress, decimal fixedCost)
            : base(originAddress, destinationAddress)
        {
            //sending parameter to properties for validation
            FixedCost = fixedCost;
        }

        private decimal FixedCost
        {
            //precondition: none
            //postcondition: the fixed cost is returned
            get
            {
                return _fixedCost;
            }
            //precondition: FixedCost >= 0
            //postcondition: the fixed cost is set to the value or an error message is thrown.
            set
            {
                if (value >= 0)
                {
                    _fixedCost = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(FixedCost), value, $"Sorry, {nameof(FixedCost)} was not valid");
                }
            }
        }

        //Method that calculates the cost by using a fixed cost that is passed in.
        public override decimal CalcCost()
        {
            return FixedCost;
        }

        //Method that returns a string to output the origin address, destination address, and the cost.
        public override string ToString() =>
            $"Origin Address:\n{OriginAddress}\n\n" +
            $"Destination Address:\n{DestinationAddress}\n\n" +
            $"Total cost:\n{CalcCost():C}\n" +
            $"\n..............................\n";
    }
}
