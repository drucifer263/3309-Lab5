using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        public frmNewItem()
        {
            InitializeComponent();
        }

        private InvItem invItem = null;

        public InvItem GetNewItem()
        {
            LoadComboBox();
            this.ShowDialog();
            return invItem;
        }

        private void LoadComboBox()
        {
            cboSizeOrManufacturer.Items.Clear();
            if (rdoPlant.Checked)
            {
                cboSizeOrManufacturer.Items.Add("1 gallon");
                cboSizeOrManufacturer.Items.Add("5 gallon");
                cboSizeOrManufacturer.Items.Add("15 gallon");
                cboSizeOrManufacturer.Items.Add("24-inch box");
                cboSizeOrManufacturer.Items.Add("36-inch box");
            }
            else
            {
                cboSizeOrManufacturer.Items.Add("Bayer");
                cboSizeOrManufacturer.Items.Add("Jobe's");
                cboSizeOrManufacturer.Items.Add("Ortho");
                cboSizeOrManufacturer.Items.Add("Roundup");
                cboSizeOrManufacturer.Items.Add("Scotts");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
     
            string sizeOrManufacturer = "";

            //Converts the selected item, either size or manufacturer to a string
            sizeOrManufacturer = (string) cboSizeOrManufacturer.SelectedItem;

            if (IsValidData())
            {
                //Checks to see which radion button is checked for the appropriate method instantiation 
                if (rdoPlant.Checked)
                {
                    //Calls Plant constructor and places new plant object into invItem object
                    invItem = new Plant(Convert.ToInt32(txtItemNo.Text),
                    txtDescription.Text, Convert.ToDecimal(txtPrice.Text), sizeOrManufacturer);
                }

                else
                {
                    //Calls Supply constructor and places new supply object into invItem object
                    invItem = new Supply(Convert.ToInt32(txtItemNo.Text),
                    txtDescription.Text, Convert.ToDecimal(txtPrice.Text), sizeOrManufacturer);
                }
                
                //Closes form
                this.Close();
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtItemNo) &&
                   Validator.IsInt32(txtItemNo) &&
                   Validator.IsPresent(txtDescription) &&
                   Validator.IsPresent(txtPrice) &&
                   Validator.IsDecimal(txtPrice);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoPlant_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPlant.Checked)
            {
                lblSizeOrManufacturer.Text = "Size:";
            }
            else
            {
                lblSizeOrManufacturer.Text = "Manufacturer:";
            }
            LoadComboBox();
        }
    }
}
