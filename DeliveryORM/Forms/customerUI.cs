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
    public partial class customerUI : Form
    {
        private int glCustomer;
        private int glAddress;
        public customerUI()
        {
            InitializeComponent();
            CreateShipmentButt.Enabled = false;

            InitComboBox();
        }

        private void InitComboBox()
        {
            List<User> customers = dbProcesor.Customers();

            foreach(User customer in customers)
            {
                customerBox.Items.Add(customer.Id + "   " + customer.Person.FullName + "   " + customer.Login);
            }
        }

        private void InitShipmentsView()
        {
            List<User> customers = dbProcesor.Customers();

            ShipmentsView.Clear();
            ShipmentsView.TabIndex = 0;
            ShipmentsView.View = System.Windows.Forms.View.Details;
            ShipmentsView.MultiSelect = true;
            ShipmentsView.GridLines = true;


            ColumnHeader id = new ColumnHeader();
            id.Text = "ID zásielky";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 150;

            ColumnHeader price = new ColumnHeader();
            price.Text = "Cena";
            price.TextAlign = HorizontalAlignment.Center;
            price.Width = 150;

            ColumnHeader DeliveryPrice = new ColumnHeader();
            DeliveryPrice.Text = "Cena doručenia";
            DeliveryPrice.TextAlign = HorizontalAlignment.Center;
            DeliveryPrice.Width = 150;

            ColumnHeader state = new ColumnHeader();
            state.Text = "Aktuálny stav";
            state.TextAlign = HorizontalAlignment.Center;
            state.Width = 150;

            this.ShipmentsView.Columns.Add(id);
            this.ShipmentsView.Columns.Add(price);
            this.ShipmentsView.Columns.Add(DeliveryPrice);
            this.ShipmentsView.Columns.Add(state);

            List<Shipment> Shipments = dbProcesor.CustomerShipments(glCustomer);

            if (Shipments == null) return;

            foreach (Shipment s in Shipments)
            {
                ListViewItem item = new ListViewItem(s.Id.ToString());
                item.SubItems.Add(s.Price.ToString()+ "€");
                item.SubItems.Add(s.DeliveryPrice.ToString() + "€");
                item.SubItems.Add(s.State);
                ShipmentsView.Items.Add(item);

            }
        }


        private void customerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = customerBox.Text;
            string[] splited = tmp.Split(' ');
            Int32.TryParse(splited[0], out glCustomer);

            InitShipmentsView();
            CreateShipmentButt.Enabled = true;
        }

        private void customerUI_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateShipmentButt_Click(object sender, EventArgs e)
        {
            CreateShipment cs = new CreateShipment(glCustomer);

            using (cs)
            {
                cs.ShowDialog();
            }

            InitShipmentsView();
        }
    }
}
