using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp
{

    public partial class ItemUi : Form
    {


        ItemManager _itemManager = new ItemManager();
        Item item = new Item();
        int itemid;
        public ItemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
           
            
            //Check UNIQUE
            if (_itemManager.IsNameExists(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!");
                return;
            }
            item.Name = nameTextBox.Text;
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            item.Price = Convert.ToDouble(priceTextBox.Text);

            //Add/Insert Item
            bool isAdded = _itemManager.Add(item);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

              showDataGridView.DataSource =  _itemManager.Display();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
              showDataGridView.DataSource =  _itemManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {


            //Set Id as Mandatory
            //if (String.IsNullOrEmpty(idTextBox.Text))
            //{
            //    MessageBox.Show("Id Can not be Empty!!!");
            //    return;
            //}

            //Delete

            item.ID = itemid;
            if (_itemManager.Delete(item))
            {
                MessageBox.Show("Deleted");
              //  itemComboBox.DataSource = _itemManager.ComboDisplay();
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

             showDataGridView.DataSource = _itemManager.Display();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
         //   showDataGridView.DataSource = _itemManager.Search(itemComboBox.GetItemText(itemComboBox.SelectedItem));
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Check Unique
            if (_itemManager.IsNameExists(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!");
                return;
            }
            item.Name = nameTextBox.Text;
            //Set Id as Mandatory
            //if (String.IsNullOrEmpty(idTextBox.Text))
            //{
            //    MessageBox.Show("Id Can not be Empty!!!");
            //    return;
            //}
            item.ID = itemid; //Convert.ToInt32( idTextBox.Text);
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }
            item.Price = Convert.ToInt32(priceTextBox.Text);

            if (_itemManager.Update(item))
            {
                MessageBox.Show("Updated");
                  showDataGridView.DataSource = _itemManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

   
        //Method
        
       
       
       
        
       

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ItemUi_Load(object sender, EventArgs e)
        {
            //itemComboBox.DataSource = _itemManager.ComboDisplay();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = showDataGridView.Rows[e.RowIndex];
                //idTextBox.Text = row.Cells[0].Value.ToString();
                itemid = Convert.ToInt32(row.Cells[0].Value.ToString());
                nameTextBox.Text = row.Cells[1].Value.ToString();
                priceTextBox.Text = row.Cells[2].Value.ToString();



            }
        }

        private void customer_show_button_Click(object sender, EventArgs e)
        {
            new CustomerUi().Show();

        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            new OrderUi().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //showDataGridView.DataSource = _itemManager.Search(itemComboBox.GetItemText(itemComboBox.SelectedItem));
        }
    }
}
