using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GroupProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Class scope declarations
        private const int cSize = 100;
        private string[] mName = new string[cSize];
        private string[] mCell = new string[cSize];
        private string[] mWork = new string[cSize];
        private string[] mID = new string[cSize];
        int mIndex = 0;
        private string mFileName = Path.Combine(Application.StartupPath, "Employees.txt");

        //HELPER METHODS
        //

        //Dispaly a Message
        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Make Name Copy
        private void MakeNameCopy(string[] mName, string[] mNameCopy, int entries)
        {
            int ctr;
            for (ctr = 0; ctr < mIndex; ctr++)
            {
                mNameCopy[ctr] = mName[ctr];
            }
        }

        //Make ID Copy
        private void MakeIDCopy(string[] mID, string[] mIDCopy, int entries)
        {
            int ctr;
            for (ctr = 0; ctr < mIndex; ctr++)
            {
                mIDCopy[ctr] = mID[ctr];
            }
        }

        //Add number text boxes
        private string AddCell()
        {
            string cell = "";
            if (chkCell.Checked == true)
            {
                cell = txtCellArea.Text + "-" + txtCell1.Text + "-" + txtCell2.Text;
            }
            return cell;
        }
        private string AddWork()
        {
            string work = "";
            if (chkWork.Checked == true)
            {
                work = txtWorkArea.Text + "-" + txtWork1.Text + "-" + txtWork2.Text;
            }
            return work;
        }
        //Create a Header in output
        private void DisplayHeader()
        {
            lstOutput.Items.Add("Name              ID                Work            Cell");
            lstOutput.Items.Add("========================================================================================");
        }

        //Validate Input
        private bool ValidateInput()
            {
            //Checks if a name is entered
            if (txtName.Text == "")
            {
                DisplayMessage("Please enter a name!");
                txtName.Focus();
                return false;
            }
            //Checks whether or not a first and last name was entered
                string fullname = txtName.Text;
                var names = fullname.Split(' ');
                if (names.Length != 2)
                {
                    DisplayMessage("Please provide only a first, then last name!");
                    txtName.Focus();
                    return false;
                }

            //Checks if an ID number was entered
            if (txtID.Text == "")
            {
                DisplayMessage("Please enter an ID!");
                txtID.Focus();
                return false;
            }
            //Checks whether or not ID is in numeral format
            int id;
            if (int.TryParse(txtID.Text, out id) == false)
            {
                DisplayMessage("Please enter an ID number as numerals!");
                txtID.Focus();
                return false;
            }
            //Checks if the cell number digits are entered and in numeral format
            int number;
            if (chkCell.Checked == true)
            {
                if (txtCellArea.Text == "" || (txtCellArea.Text).Length != 3)
                {
                    DisplayMessage("Please enter the full area code for the cell number!");
                    txtCellArea.Focus();
                    return false;
                }
                if (txtCell1.Text == "" || (txtCell1.Text).Length != 3)
                {
                    DisplayMessage("Please enter all of the second three digits for the cell number!");
                    txtCell1.Focus();
                    return false;
                }
                if (txtCell2.Text == "" || (txtCell2.Text).Length != 4)
                {
                    DisplayMessage("Please enter all of the last four digits for the cell number!");
                    txtCell2.Focus();
                    return false;
                }
                if (int.TryParse(txtCellArea.Text, out number) == false)
                {
                    DisplayMessage("Please enter the three digit area code of the cell number as numerals!");
                    txtCellArea.Focus();
                    return false;
                }
                if (int.TryParse(txtCell1.Text, out number) == false)
                {
                    DisplayMessage("Please enter the second three digits of the cell number as numerals!");
                    txtCell1.Focus();
                    return false;
                }
                if (int.TryParse(txtCell2.Text, out number) == false)
                {
                    DisplayMessage("Please enter the last four digits of the cell number as numerals!");
                    txtCell2.Focus();
                    return false;
                }
            }
            //Checks if the work number digits are entered and in numeral format
            if (chkWork.Checked == true)
            {
                if (txtWorkArea.Text == "" || (txtWorkArea.Text).Length != 3)
                {

                    DisplayMessage("Please enter the full area code for the work number!");
                    txtWorkArea.Focus();
                    return false;
                }
                if (txtWork1.Text == "" || (txtWork1.Text).Length != 3)
                {
                    DisplayMessage("Please enter all of the second three digits for the work number!");
                    txtWork1.Focus();
                    return false;
                }
                if (txtWork2.Text == "" || (txtWork2.Text).Length != 4)
                {
                    DisplayMessage("Please enter all of the last four digits for the work number!");
                    txtWork2.Focus();
                    return false;
                }
                if (int.TryParse(txtWorkArea.Text, out number) == false)
                {
                    DisplayMessage("Please enter the three digit area code of the work number as numerals!");
                    txtWork1.Focus();
                    return false;
                }
                if (int.TryParse(txtWork1.Text, out number) == false)
                {
                    DisplayMessage("Please enter the second three digits of the work number as numerals!");
                    txtWork1.Focus();
                    return false;
                }
                if (int.TryParse(txtWork2.Text, out number) == false)
                {
                    DisplayMessage("Please enter the last four digits of the work number as numerals!");
                    txtWork2.Focus();
                    return false;
                }
            }
            return true;
        }
        private void ClearInput()
        {
            chkCell.Checked = false;
            chkWork.Checked = false;
            txtCell1.Clear();
            txtCell2.Clear();
            txtCellArea.Clear();
            txtID.Clear();
            txtName.Clear();
            txtWork1.Clear();
            txtWork2.Clear();
            txtWorkArea.Clear();
            txtName.Focus();
        }
        //Display helper method
        private void Display()
        {
            int ctr;
            lstOutput.Items.Clear();
            //Checks if there are no employees entered
            if (mIndex == 0)
            {
                DisplayMessage("No employees have been entered!");
                return;
            }
            else
            {
                DisplayHeader();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    lstOutput.Items.Add(mName[ctr].PadRight(18) + mID[ctr].PadRight(18) + mWork[ctr].PadRight(16) + mCell[ctr].PadRight(15));
                }
            }
        }
        //
        //HELPER METHODS
       
        //Event of the 'Enter' button being clicked
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //Call Validate input helper method
            if (ValidateInput() == false)
            {
                return;
            }
            else
            {
                // variables to split name
                mName[mIndex] = txtName.Text;
                mID[mIndex] = txtID.Text;
                //Inputs phone numbers in arrays, if needed
                if (chkCell.Checked == true)
                {
                    mCell[mIndex] = AddCell();
                }
                else
                {
                    mCell[mIndex] = "n/a";
                }
                if (chkWork.Checked == true)
                {
                    mWork[mIndex] = AddWork();
                }
                else
                {
                    mWork[mIndex] = "n/a";
                }
                mIndex++;
                ClearInput();
                Display();
                //Checks if arrays are full
                if (mIndex == cSize)
                {
                    DisplayMessage("Max # of employees have been entered!");
                    btnEnter.Enabled = false;
                    return;
                }
            }
        }

        //Event of the button 'Display' being clicked
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Display();
        }
        //Event of the button 'Clear Inputs' being clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
            btnEnter.Enabled = true;
            btnUpdate.Enabled = true;
        }
        //Event of the button 'Clear All' being clicked
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearInput();
            lstOutput.Items.Clear();
            btnEnter.Enabled = true;
            btnUpdate.Enabled = true;
        }
        //Event of the button 'Search' being clicked
        private void btnLookUp_Click(object sender, EventArgs e)
        {
            if (mIndex == 0)
            {
                DisplayMessage("There is nothing to search: no employees have been entered.");
                return;
            }
            btnEnter.Enabled = false;
            btnUpdate.Enabled = false;
            lstOutput.Items.Clear();
            int ctr;
            bool flag = false;
            DisplayHeader();
            if (txtName.Text != "")
            {
                string name = (txtName.Text).ToLower();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (((mName[ctr]).ToLower()).Contains(name))
                    {
                        lstOutput.Items.Add(mName[ctr].PadRight(18) + mID[ctr].PadRight(18) + mWork[ctr].PadRight(16) + mCell[ctr].PadRight(15));
                        flag = true;
                    }
                }
            }
            else if (txtID.Text != "")
            {
                string id = txtID.Text;
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mID[ctr] == id)
                    {
                        lstOutput.Items.Add(mName[ctr].PadRight(18) + mID[ctr].PadRight(18) + mWork[ctr].PadRight(16) + mCell[ctr].PadRight(15));
                        flag = true;
                    }
                }
            }
            else if (txtCellArea.Text != "" || txtCell1.Text != "" || txtCell2.Text != "")
            {
                string cell = AddCell();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mCell[ctr] == cell)
                    {
                        lstOutput.Items.Add(mName[ctr].PadRight(18) + mID[ctr].PadRight(18) + mWork[ctr].PadRight(16) + mCell[ctr].PadRight(15));
                        flag = true;
                    }
                }
            }
            else if (txtWorkArea.Text != "" || txtWork1.Text != "" || txtWork2.Text != "")
            {
                string work = AddWork();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mWork[ctr] == work)
                    {
                        lstOutput.Items.Add(mName[ctr].PadRight(18) + mID[ctr].PadRight(18) + mWork[ctr].PadRight(16) + mCell[ctr].PadRight(15));
                        flag = true;
                    }
                }
            }
            if (flag == false)
            {
                DisplayMessage("Nothing was found.");
                btnEnter.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }
        //Event of the form being closed.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if(mIndex != 0)
            {
                StreamWriter SW = null;
                SW = new StreamWriter(mFileName);
                int ctr;
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    SW.WriteLine(mName[ctr] + "\t" + mID[ctr] + "\t" + mWork[ctr] + "\t" + mCell[ctr]);
                }
                SW.Close();
            }
        }
        //Event of the form being loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            txtCellArea.Enabled = false;
            txtCell1.Enabled = false;
            txtCell2.Enabled = false;
            txtWorkArea.Enabled = false;
            txtWork1.Enabled = false;
            txtWork2.Enabled = false;
            if (File.Exists(mFileName) == false)
            {
                DisplayMessage("No previous data exists.");
                return;
            }
            else
            {
                StreamReader SR = null;
                SR = new StreamReader(mFileName);
                string[] parts;
                string line = SR.ReadLine();
                while (line != null)
                {
                    parts = line.Split('\t');
                    mName[mIndex] = parts[0];
                    mID[mIndex] = parts[1];
                    mWork[mIndex] = parts[2];
                    mCell[mIndex] = parts[3];
                    mIndex++;
                    line = SR.ReadLine();
                }
                SR.Close();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Event of the button 'Sort by Name' being clicked
        private void sortName_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();
            string[] mNameCopy = new string[cSize];
            MakeNameCopy(mName, mNameCopy, mIndex);
            string[] mNameCopy2 = new string[cSize];
            MakeNameCopy(mName, mNameCopy2, mIndex);
            Array.Sort(mName, mID, 0, mIndex);
            Array.Sort(mNameCopy, mCell, 0, mIndex);
            Array.Sort(mNameCopy2, mWork, 0, mIndex);
            int ctr;
            if (mIndex == 0)
            {
                DisplayMessage("No employees have been entered!");
                return;
            }
            else
            {
                DisplayHeader();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    lstOutput.Items.Add(mName[ctr].PadRight(18) + mID[ctr].PadRight(18) + mWork[ctr].PadRight(16) + mCell[ctr].PadRight(15));
                }
            }
        }
        //Event of the button 'Sort by ID' being clicked
        private void sortID_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();
            string[] mIDCopy = new string[cSize];
            MakeIDCopy(mID, mIDCopy, mIndex);
            string[] mIDCopy2 = new string[cSize];
            MakeIDCopy(mID, mIDCopy2, mIndex);
            Array.Sort(mID, mName, 0, mIndex);
            Array.Sort(mIDCopy, mCell, 0, mIndex);
            Array.Sort(mIDCopy2, mWork, 0, mIndex);
            int ctr;
            if (mIndex == 0)
            {
                DisplayMessage("No employees have been entered!");
                return;
            }
            else
            {
                DisplayHeader();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    lstOutput.Items.Add(mName[ctr].PadRight(18) + mID[ctr].PadRight(18) + mWork[ctr].PadRight(16) + mCell[ctr].PadRight(15));
                }
            }
        }
        //Event of the button 'Delete All Contacts' being clicked
        private void deleteAll_Click(object sender, EventArgs e)
        {
            if (mIndex == 0)
            {
                DisplayMessage("No employees have been entered!");
                return;
            }
            DialogResult result = MessageBox.Show("***WARNING***: This will delete all contacts entered into the system. " +
                "Would you still like to proceed?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                File.Delete(mFileName);
                int ctr;
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    mName[ctr] = null;
                    mID[ctr] = null;
                    mCell[ctr] = null;
                    mWork[ctr] = null;
                }
                mIndex = 0;
                lstOutput.Items.Clear();
                DisplayMessage("All data has sucessfully been deleted.");
            }
        }
        //Event of the button 'deleteSelected' being clicked
        private void deleteSelected_Click(object sender, EventArgs e)
        {
            if (mIndex == 0)
            {
                DisplayMessage("There is nothing to delete: no employees have been entered.");
                return;
            }
            if (lstOutput.SelectedIndex == -1)
            {
                DisplayMessage("Please select an employee to delete.");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you would like to delete the entry?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                {
                return;
                }
            else
            {
                int index = lstOutput.SelectedIndex;
                int ctr;
                mIndex--;
                for(ctr=index; (ctr-2) < mIndex; ctr++)
                {
                    mName[ctr - 2] = mName[ctr - 1];
                    mID[ctr - 2] = mID[ctr - 1];
                    mCell[ctr - 2] = mCell[ctr - 1];
                    mWork[ctr - 2] = mWork[ctr - 1];
                }
            }
            ClearInput();
            Display();
            btnEnter.Enabled = true;
            btnUpdate.Enabled = true;
        }
        //Event of the cell checkbox status changing
        private void chkCell_CheckedChanged(object sender, EventArgs e)
        {
            txtCellArea.Enabled ^= true;
            txtCell1.Enabled ^= true;
            txtCell2.Enabled ^= true;
        }
        //Event of the work checkbox status changing
        private void chkWork_CheckedChanged(object sender, EventArgs e)
        {
            txtWorkArea.Enabled ^= true;
            txtWork1.Enabled ^= true;
            txtWork2.Enabled ^= true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Call Validate input helper method
            if (ValidateInput() == false)
            {
                return;
            }
            else
            {
                try
                {
                    int index = lstOutput.SelectedIndex;
                    // variables to split name
                    mName[index - 2] = txtName.Text;
                    mID[index - 2] = txtID.Text;
                    //Inputs phone numbers in arrays, if needed
                    if (chkCell.Checked == true)
                    {
                        mCell[index - 2] = AddCell();
                    }
                    else
                    {
                        mCell[index - 2] = "n/a";
                    }
                    if (chkWork.Checked == true)
                    {
                        mWork[index - 2] = AddWork();
                    }
                    else
                    {
                        mWork[index - 2] = "n/a";
                    }
                    ClearInput();
                    btnEnter.Enabled = true;
                    Display();
                }
                catch (Exception ex)
                {
                    DisplayMessage("Please select an employee to update.");
                    Display();
                }
            }
        }
        private void lstOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index;
                index = lstOutput.SelectedIndex;
                btnEnter.Enabled = false;
                ClearInput();
                txtName.Text = mName[index - 2];
                txtID.Text = mID[index - 2];
                if (mCell[index - 2] != "n/a")
                {
                    txtCellArea.Text = (mCell[index - 2]).Substring(0, 3);
                    txtCell1.Text = (mCell[index - 2]).Substring(4, 3);
                    txtCell2.Text = (mCell[index - 2]).Substring(8, 4);
                    chkCell.Checked = true;
                }
                if (mWork[index - 2] != "n/a")
                {
                    txtWorkArea.Text = (mWork[index - 2]).Substring(0, 3);
                    txtWork1.Text = (mWork[index - 2]).Substring(4, 3);
                    txtWork2.Text = (mWork[index - 2]).Substring(8, 4);
                    chkWork.Checked = true;
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("You cannot click here!");
            }
        }

    }
}