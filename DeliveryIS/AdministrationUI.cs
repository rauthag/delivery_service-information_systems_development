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
using DomainLayer.Processors;
using DataTransferObject.DataTransferObjects;

namespace DeliveryIS
{
    public partial class AdministrationUI : Form
    {
        private List<User> users;
        private List<Shipment> allShipments;
        private string glState;
        private int globalcourID;
        List<User> couriers;
        List<Shipment> LateShipmentsC;

        public AdministrationUI()
        {
            InitializeComponent();
            InitUserList();
        }

        private void deleteB_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updateUser_Click(object sender, EventArgs e)
        {

        }

        private void addUser_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void InitUserList()
        {
            userList.Clear();
            userList.TabIndex = 0;
            userList.View = System.Windows.Forms.View.Details;
            userList.MultiSelect = true;
            userList.GridLines = true;

            ColumnHeader id = new ColumnHeader();
            id.Text = "ID";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 25;

            ColumnHeader firstName = new ColumnHeader();
            firstName.Text = "Meno";
            firstName.TextAlign = HorizontalAlignment.Left;
            firstName.Width = 140;

            ColumnHeader login = new ColumnHeader();
            login.Text = "Login";
            login.TextAlign = HorizontalAlignment.Left;
            login.Width = 70;

            ColumnHeader type = new ColumnHeader();
            type.Text = "Typ";
            type.TextAlign = HorizontalAlignment.Left;
            type.Width = 100;


            ColumnHeader gender = new ColumnHeader();
            gender.Text = "Pohlavie";
            gender.TextAlign = HorizontalAlignment.Left;
            gender.Width = 50;

            ColumnHeader address = new ColumnHeader();
            address.Text = "Adresa";
            address.TextAlign = HorizontalAlignment.Left;
            address.Width = 180;


            ColumnHeader email = new ColumnHeader();
            email.Text = "eMail";
            email.TextAlign = HorizontalAlignment.Left;
            email.Width = 150;

            ColumnHeader phoneNumber = new ColumnHeader();
            phoneNumber.Text = "Tel.č.";
            phoneNumber.TextAlign = HorizontalAlignment.Left;
            phoneNumber.Width = 100;

            ColumnHeader birthDay = new ColumnHeader();
            birthDay.Text = "Dátum narodenia";
            birthDay.TextAlign = HorizontalAlignment.Left;
            birthDay.Width = 80;


            this.userList.Columns.Add(id);
            this.userList.Columns.Add(firstName);
            this.userList.Columns.Add(login);
            this.userList.Columns.Add(type);
            this.userList.Columns.Add(gender);
            this.userList.Columns.Add(address);
            this.userList.Columns.Add(email);
            this.userList.Columns.Add(phoneNumber);
            this.userList.Columns.Add(birthDay);


            users = UserProcessor.GetUserList();

            if (users == null) return;

            foreach (User user in users)
            {
                ListViewItem item = new ListViewItem(user.Id.ToString());
                item.SubItems.Add(user.Person.FullName);
                item.SubItems.Add(user.Login);
                item.SubItems.Add(user.Type);
                item.SubItems.Add(user.Person.Gender);
                item.SubItems.Add(user.Person.Address.City + " " + user.Person.Address.Street);
                item.SubItems.Add(user.Person.Email);
                item.SubItems.Add(user.Person.PhoneNumber);
                item.SubItems.Add(user.Person.BirthDay.Remove((user.Person.BirthDay).Length - 8));
                userList.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();

            using (addUser)
            {
                addUser.ShowDialog();
            }
            InitUserList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();

            using (updateUser)
            {
                updateUser.ShowDialog();
            }
            InitUserList();
        }
    }
}
