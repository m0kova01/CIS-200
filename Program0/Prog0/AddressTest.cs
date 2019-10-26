//Grading ID: M1610
//Program Number: 0
//Due Date: 9/9/19
//Course Section: 01
/*Class description: This class simply tests the program using various different addresses and parcel objects*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class AddressTest
    {
        //Precondition: None
        //Postcondition: The program has been tested.
        static void Main(string[] args)
        {
            //The addresses used for testing
            Address address1 = new Address("Mr. President", "1600 Pennsylvania Ave NW", "Washington", "DC", 20500);
            Address address2 = new Address("Jordan Belfort", "11 Wall St", "New York", "NY", 10005);
            Address address3 = new Address("Doc Brown", "1640 Riverside Drive", "Hill Valley", "CA", 91905);
            Address address4 = new Address("Homer Simpson", "742 Evergreen Terrace","Room 1", "Springfield", "OR", 97475);

            //The letter objects for testing, using the address objects as well as a fixed cost amount.
            Letter letterTest1 = new Letter(address1, address2, 10);
            Letter letterTest2 = new Letter(address3, address4, 15);
            Letter letterTest3 = new Letter(address2, address3, 20);

            //The list of parcel objects
            List<Parcel> parcels = new List<Parcel>();
            parcels.Add(letterTest1);
            parcels.Add(letterTest2);
            parcels.Add(letterTest3);

            //Foreach loop used to print the output into the console
            foreach (Parcel item in parcels)
            {
                Console.WriteLine(item.ToString());//writeline calls the parcel objects tostring method to display the output into a console.
            }
        }
    }
}
