using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuctionSystem;
using AuctionSystem.ORM;

namespace Forms
{
    public partial class adminUI : Form
    {
        private List<User> users;
        private List<Shipment> allShipments;
        private string glState;
        private int globalcourID;
        List<User> couriers;
        List<Shipment> LateShipmentsC;

        public adminUI()
        {
            InitializeComponent();
            initComboBox();
            InitAllShipments();
            InitUserList();
            InitStateList();
        }
        private void initComboBox()
        {
            doneBox.Items.Add("Vyzdvihnutá");
            doneBox.Items.Add("Nevyzdvihnutá");
            doneBox.Items.Add("Zrušená zákazníkom");


            couriers = dbProcesor.Couriers();

            foreach (User user in couriers)
            {
                courierBox.Items.Add(user.Id + "/" + user.Person.FullName + "/" + user.Login);
            }

        }

        public void InitLateC()
        {
            LateCView.Clear();
            LateCView.TabIndex = 0;
            LateCView.View = System.Windows.Forms.View.Details;
            LateCView.MultiSelect = true;
            LateCView.GridLines = true;

            ColumnHeader id = new ColumnHeader();
            id.Text = "ID";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 100;

            ColumnHeader delay = new ColumnHeader();
            delay.Text = "Oneskorenie";
            delay.TextAlign = HorizontalAlignment.Center;
            delay.Width = 100;

            ColumnHeader deliveryTime = new ColumnHeader();
            deliveryTime.Text = "Mala byť doručená";
            deliveryTime.TextAlign = HorizontalAlignment.Center;
            deliveryTime.Width = 160;

            ColumnHeader delivered = new ColumnHeader();
            delivered.Text = "Bola doručená";
            delivered.TextAlign = HorizontalAlignment.Center;
            delivered.Width = 160;

            this.LateCView.Columns.Add(id);
            this.LateCView.Columns.Add(delay);
            this.LateCView.Columns.Add(deliveryTime);
            this.LateCView.Columns.Add(delivered);

            LateShipmentsC = dbProcesor.LateShipmentsByCourierId(globalcourID);



            if (LateShipmentsC == null) return;


            foreach (Shipment s in LateShipmentsC)
            {
                ListViewItem item = new ListViewItem(s.Id.ToString());
                item.SubItems.Add(s.Delay.ToString());
                item.SubItems.Add(s.DeliveryTime.ToString());
                item.SubItems.Add(s.Delivered.ToString());

                LateCView.Items.Add(item);
            }
        }

        public void InitStateList()
        {
            stateView.Clear();
            stateView.TabIndex = 0;
            stateView.View = System.Windows.Forms.View.Details;
            stateView.MultiSelect = true;
            stateView.GridLines = true;

            ColumnHeader id = new ColumnHeader();
            id.Text = "ID";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 150;

            ColumnHeader name = new ColumnHeader();
            name.Text = "Meno";
            name.TextAlign = HorizontalAlignment.Center;
            name.Width = 250;

            ColumnHeader picked = new ColumnHeader();
            picked.Text = "Vyzdvihnuté";
            picked.TextAlign = HorizontalAlignment.Left;
            picked.Width = 150;

            ColumnHeader npicked = new ColumnHeader();
            npicked.Text = "Nevyzdvihnuté";
            npicked.TextAlign = HorizontalAlignment.Left;
            npicked.Width = 150;

            ColumnHeader canceled = new ColumnHeader();
            canceled.Text = "Zrušené";
            canceled.TextAlign = HorizontalAlignment.Left;
            canceled.Width = 150;

            ColumnHeader onWay = new ColumnHeader();
            onWay.Text = "Na ceste";
            onWay.TextAlign = HorizontalAlignment.Left;
            onWay.Width = 150;


            this.stateView.Columns.Add(id);
            this.stateView.Columns.Add(name);
            this.stateView.Columns.Add(picked);
            this.stateView.Columns.Add(npicked);
            this.stateView.Columns.Add(canceled);
            this.stateView.Columns.Add(onWay);



            List<User> byState = dbProcesor.ShipmentsByState();
            if (byState == null) return;



            foreach (User u in byState)
            {
                ListViewItem item = new ListViewItem(u.Id.ToString());
                item.SubItems.Add(u.Person.FullName);
                item.SubItems.Add(u.CourPicked.ToString());
                item.SubItems.Add(u.CourNotPicked.ToString());
                item.SubItems.Add(u.CourCanceled.ToString());
                item.SubItems.Add(u.CourOnWay.ToString());
                stateView.Items.Add(item);
            }
        }

