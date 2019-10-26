//Grading ID: M1610
//Program Number: 0
//Due Date: 9/9/19
//Course Section: 01
/*Class description: This class stores and validates the addresses. It also formats the output using a ToString Method*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class Address
    {
        //Backing fields
        private string _name; //The name from the address
        private string _addressLine1; //The first address line in the address
        private string _addressLine2; //The second (optional) address line in the address
        private string _city; //The city in the address
        private string _state; //The state in the address
        private int _zip; //The zip code of the address

        public const int MINIMUM_ZIP = 00000; // The minimum zip code value
        public const int MAXIMUM_ZIP = 99999; // The maximum zip code value

        // Preconditions: name != null or whitespace 
        //                addressLine1 != null or whitespace,
        //                addressLine2 != null or whitespace,
        //                city != null or whitespace,
        //                state != null or whitespace,
        //                MINIMUMM_ZIP <= zip <= MAXIMUM_ZIP
        // Postconditions: The Address class has been created with the values passed in through parameters.
        public Address (string name, string addressLine1, string addressLine2, string city, string state, int zip)
        {
            //The properties for validation
            Name = name;
            Address1 = addressLine1;
            Address2 = addressLine2;
            City = city;
            State = state;
            Zip = zip;
        }

        // Preconditions: name != null or whitespace 
        //                addressLine1 != null or whitespace,
        //                city != null or whitespace,
        //                state != null or whitespace,
        //                MINIMUMM_ZIP <= zip <= MAXIMUM_ZIP
        //                addressLine2 is set to empty
        //Postconditions: The Address class has been overloaded and address line 2 is set to empty.
        public Address (string name, string addressLine1, string city, string state, int zip)
        {
            //Sends parameters to properties for validation.
            Name = name;
            Address1 = addressLine1;
            City = city;
            State = state;
            Zip = zip;
            Address2 = string.Empty; //Sets Address2 to empty.
        }

        public string Name
        {
            //Precondition: none.
            //Postcondition: The name on the address is returned.
            get
            {
                return _name;
            }
            //Precondition: Name != null or whitespace.
            //Postcondition: The name on the package has been set to value or an error message is shown.
            private set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()) == false)
                {
                    _name = value.Trim();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), value, $"Sorry, the {nameof(Name)} was not valid");
                }
            }
        }
        public string Address1
        {
            //Precondition: none.
            //Postcondition: The Address1 on the address is returned.
            get
            {
                return _addressLine1;
            }
            //Precondition: Address1 != null or whitespace.
            //Postcondition: The address1 on the package has been set to value or an error message is shown.
            private set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()) == false)
                {
                    _addressLine1 = value.Trim();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Address1), value, $"Sorry, the {nameof(Address1)} was not valid");
                }
            }
        }
        public string Address2
        {
            //Precondition: none.
            //Postcondition: The Address2 on the address is returned.
            get
            {
                return _addressLine2;
            }
            //Precondition: Address2 != null or whitespace.
            //Postcondition: The address2 on the package has been set to value or an error message is shown.
            private set
            {
                _addressLine2 = value.Trim();
            }
        }
        public string City
        {
            //Precondition: none.
            //Postcondition: The City on the address is returned.
            get
            {
                return _city;
            }
            //Precondition: City != null or whitespace.
            //Postcondition: The City on the package has been set to value or an error message is shown.
            private set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()) == false)
                {
                    _city = value.Trim();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(City), value, $"Sorry, the {nameof(City)} was not valid");
                }
            }
        }
        public string State
        {
            //Precondition: none.
            //Postcondition: The State on the address is returned.
            get
            {
                return _state;
            }
            //Precondition: State != null or whitespace.
            //Postcondition: The State on the package has been set to value or an error message is shown.
            private set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()) == false)
                {
                    _state = value.Trim();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(State), value, $"Sorry, the {nameof(State)} was not valid");
                }
            }
        }
        public int Zip
        {
            //Precondition: none.
            //Postcondition: The Zip on the address is returned.
            get
            {
                return _zip;
            }
            //Precondition: MINIMUM_ZIP <= Zip <= MAXIMUM_ZIP.
            //Postcondition: The address1 on the package has been set to value or an error message is shown.
            private set
            {
                if (value >= MINIMUM_ZIP && value <= MAXIMUM_ZIP)
                {
                    _zip = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Zip), value, $"Sorry, the {nameof(Zip)} was not valid");
                }
            }
        }

        // Precondition:  None
        // Postcondition: The address is returned as a string with standard formatting.
        public override string ToString() =>
            $"{Name}\n{((Address2 == string.Empty) ? $"{Address1}\n" : $"{Address1}\n{Address2}\n")}{City}, {State} {Zip:D5}";
    }
}
