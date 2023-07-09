using CircularProgressBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Flight_Tickets.Form1;

namespace Flight_Tickets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public stPeronInfo PersonInfo;
        public stPeronInfo PersonInfo2;
        public stPeronInfo PersonInfo3;

        static short _NumberOfPersons;

        public stMeals Meals;

        public struct stTicketDetails
        {
            public string FromWhere;
            public string ToWhere;
            public short NumberOfPersons;
            public string Date;
        };

        public struct stPeronInfo
        {
            public stTicketDetails TicketDetails;
            public string FullName;
            public string PassportNumber;
            public string PhoneNumber;
        };
        
        public struct stMeals
        {
            public short Burger;
            public short Dominos;
            public short KFC;
        }        
        private void Form1_Load(object sender, EventArgs e)
        {
            nudNumberOfPersons.Maximum = 3;
            nudNumberOfPersons.Minimum = 0;
            SetPersonsNumberPanel();
            SetPersonInfo1();
            nudNumberOfPersons.Focus();
        }

        public void SetPersonsNumberPanel()
        {


            _NumberOfPersons = (short)nudNumberOfPersons.Value;

            if (nudNumberOfPersons.Value == 0)
            {
                pnlPersonInfo1.Visible = false;
                pnlPersonInfo2.Visible = false;
                pnlPersonInfo3.Visible = false;
            }
            else if(nudNumberOfPersons.Value == 1)
            {
                pnlPersonInfo1.Visible = true;
                pnlPersonInfo2.Visible = false;
                pnlPersonInfo3.Visible = false;
            }
            else if(nudNumberOfPersons.Value == 2)
            {
                pnlPersonInfo1.Visible = true;
                pnlPersonInfo2.Visible = true;
                pnlPersonInfo3.Visible = false;
            }
            else
            {
                pnlPersonInfo1.Visible = true;
                pnlPersonInfo2.Visible = true;
                pnlPersonInfo3.Visible = true;
            }
        }

        public void Swap( ComboBox cmd1, ComboBox cmd2)
        {
            string temp;
            temp = cmd1.Text;  
            cmd1.Text = cmd2.Text;
            cmd2.Text = temp;
        }
        
        public void SetTicketInfo(ref stPeronInfo Person)
        {
            Person.TicketDetails.ToWhere = cmbToWhere.Text;
            Person.TicketDetails.FromWhere = cmbFromWhere.Text;
            Person.TicketDetails.Date = dateTimePicker1.Value.ToString("dddd, dd/MM/yy");

            if (cmbFromWhere.SelectedIndex == cmbToWhere.SelectedIndex)
            {
                MessageBox.Show("The two choices cannot be the same", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                
        }

        public void SetPersonInfo1()
        {
            PersonInfo.FullName = txtFullName.Text;
            PersonInfo.PhoneNumber = mtxtPhoneNumber.Text;
            PersonInfo.PassportNumber = txtPassportNumber.Text;


            SetTicketInfo(ref PersonInfo);
            
        }
        
        public void SetPersonInfo2()
        {
            PersonInfo2.FullName = txtFullName2.Text;
            PersonInfo2.PassportNumber = txtPassportNumber2.Text;
        }
        
        public void SetPersonInfo3()
        {
            PersonInfo3.FullName = txtFullName3.Text;
            PersonInfo3.PassportNumber = txtPassportNumber3.Text;
        }

        public string GetTicketDetails()
        {
            string Details = "    -----First Traveler----\n\n" +
                             "Full Name    : " + PersonInfo.FullName + "\n" +
                             "Phone Number : " + PersonInfo.PhoneNumber + "\n" +
                             "Passport     : " + PersonInfo.PassportNumber + " \n" +
                             "From Where   : " + PersonInfo.TicketDetails.FromWhere + "\n" +
                             "To Where     : " + PersonInfo.TicketDetails.ToWhere + "\n" +
                             "Date         : " + PersonInfo.TicketDetails.Date + "\n\n";
            if (_NumberOfPersons >= 2)
            {
                Details += "\n    -----Second Traveler----\n\n" +
                             "Full Name    : " + PersonInfo2.FullName + "\n" +
                             "Passport     : " + PersonInfo2.PassportNumber + " \n\n";
            }
            if (_NumberOfPersons >= 3)
            {
                Details += "\n    -----Thrid Traveler----\n\n" +
                             "Full Name    : " + PersonInfo3.FullName + "\n" +
                             "Passport     : " + PersonInfo3.PassportNumber + " \n";
            }
            return Details;
        }
        
        public void TakeTicket()
        {
            ListViewItem item = new ListViewItem(txtPassportNumber.Text.Trim());
            item.SubItems.Add(txtFullName.Text.Trim());
            item.SubItems.Add(mtxtPhoneNumber.Text.Trim());
            item.SubItems.Add(cmbFromWhere.Text.Trim());
            item.SubItems.Add(cmbToWhere.Text.Trim());
            item.SubItems.Add(PersonInfo.TicketDetails.Date);
            listView1.Items.Add(item);
        }

        private void nudNumberOfPersons_ValueChanged(object sender, EventArgs e)
        {
            SetPersonsNumberPanel();
        }

        private void cmbFromWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPersonInfo1();
        }

        private void cmbToWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPersonInfo1();
        }

        private void btnUpDown_Click(object sender, EventArgs e)
        {
            Swap(cmbToWhere, cmbFromWhere);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TakeTicket();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            SetPersonInfo1();
        }

        private void txtPassportNumber_TextChanged(object sender, EventArgs e)
        {
            SetPersonInfo1();
        }

        private void mtxtPhoneNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            SetPersonInfo1();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(GetTicketDetails() , "Ticket Details");
            
        }

        private void txtPassportNumber2_TextChanged(object sender, EventArgs e)
        {
            SetPersonInfo2();
        }

        private void txtFullName2_TextChanged(object sender, EventArgs e)
        {
            SetPersonInfo2();
        }

        private void txtFullName3_TextChanged(object sender, EventArgs e)
        {
            SetPersonInfo3();

        }

        private void txtPassportNumber3_TextChanged(object sender, EventArgs e)
        {
            SetPersonInfo3();
        }

        private void mtxtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            SetPersonInfo1();
        }
        
        public void Increase(Label lblMeals, string Message, ref short CountOfMeals)
        {
            CountOfMeals++;
            if(CountOfMeals > 3)
            {
                MessageBox.Show("No more than three " + Message + " meals can be taken", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CountOfMeals = 3;
            }
            lblMeals.Text = CountOfMeals.ToString();

        }

        public void Decrease(Label lblMeals, ref short CountOfMeals)
        {
            CountOfMeals--;
            if (CountOfMeals < 0)
            {
                MessageBox.Show("False Operation", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CountOfMeals = 0;
            }
            lblMeals.Text = CountOfMeals.ToString();

        }
       
        private void btnIncreaseBurger_Click(object sender, EventArgs e)
        {
            Increase(lblBurger, "Burger King", ref Meals.Burger);
        }

        private void btnIncreaseKFC_Click(object sender, EventArgs e)
        {
            Increase(lblKFC, "KFC", ref Meals.KFC);
        }

        private void btnIncreaseDominos_Click(object sender, EventArgs e)
        {
            Increase(lblDominos, "Dominos", ref Meals.Dominos);
        }

        private void btnDecreaseKFC_Click(object sender, EventArgs e)
        {
            Decrease(lblKFC, ref Meals.KFC);

        }

        private void btnDecreaseDominos_Click(object sender, EventArgs e)
        {
            Decrease(lblDominos, ref Meals.Dominos);

        }

        private void btnDecreaseBurger_Click(object sender, EventArgs e)
        {
            Decrease(lblBurger, ref Meals.Burger);

        }

        private void SetError(object sender, CancelEventArgs e, string message, params Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    e.Cancel = true;
                    control.Focus();
                    errorProvider1.SetError(control, message + " should have a value");
                }
                else if (control is MaskedTextBox maskedtextbox && string.IsNullOrWhiteSpace(maskedtextbox.Text))
                {
                    e.Cancel = true;
                    control.Focus();
                    errorProvider1.SetError(control, message + " should have a value");
                }
                else if (control is ComboBox comboBox && comboBox.SelectedItem == null)
                {
                    e.Cancel = true;
                    control.Focus();
                    errorProvider1.SetError(control, message + " should have a value");
                }
                else if (control is NumericUpDown numericUpDown && numericUpDown.Value == 0)
                {
                    e.Cancel = true;
                    control.Focus();
                    errorProvider1.SetError(control, message + " should have a value");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(control, "");
                }
            }
        }
        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            SetError(sender, e, "Full Name", txtFullName);
        }

        private void nudNumberOfPersons_Validating(object sender, CancelEventArgs e)
        {

            SetError(sender, e, "Number of person", nudNumberOfPersons);
        }

        private void cmbFromWhere_Validating(object sender, CancelEventArgs e)
        {

            SetError(sender, e, "From Where", cmbFromWhere);
        }

        private void cmbToWhere_Validating(object sender, CancelEventArgs e)
        {
            SetError(sender, e, "To Where", cmbToWhere);
        }

        private void txtPassportNumber_Validating(object sender, CancelEventArgs e)
        {
            SetError(sender, e, "Passport number", txtPassportNumber);
        }

        private void mtxtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            SetError(sender, e, "Phone number", mtxtPhoneNumber);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetPersonInfo1();
        }

        public void ResetTextBox(TextBox t1, TextBox t2, MaskedTextBox t3 = null)
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
        }

        public void Reset()
        {
            lblBurger.Text = 0.ToString();
            lblDominos.Text = 0.ToString();
            lblKFC.Text = 0.ToString();

            if (_NumberOfPersons == 1)
            {
                ResetTextBox(txtFullName, txtPassportNumber, mtxtPhoneNumber);
            }
            if (_NumberOfPersons == 2)
            {
                ResetTextBox(txtFullName2, txtPassportNumber2);
            }
            if (_NumberOfPersons == 3)
            {
                ResetTextBox(txtFullName3, txtPassportNumber3);
            }

            _NumberOfPersons = 0;

            nudNumberOfPersons.Value = 0;

            cmbFromWhere.Text = "";
            cmbToWhere.Text = "";

            dateTimePicker1.Text = DateTime.Now.ToString();
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            
            Reset();
        }

    }
}
