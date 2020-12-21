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
    public partial class courierUI : Form
    {
        int courierID;
        public courierUI()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void InitComboBox()
        {

            List<User> couriers = dbProcesor.Couriers();

            foreach (User user in couriers)
            {
                courierBox.Items.Add(user.Id + " " + user.Person.FullName + " " + user.Login);
            }
        }


        private void InitLateShipments()
        {

            lateshipmentsView.Clear();
            lateshipmentsView.TabIndex = 0;
            lateshipmentsView.View = System.Windows.Forms.View.Details;
            lateshipmentsView.MultiSelect = true;
            lateshipmentsView.GridLines = true;

            ColumnHeader id = new ColumnHeader();
            id.Text = "ID zásielky";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 150;

            ColumnHeader delay = new ColumnHeader();
            delay.Text = "Oneskorenie";
            delay.TextAlign = HorizontalAlignment.Center;
            delay.Width = 150;

            ColumnHeader DeliveryTime = new ColumnHeader();
            DeliveryTime.Text = "Čas pred. doručenia";
            DeliveryTime.TextAlign = HorizontalAlignment.Center;
            DeliveryTime.Width = 150;

            this.lateshipmentsView.Columns.Add(id);
            this.lateshipmentsView.Columns.Add(delay);
            this.lateshipmentsView.Columns.Add(DeliveryTime);


            List<Shipment> Shipments = dbProcesor.SelectCurrLateShipmentsByCourierId(courierID);

            if (Shipments == null) return;

            foreach (Shipment s in Shipments)
            {
                ListViewItem item = new ListViewItem(s.Id.ToString());
                item.SubItems.Add(s.Delay.ToString());
                item.SubItems.Add(s.DeliveryTime.ToString());
                lateshipmentsView.Items.Add(item);
            }
        }

        private void InitNotDoneShipments()
        {
            notdoneListView.Clear();
            notdoneListView.TabIndex = 0;
            notdoneListView.View = System.Windows.Forms.View.Details;
            notdoneListView.MultiSelect = true;
            notdoneListView.GridLines = true;

            ColumnHeader id = new ColumnHeader();
            id.Text = "ID zásielky";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 150;

            ColumnHeader deltime = new ColumnHeader();
            deltime.Text = "Čas predp. doručenia";
            deltime.TextAlign = HorizontalAlignment.Center;
            deltime.Width = 150;

            ColumnHeader customer = new ColumnHeader();
            customer.Text = "Zákazník";
            customer.TextAlign = HorizontalAlignment.Center;
            customer.Width = 150;

            this.notdoneListView.Columns.Add(id);
            this.notdoneListView.Columns.Add(deltime);
            this.notdoneListView.Columns.Add(customer);


            List<Shipment> Shipments = dbProcesor.SelectNotDoneShipmentsByCourierId(courierID);

            if (Shipments == null) return;

            foreach (Shipment s in Shipments)
            {
                ListViewItem item = new ListViewItem(s.Id.ToString());
                item.SubItems.Add(s.DeliveryTime.ToString());
                item.SubItems.Add(s.Person.FullName);
                notdoneListView.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = courierBox.Text;
            string[] splited = tmp.Split(' ');
            Int32.TryParse(splited[0], out courierID);

            MessageBox.Show(courierID.ToString());

            InitLateShipments();
            InitNotDoneShipments();
        }

        private void courierUI_Load(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void notdoneListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
