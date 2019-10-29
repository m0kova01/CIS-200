// Program 2
// CIS 200-01
// Fall 2019
// Due: 10/21/2019
// Grading ID: M1610

// File: LetterForm.cs
// The LetterForm is used to add letters to the upv object.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class LetterForm : Form
    {
        private List<Address> _addresses;   //private list of addresses.

        //precondition: none
        //postcondition: the LetterForm is initiated, the addresses parameter is added to the local list of addresses, and each address.Name is added to the comboboxes.
        public LetterForm(List<Address> addresses)
        {
            InitializeComponent();
            _addresses = addresses; //adds the addresses parameter to the local list.
            //loop to add each address.Name to the comboboxes.
            foreach (Address address in addresses)
            {
                originAddressComboBox.Items.Add(address.Name);
                destinationComboBox.Items.Add(address.Name);
            }
        }
        internal int OriginIndex    // Can be accessed by other classes in same namespace
        {
            get { return originAddressComboBox.SelectedIndex; } //returns the selected index of the originAddressComboBox
        }
        internal int DestinationIndex   // Can be accessed by other classes in same namespace
        {
            get { return destinationComboBox.SelectedIndex; }   //returns the selected index of the destinationComboBox
        }

        internal string CostValue // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in CostValue is returned
            get { return costBox.Text; }

            // Precondition:  None
            // Postcondition: Text in CostValue is set to specified value
            set { costBox.Text = value; }
        }

        //Precondition: Focus must attempt to change from the originAddressComboBox
        //Postcondition: If nothing is selected, errorProvider1 will be displayed. Otherwise, focus will change.
        private void Origin_Validating(object sender, CancelEventArgs e)
        {
            //Checks if something is selected or not.
            //If not, errorprovider is displayed
            if (originAddressComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(originAddressComboBox, "You must select an origin address!");
            }
        }

        //Precondition: Origin_Validating succeeded.
        //Postcondition: error messages are cleared and focus is allowed to change.
        private void Origin_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(originAddressComboBox, "");
        }
        //Precondition: Focus must attempt to change from the destinationComboBox
        //Postcondition: If nothing is selected OR the destination is the same as the origin, errorProvider1 will be displayed. Otherwise focus will change.
        private void Destination_Validating(object sender, CancelEventArgs e)
        {
            //Checks if something is selected. If not, an errorprovider is displayed
            if (destinationComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(destinationComboBox, "You must select a destination address!");
            }
            else
            {
                //Checks if the destination and origin address are the same. If they are, erroProvider1 is displayed.
                if (destinationComboBox.Text == originAddressComboBox.Text)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(destinationComboBox, "Origin and destination address must be different!");
                }
            }
        }

        //Precondition: Destination_Validating succeeded.
        //Postcondition: error messages are cleared and focus is allowed to change.
        private void Destination_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(destinationComboBox, "");
        }

        //Precondition: Focus must attempt to change from costBox
        //Postcondition: If nothing costBox contains a valid decimal, focus will change. Otherwise, error providers will be displayed and focus will remain.
        private void Cost_Validating(object sender, CancelEventArgs e)
        {
            //Checks if a decimal was entered.
            if (!decimal.TryParse(costBox.Text, out decimal cost))
            {
                e.Cancel = true;
                errorProvider1.SetError(costBox, "Enter a valid cost!");
                costBox.SelectAll();
            }
            else
            {
                //checks if the decimal is greater than 0
                if (cost < 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(costBox, "Cost must be >= 0!");
                    costBox.SelectAll();
                }
            }
        }
        //Precondition: Cost_Validating succeeded.
        //Postcondition: error messages are cleared and focus is allowed to change.
        private void Cost_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(costBox, "");
        }

        // Precondition:  okButton is clicked
        // Postcondition: If all controls on form validate, InputBox is dismissed with OK result
        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // Precondition:  cancelButton is clicked
        // Postcondition: If left-click, InputBox is dismissed with Cancel result
        private void Cancel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
