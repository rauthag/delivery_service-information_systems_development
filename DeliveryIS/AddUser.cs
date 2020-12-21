using DomainLayer.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryIS
{
    public partial class AddUser : Form
    {

        private string gType;
        private bool checker = false;

        public AddUser()
        {
            InitializeComponent();
            initTypeBox();
            ok.Enabled = false;

            if (typeBox.SelectedItem == null || genderBox.SelectedItem == null)
            {
                ok.Enabled = false;
            }
            else
            {
                ok.Enabled = true;
            }

        }

        private void initTypeBox()
        {
            typeBox.Items.Add("Zákazník");
            typeBox.Items.Add("Kuriér");
            typeBox.Items.Add("Predajca");
            typeBox.Items.Add("Správca skladu");

            for (int i = 1; i <= 31; i++)
            {
                if (i <= 12)
                {
                    monthBox.Items.Add(i.ToString());
                }
                dayBox.Items.Add(i.ToString());
            }

            genderBox.Items.Add("Muž");
            genderBox.Items.Add("Žena");

            yearBox.MaxLength = 4;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tmp = typeBox.Text;
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

            if (typeBox.SelectedItem == null || genderBox.SelectedItem == null)
            {
                ok.Enabled = false;
            }
            else
            {
                ok.Enabled = true;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string city = cityInput.Text;
            string street = streetInput.Text;
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string birthDate = yearBox.Text + "-" + monthBox.Text + "-" + dayBox.Text;
            string type = gType;
            string login = firstName.Substring(0, 3) + RandomString("number", 4).ToLower();
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
            if (checker == true)
            {
                int result = UserProcessor.InsertUser(firstName, lastName, birthDate, phoneNumber, email,
                                                   gender, city, street, login, type);
                MessageBox.Show("Užívateľ " + firstName + " " + lastName + " bol vytvorený");
                Close();


            }
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


        private void yearBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
