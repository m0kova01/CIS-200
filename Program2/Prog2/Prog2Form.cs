// Program 2
// CIS 200-01
// Fall 2019
// Due: 10/21/2019
// Grading ID: M1610

// File: Prog2Form.cs
// The Prog2Form is used to store the upv object. It is also the starting form of the application. Any of the other forms are accessed using this form.
using System;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        UserParcelView upvObject = new UserParcelView();    //The UPV object used to store everything.

        //The test addresses stored as address objects.
        Address a1 = new Address("Homer Simpson", "742 Evergreen Terrace", "Springfield", "OR", 97403);
        Address a2 = new Address("Batman", "Bat Cave", "Gotham", "NY", 10001);
        Address a3 = new Address("Harry Potter", "4 Privet Drive", "Little Whingeing", "HP", 62442);


        //Precondition: none
        //Postcondition: The main form has been created and the test addresses and letters are added.
        public Prog2Form()
        {
            InitializeComponent();

            //Adding addresses to the UPV object.
            upvObject.AddAddress("Homer Simpson", "742 Evergreen Terrace", "Springfield", "OR", 97403);
            upvObject.AddAddress("Batman", "Bat Cave", "Gotham", "NY", 10001);
            upvObject.AddAddress("Harry Potter", "4 Privet Drive", "Little Whingeing", "HP", 62442);

            //Adding letters to the UPV object.
            upvObject.AddLetter(a1, a3, 10);
            upvObject.AddLetter(a2, a1, 15);
            upvObject.AddLetter(a3, a2, 20);

        }

        //Precondition: exit menu item is clicked.
        //Postcondition: application exits.
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Exits the application.
        }

        //Precondition: About menu item is clicked
        //Postcondition: Shows message box with student info.
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program 2\nGrading ID: M1610\nDue Date: 10/21/19\nCourse Section: 01");//shows messagebox with information
        }

        //Precondition: Address menu item is clicked
        //Postcondition: An address is added to the UPV object's list and the dialog box is disposed.
        private void AddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addAddress = new AddressForm(); //new AddressForm object
            DialogResult dialogResult;  //allows us to store a dialog result.
            dialogResult = addAddress.ShowDialog(); //displays the AddressForm.

            //checks to see if the dialogresult was set to ok. If it was, an address is added to the UPV object.
            if (dialogResult == DialogResult.OK)
            {
                upvObject.AddAddress(addAddress.NameValue, addAddress.Address1Value, addAddress.Address2Value, addAddress.CityValue, addAddress.StateValue, int.Parse(addAddress.ZipValue));    //passing the AddressForms results into the AddAddress method.
                addAddress.Dispose(); //Gets rid of the form.
            }
        }

        //Precondition: List Address menu item is clicked.
        //Postcondition: each address object is converted to a string and displayed in the outputBox.
        private void ListAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newLine = Environment.NewLine;   //newline shortcut.
            string addressString = $"Addresses:{newLine}{newLine}"; //the beginning of the string to be displayed.

            //Loop to go through each address in the AddressList and add them to the string to be displayed.
            foreach (Address address in upvObject.AddressList)
            {
                addressString += $"{address.Name}{newLine}{address.Address1}{newLine}{(String.IsNullOrEmpty(address.Address2) ? "" : $"{address.Address2}{newLine}")}{address.City}, {address.State}{newLine}{address.Zip}{newLine}-------------------------{newLine}"; //Adds address to string with additional formatting.
            }
            outputBox.Text = addressString;   //Displays the string in the outputBox.
        }

        //Precondition: letter menut item is clicked
        //Postcondition: A letter is added to the upvObject. The form is also disposed.
        private void LetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm = new LetterForm(upvObject.AddressList);  //new LetterForm object is created
            DialogResult dialogResult;  //Allows us to store the dialogresult.
            dialogResult = letterForm.ShowDialog(); //shows the LetterForm as a dialog box.

            //Checks if the dialogresult is returned with OK. If it is, a letter is added to the list of letters.
            if (dialogResult == DialogResult.OK)
            {
                upvObject.AddLetter(upvObject.AddressAt(letterForm.OriginIndex), upvObject.AddressAt(letterForm.DestinationIndex), decimal.Parse(letterForm.CostValue));    //Adds the letter based on what was enterd in the letterform.
                letterForm.Dispose();   //disposes the form when everything is complete.
            }
        }

        //Precondition: the list parcels menu item is clicked.
        //Postcondition: the outputBox lists all the parcels as a string.
        private void ListParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newLine = Environment.NewLine;   //newline shortcut
            string parcelString = $"Parcels:{newLine}{newLine}";    //Start of the string to be displayed

            //loop to go through each Parcel objet in the UPV objects ParelList.
            foreach (Parcel parcel in upvObject.ParcelList)
            {
                parcelString += $"{parcel.ToString()}{newLine}------------------------------------{newLine}";   //Adds each parcel to the string
            }
            outputBox.Text = parcelString;  //Displays the string in the outputBox
        }
    }
}