        public void InitDoneList()
        {
            DoneView.Clear();
            DoneView.TabIndex = 0;
            DoneView.View = System.Windows.Forms.View.Details;
            DoneView.MultiSelect = true;
            DoneView.GridLines = true;


            ColumnHeader id = new ColumnHeader();
            id.Text = "ID";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 250;

            ColumnHeader doneAt = new ColumnHeader();
            doneAt.Text = "Ukončené";
            doneAt.TextAlign = HorizontalAlignment.Left;
            doneAt.Width = 250;


            this.DoneView.Columns.Add(id);
            this.DoneView.Columns.Add(doneAt);

            List<Shipment> done = dbProcesor.DoneShipments(glState);

            if (done == null) return;

            foreach (Shipment s in done)
            {
                ListViewItem item = new ListViewItem(s.Id.ToString());
                item.SubItems.Add(s.DoneAt.Remove((s.DoneAt).Length - 8));
                DoneView.Items.Add(item);
            }
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


            users = dbProcesor.GetUserList();

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
                item.SubItems.Add(user.Person.BirthDay.Remove((user.Person.BirthDay).Length-8));
                userList.Items.Add(item);
            }
    }

        private void InitAllShipments()
        {

            shipmentView.Rows.Clear();
            List<Shipment> allShipments = dbProcesor.SelectAllShipments();

            int i = 0;

            shipmentView.Columns[0].Width = 320;
            shipmentView.Columns[1].Width = 320;


            foreach (Shipment shipment in allShipments)
            {
                shipmentView.Rows.Add();
                shipmentView.Rows[i].Cells[0].Value = shipment.Id;
                shipmentView.Rows[i].Cells[1].Value = "Zobraziť detail";
                i++;
            }


        }



        private void adminUI_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void addUser_Click(object sender, EventArgs e)
        {
            addUser addUser = new addUser();

            using (addUser)
            {
                addUser.ShowDialog();
            }
            InitUserList();
        }

        private void updateUser_Click(object sender, EventArgs e)
        {
            updateUser updateUser = new updateUser();

            using (updateUser)
            {
                updateUser.ShowDialog();
            }
            InitUserList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            deleteUser deleteUser = new deleteUser();

            using(deleteUser)
            {
                deleteUser.ShowDialog();
            }
            InitUserList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitUserList();
        }

        private void allShipmentsView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void shipmentView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                if(shipmentView.Columns[e.ColumnIndex].Name == "detailButton")
                {
                    int id = Int32.Parse(shipmentView.Rows[e.RowIndex].Cells[0].Value.ToString());

                    ShipmentDetail sd = new ShipmentDetail(id);
                    sd.Text += " č." + id;

                    using (sd)
                    {
                        sd.ShowDialog();
                    }
                


                }
            }
        }

        private void DoneView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void courierBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = courierBox.Text;
            string[] splited = tmp.Split('/');
            Int32.TryParse(splited[0], out globalcourID);
            InitLateC();
        }

        private void doneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tmp = doneBox.Text;
            if (tmp.Equals("Vyzdvihnutá"))
            {
                glState = "vyzdvihnuta";
                InitDoneList();
            }
            if (tmp.Equals("Nevyzdvihnutá"))
            {
                glState = "nevyzdvihnuta";
                InitDoneList();
            }
            if (tmp.Equals("Zrušená zákazníkom"))
            {
                glState = "zrusena zakaznikom";
                InitDoneList();
            }

        }

        private void stateView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LateCView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

    }
}
