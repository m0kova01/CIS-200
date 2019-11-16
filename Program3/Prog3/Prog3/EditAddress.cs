// Program 3
// CIS 200-01
// Fall 2019
// Due: 11/11/2019
// Grading ID: M1610

//This form serves as a simple selection tool to select the address to edit
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class EditAddress : Form
    {
        private List<Address> addressList;  // List of addresses used to fill combo box

        //precondition: there must be at least one address in the upv object list
        //postcondition: the form is initialized and the addressList is populated 
        public EditAddress(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

        internal int AddressBoxIndex //stores an index of the addressComboBox
        {
            // Precondition:  User has selected from addressComboBox
            // Postcondition: The index of the selected address is returned
            get
            {
                return addressComboBox.SelectedIndex;
            }
        }

        //precondition: ok button is clicked
        //postcondition: the dialogresult is returned with ok
        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //precondition: cancel button is clicked
        //postcondition: the dialogresult is returned with cancel
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //precondition: the form must begin loading
        //postcondition: the combobox is populated with the list and the first item is selected by default.
        private void EditAddressLoad(object sender, EventArgs e)
        {
            const int FIRST_ITEM = 0; // an int to select the first item in the combobox
            //populates the combobox
            foreach (Address address in addressList)
            {
                addressComboBox.Items.Add(address.Name);
            }
            addressComboBox.SelectedIndex = FIRST_ITEM; //selects the firs item in the combobox
        }
    }
}
