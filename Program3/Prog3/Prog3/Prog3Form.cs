// Program 3
// CIS 200-01
// Fall 2019
// Due: 11/11/2019
// Grading ID: M1610

// File: Prog3Form.cs
// This class creates the main GUI for Program 2. It provides a
// File menu with About and Exit items, an Insert menu with Address and
// Letter items, and a Report menu with List Addresses and List Parcels
// items.

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class Prog3Form : Form
    {
        private UserParcelView upv; // The UserParcelView
        private readonly BinaryFormatter reader = new BinaryFormatter(); // object for serializing RecordSerializables in binary format
        private readonly BinaryFormatter formatter = new BinaryFormatter(); // object for serializing RecordSerializables in binary format
        private FileStream input; // stream for reading from a file
        private FileStream output; // stream for writing to a file

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test addresses are
        //                added to the list of addresses
        public Prog3Form()
        {
            InitializeComponent();

            upv = new UserParcelView();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Program 3{NL}Grading ID: M1610{NL}CIS 200{NL}Fall 2019",
                "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        //precondition: the open toolstrip menu item is clicked
        //postcondition: the selected file is loaded into the program
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; // stores the DialogResult
            string fileName; // name of file containing data

            //opens the filedialog
            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog(); //gets the result
                fileName = fileChooser.FileName; // get specified name
            }

            //if the result was ok, tries to load the upv object with the file.
            if (result == DialogResult.OK)
            {
                try
                {
                    // create FileStream to obtain read access to file
                    input = new FileStream(
                       fileName, FileMode.Open, FileAccess.Read);

                    upv = (UserParcelView)reader.Deserialize(input); //loads the upv object with the input
                }
                catch (IOException) //catches IOException error
                {
                    // notify user if file could not be saved
                    MessageBox.Show("Error saving file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SerializationException) //catches SerializationException error
                {
                    MessageBox.Show("Error opening file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally //closes the filestream if no errors occur
                {
                    input?.Close(); // close FileStream
                }
            }
        }

        //precondition: save as toolstrip menu item is clicked
        //postcondition: the upv object is saved
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; //stores the result
            string fileName; // name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file
                // retrieve the result of the dialog box
                result = fileChooser.ShowDialog(); //stores the result
                fileName = fileChooser.FileName; // get specified file name
            }

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                //tries to save the file
                try
                {
                    // open file with write access
                    output = new FileStream(fileName,
                       FileMode.Create, FileAccess.Write);

                    formatter.Serialize(output, upv);
                }
                catch (IOException) //catches IOException
                {
                    // notify user if file could not be saved
                    MessageBox.Show("Error saving file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (SerializationException) //catches SerializationException
                {
                    MessageBox.Show("Error saving file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException) //catches FormatException
                {
                    MessageBox.Show("Invalid Format", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally //closes filestream if no errors occur.
                {
                    output?.Close();
                }
            }
        }

        //precondition: the address toolstrip menu item is clicked.
        //postcondition: the selected upv address object is updated
        private void AddressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            const int MINIMUM_ADDRESSES = 0; //the minimum addresses required to be able to edit

            //checks if there is at least one address
            //If yes, opens an EditAddress form. If no, shows a messagebox with error.
            if (upv.AddressCount > MINIMUM_ADDRESSES)
            {
                EditAddress editAddress = new EditAddress(upv.AddressList); // Send list of addresses and open EditAddress form
                DialogResult result = editAddress.ShowDialog(); //the dialog result of the EditAddress form
                int selectedIndex; //keeps track of selected indoex in the editaddress form.

                if (result == DialogResult.OK) // Only add if OK
                {
                    selectedIndex = editAddress.AddressBoxIndex; //sets selectedIndex to the selected one in the EditAddress form.
                    //Populates the address form textboxes with the selected address' data
                    AddressForm addressForm = new AddressForm
                    {
                        AddressName = upv.AddressList[selectedIndex].Name,
                        Address1 = upv.AddressList[selectedIndex].Address1,
                        Address2 = upv.AddressList[selectedIndex].Address2,
                        City = upv.AddressList[selectedIndex].City,
                        State = upv.AddressList[selectedIndex].State,
                        ZipText = upv.AddressList[selectedIndex].Zip.ToString()
                    };

                    DialogResult editResult = addressForm.ShowDialog(); //sets editResult depending on what was clicked
                    //checks if the result was ok.
                    //If so, tries to update the upv address with the new information
                    if (editResult == DialogResult.OK)
                    { //tries to parse the zipcode. If successful, updates the upv address.
                        if (int.TryParse(addressForm.ZipText, out int zip))
                        {
                            upv.AddressList[selectedIndex].Name = addressForm.AddressName;
                            upv.AddressList[selectedIndex].Address1 = addressForm.Address1;
                            upv.AddressList[selectedIndex].Address2 = addressForm.Address2;
                            upv.AddressList[selectedIndex].City = addressForm.City;
                            upv.AddressList[selectedIndex].State = addressForm.State;
                            upv.AddressList[selectedIndex].Zip = zip;
                        }
                        else // If there was an error
                        {
                            MessageBox.Show("Problem with Address Validation!", "Validation Error");
                        }
                    }
                    addressForm.Dispose(); //disposes the form
                }
                editAddress.Dispose(); // Disposes the form
            }
            else
            {
                //shows if there is nothing to edit
                MessageBox.Show("No addresses to edit!",
                    "Addresses Error");
                this.DialogResult = DialogResult.Abort; // Dismiss immediately
            }
        }
    }
}