using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp
{
    
    public partial class CustomerUi : Form
    {
        int id;
        CustomerManager _customerManager = new CustomerManager();
        Customer customer = new Customer();
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void show_button_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            //Check UNIQUE
            if (_customerManager.IsNameExists(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!");
                return;
            }

            //Set Price as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("name Can not be Empty!!!");
                return;
            }

            customer.Name = nameTextBox.Text;
            customer.Contact = phoneTextBox.Text;
            customer.Address=addressTextBox.Text;

            //Add/Insert Item
            bool isAdded = _customerManager.Add(customer);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

           // showDataGridView.DataSource = _itemManager.Display();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            
            
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Phone Can not be Empty!!!");
                return;
            }
            customer.Id =id;
            customer.Name = nameTextBox.Text;
            customer.Contact = phoneTextBox.Text;
            customer.Address = addressTextBox.Text;

            if (_customerManager.Update(customer))
            {
                MessageBox.Show("Updated");
               // showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {

            //Set Id as Mandatory
            //if (String.IsNullOrEmpty(idTextBox.Text))
            //{
            //    MessageBox.Show("Id Can not be Empty!!!");
            //    return;
            //}
            customer.Id = id;
            //Delete
            if (_customerManager.Delete(customer))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

           // showDataGridView.DataSource = _itemManager.Display();
        }
        
        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = showDataGridView.Rows[e.RowIndex];
                //idTextBox.Text = row.Cells[0].Value.ToString();
                id = Convert.ToInt32(row.Cells[0].Value.ToString());
                nameTextBox.Text = row.Cells[1].Value.ToString();
                addressTextBox.Text = row.Cells[2].Value.ToString();
                phoneTextBox.Text = row.Cells[3].Value.ToString();



            }
        }
    }
}
