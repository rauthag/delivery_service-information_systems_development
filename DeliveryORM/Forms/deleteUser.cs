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
    public partial class deleteUser : Form
    {
        private List<User> users;
        private int globalID;
        private string globalName;
        private string gType;
     
        public deleteUser()
        {
            InitializeComponent();
            ok.Enabled = false;
            InitComboBox();
        }

        public void InitComboBox()
        {
            users = dbProcesor.GetUserList();

            if (users == null) return;

            foreach (User user in users)
            {
                usersBox.Items.Add(user.Id + "/" + user.Person.FullName + "/" + user.Login);
            }
        }

        private void deleteUser_Load(object sender, EventArgs e)
        {

        }

        private void usersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = usersBox.Text;
            string[] splited = tmp.Split('/');
            Int32.TryParse(splited[0], out globalID);
            globalName = splited[1];


            if (usersBox.SelectedItem == null)
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
            int id = globalID;

            dbProcesor.DeleteUser(id);
            MessageBox.Show("Užívateľ bol" + " " + globalName + " bol vymazaný");
            Close();
        }
    }
}
