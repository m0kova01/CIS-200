// Program 2
// CIS 200-01
// Fall 2019
// Due: 10/21/2019
// Grading ID: M1610

// File: AddressForm.cs
// The AddressForm is used to add addresses to the upv object.
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class AddressForm : Form
    {
        //Precondition:none
        //Postcondition: the AddressForm is created and the stateComboBox selected index is set to 0
        public AddressForm()
        {
            InitializeComponent();
            stateComboBox.SelectedIndex = 0;    //Selects the first thing in the state combo box. This ensures something is selected
        }
        internal string NameValue // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in nameTextBox is returned
            get { return nameTextBox.Text; }

            // Precondition:  None
            // Postcondition: Text in nameTextBox is set to specified value
            set { nameTextBox.Text = value; }
        }
        internal string Address1Value // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in addressTextBox1 is returned
            get { return addressTextBox1.Text; }

            // Precondition:  None
            // Postcondition: Text in addressTextBox1 is set to specified value
            set { addressTextBox1.Text = value; }
        }
        internal string Address2Value // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in addressTextBox2 is returned
            get { return addressTextBox2.Text; }

            // Precondition:  None
            // Postcondition: Text in addressTextBox2 is set to specified value
            set { addressTextBox2.Text = value; }
        }
        internal string CityValue // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in cityTextBox is returned
            get { return cityTextBox.Text; }

            // Precondition:  None
            // Postcondition: Text in cityTextBox is set to specified value
            set { cityTextBox.Text = value; }
        }
        internal string StateValue // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in stateComboBox is returned
            get { return stateComboBox.Text; }

            // Precondition:  None
            // Postcondition: Text in stateComboBox is set to specified value
            set { stateComboBox.Text = value; }
        }
        internal string ZipValue // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in zipTextBox is returned
            get { return zipTextBox.Text; }

            // Precondition:  None
            // Postcondition: Text in zipTextBox is set to specified value
            set { zipTextBox.Text = value; }
        }

        //Precondition: Attempting to change focus from the nameTextBox
        //Postcondition: errorprovider displays message if the textbox is empty, otherwise focus will change
        private void Name_Validation(object sender, CancelEventArgs e)
        {
            //checks if the textbox is null or empty.
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                e.Cancel = true;    //cancels the event

                errorProvider1.SetError(nameTextBox, "Enter a valid name!");    //displays the errorprovider and message

                nameTextBox.SelectAll();    //reselects all
            }
        }

        //Precondition: Name_Validation succeeded.
        //Postcondition: error messages are cleared and focus is allowed to change.
        private void Name_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(nameTextBox, "");
        }

        //Precondition: Attempting to change focus from addressTextBox1
        //Postcondition: errorprovider displays message if the textbox is empty, otherwise focus will change
        private void Address1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(addressTextBox1.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(addressTextBox1, "Enter a valid address!");

                addressTextBox1.SelectAll();
            }
        }

        //Precondition: Address1_Validating succeeded.
        //Postcondition: error messages are cleared and focus is allowed to change.
        private void Address1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(addressTextBox1, "");
        }

        //Precondition: Attempting to change focus from the cityTextBox
        //Postcondition: errorprovider displays message if the textbox is empty, otherwise focus will change
        private void City_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(cityTextBox.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(cityTextBox, "Enter a valid city!");

                cityTextBox.SelectAll();
            }
        }

        //Precondition: City_Validating succeeded.
        //Postcondition: error messages are cleared and focus is allowed to change.
        private void City_Validation(object sender, EventArgs e)
        {
            errorProvider1.SetError(cityTextBox, "");
        }

        //Precondition: Attempting to change focus from the zipTextBox
        //Postcondition: errorprovider displays message if the textbox doesn't have a valid int, otherwise focus will change
        private void Zip_Validating(object sender, CancelEventArgs e)
        {
            //Checks if it can parse the string into an int.
            //If not, errorProvider1 is displayed
            //If yes, continues onto the next check.
            if (!int.TryParse(zipTextBox.Text, out int zip))
            {
                e.Cancel = true;

                errorProvider1.SetError(zipTextBox, "Enter an integer!");

                zipTextBox.SelectAll();
            }
            else
            {
                //Last check to make sure int is a valid zip between 0-99999.
                //If not, errorProvider 1 is displayed
                //If yes, focus is allowed to change.
                if (zip < 0 && zip > 99999)
                {
                    e.Cancel = true;

                    errorProvider1.SetError(zipTextBox, "Enter a valid zip code!");

                    zipTextBox.SelectAll();
                }
            }
        }

        //Precondition: Zip_Validating succeeded.
        //Postcondition: error messages are cleared and focus is allowed to change.
        private void Zip_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(zipTextBox, "");
        }

        // Precondition:  okButton is clicked
        // Postcondition: If all controls on form validate, InputBox is dismissed with OK result
        private void OkButton_Click(object sender, EventArgs e)
        {
            //Checks if all children have finished validation and validated events.
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // Precondition:  cancelButton is clicked
        // Postcondition: If left-click, InputBox is dismissed with Cancel result
        private void Cancel_Mousedown(object sender, MouseEventArgs e)
        {
            //Checks if the left mouse button was used.
            if (e.Button == MouseButtons.Left)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
