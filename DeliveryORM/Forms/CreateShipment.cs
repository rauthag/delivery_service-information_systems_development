using AuctionSystem.ORM;
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
    public partial class CreateShipment : Form
    {
        string productString = "";
        string gType;
        int globalId;

        public CreateShipment(int glCustomer)
        {
            globalId = glCustomer;
            InitializeComponent();
            button1.Enabled = false;
            InitProducts();
            InitComboBox();
        }

        private void InitProducts()
        {

            ProductsView.Rows.Clear();
            List<Product> products = dbProcesor.Products();

            int i = 0;

            ProductsView.Columns[0].Width = 100;
            ProductsView.Columns[1].Width = 150;
            ProductsView.Columns[2].Width = 150;
            ProductsView.Columns[3].Width = 150;
            ProductsView.Columns[4].Width = 150;
            ProductsView.Columns[5].Width = 150;


            foreach (Product p in products)
            {
                ProductsView.Rows.Add();
                ProductsView.Rows[i].Cells[0].Value = p.Id;
                ProductsView.Rows[i].Cells[1].Value = p.Name;
                ProductsView.Rows[i].Cells[2].Value = p.Price;
                ProductsView.Rows[i].Cells[3].Value = p.Weight;
                ProductsView.Rows[i].Cells[4].Value = "Pridať";
                ProductsView.Rows[i].Cells[5].Value = "Odobrať";
                ProductsView.Rows[i].Cells[6].Value = 0;
                i++;
            }


        }

        private void InitComboBox()
        {
            comboBox1.Items.Add("Na moju adresu");
            comboBox1.Items.Add("Na predajňu");
            comboBox1.Items.Add("Zásielkový box");
        }

        private void CreateShipment_Load(object sender, EventArgs e)
        {

        }


        private void shipmentView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (ProductsView.Columns[e.ColumnIndex].Name == "addButton")
                {
                    int id = Int32.Parse(ProductsView.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ProductsView.Rows[e.RowIndex].Cells[6].Value = Int32.Parse(ProductsView.Rows[e.RowIndex].Cells[6].Value.ToString()) + 1;
                    
                }

                if (ProductsView.Columns[e.ColumnIndex].Name == "deleteButt")
                {
                    if (Int32.Parse(ProductsView.Rows[e.RowIndex].Cells[6].Value.ToString()) == 0)
                    {
                        return;
                    }

                    int id = Int32.Parse(ProductsView.Rows[e.RowIndex].Cells[0].Value.ToString());


                    ProductsView.Rows[e.RowIndex].Cells[6].Value = Int32.Parse(ProductsView.Rows[e.RowIndex].Cells[6].Value.ToString()) - 1;

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            button1.Enabled = true;
            String tmp = comboBox1.Text;
            if (tmp.Equals("Na moju adresu"))
            {
                gType = "na adresu zákazníka - test";
            }
            if (tmp.Equals("Na predajňu"))
            {
                gType = "na predajňu - test";
            }
            if (tmp.Equals("Zásielkový box - test"))
            {
                gType = "na box";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < ProductsView.Rows.Count; i++)
            {
                for(int j = 0; j < Int32.Parse(ProductsView.Rows[i].Cells[6].Value.ToString()); j++)
                {
                    productString += ProductsView.Rows[i].Cells[0].Value.ToString() + ",";
                }
            }
            MessageBox.Show(productString);

            dbProcesor.CreateAndUpdateShipment("newTest", globalId, 1, 2, 2, productString);
            Close();
        }
    }
}
