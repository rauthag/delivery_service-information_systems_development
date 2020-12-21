using AuctionSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Forms
{
    public partial class addUser : Form
    {
        private string gType;
        private bool checker = false;

        public addUser()
        {
            InitializeComponent();
            ok.Enabled = false;
            initComboBox();
            if (comboBox1.SelectedItem == null || genderBox.SelectedItem == null)
            {
                ok.Enabled = false;
            }
            else
            {
                ok.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tmp = comboBox1.Text;
            if (tmp.Equals("Zákazník"))
            {
                gType = "customer";
            }
            if (tmp.Equals(" Kuriér"))
            {
                gType = "courier";
            }
            if (tmp.Equals("Predajca"))
            {
                gType = "seller";
            }
            if (tmp.Equals("Správca skladu"))
            {
                gType = "storage manager";
            }

            if (comboBox1.SelectedItem == null || genderBox.SelectedItem == null)
            {
                ok.Enabled = false;
            }
            else
            {
                ok.Enabled = true;
            }

        }

        private void initComboBox()
        {
            comboBox1.Items.Add("Zákazník");
            comboBox1.Items.Add("Kuriér");
            comboBox1.Items.Add("Predajca");
            comboBox1.Items.Add("Správca skladu");

            for (int i = 1; i <= 31; i++)
            {
                if(i <= 12)
                {
                    monthBox.Items.Add(i.ToString());
                }
                dayBox.Items.Add(i.ToString());
            }

            genderBox.Items.Add("Muž");
            genderBox.Items.Add("Žena");

            yearBox.MaxLength = 4;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string city = cityInput.Text;
            string street = streetInput.Text;
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string birthDate = yearBox.Text + "-" + monthBox.Text + "-" + dayBox.Text;
            string type = gType;
            string login = firstName.Substring(0,3) + RandomString("number", 4).ToLower();
            string phoneNumber = "+421" + RandomString("number", 9);
            string email = RandomString("word", 5) + "@email.com";
            string gender = genderBox.Text;


            ok.Enabled = false;
            if (city.Length > 20)
            {
                MessageBox.Show("Názov mesta je príliš dlhý");
            }

            else if (street.Length > 20)
            {
                MessageBox.Show("Názov ulice je príliš dlhý");
            }

            else if (firstName.Length > 30)
            {
                MessageBox.Show("Meno užívateľa je príliš dlhé");
            }
            else if (firstName.Length > 30)
            {
                MessageBox.Show("Priezvisko užívateľa je príliš dlhé");
            }
            else
            {
                checker = true;
                ok.Enabled = true;
            }
            if(checker == true)
            {
                int result = dbProcesor.InsertUser(firstName, lastName, birthDate, phoneNumber, email,
                                                   gender, city, street, login, type);
                MessageBox.Show("Užívateľ " + firstName + " " + lastName + " bol vytvorený");
                Close();

            }


        }

        private void firstNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dayBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private static string RandomString(string type, int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWZ";
            const string numPool = "0123456789";
            var builder = new StringBuilder();
            Random random_ = new Random();

            if (type == "word")
            {
                for (var i = 0; i < length; i++)
                {
                    var c = pool[random_.Next(0, pool.Length)];
                    builder.Append(c);

                }
            }
            if (type == "number")
            {
                for (var i = 0; i < length; i++)
                {
                    var c = numPool[random_.Next(0, numPool.Length)];
                    builder.Append(c);

                }
            }

            return builder.ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void yearBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void yearBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void addUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cityInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void streetInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
