using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp
{
    
    public partial class OrderUi : Form
    {
        Order order = new Order();
        OrderManager _orderManager = new OrderManager();
        public OrderUi()
        {
            InitializeComponent();
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            //Check UNIQUE
            //if (_orderManager.IsNameExists(nameTextBox.Text))
            //{
            //    MessageBox.Show(nameTextBox.Text + " Already Exists!");
            //    return;
            //}

            //Set Price as Mandatory
            //if (String.IsNullOrEmpty(nameTextBox.Text))
            //{
            //    MessageBox.Show("name Can not be Empty!!!");
            //    return;
            //}

            try
            {
                Convert.ToInt32(quantityTextBox.Text);
               // Convert.ToInt32(priceTextBox.Text);
            }


            catch(FormatException exception)
            {
                MessageBox.Show("invalid input");
                return;
            }

            order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
         
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            order.Quantity = Convert.ToInt32(quantityTextBox.Text);
            
            priceTextBox.Text = Convert.ToString(_orderManager.pricefetch(order));
            int price = _orderManager.pricefetch(order);
            order.TotalPrice = order.Quantity * price;


            //Add/Insert Item
            bool isAdded = _orderManager.Add(order);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            showDataGridView.DataSource = _orderManager.Display();
        }


        
        private void show_button_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Display();
        }

        //private void search_button_Click(object sender, EventArgs e)
        //{
        //    showDataGridView.DataSource = _orderManager.Search(nameTextBox.Text);
        //}

        private void delete_button_Click(object sender, EventArgs e)
        {

            //Set Id as Mandatory
            //if (String.IsNullOrEmpty(idTextBox.Text))
            //{
            //    MessageBox.Show("Id Can not be Empty!!!");
            //    return;
            //}

            //Delete
            //if (_orderManager.Delete(Convert.ToInt32(idTextBox.Text)))
            //{
            //    MessageBox.Show("Deleted");
            //}
            //else
            //{
            //    MessageBox.Show("Not Deleted");
            //}

            // showDataGridView.DataSource = _itemManager.Display();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            try
            {
                Convert.ToInt32(quantityTextBox.Text);
                Convert.ToInt32(priceTextBox.Text);
            }
            catch (FormatException exception)
            {
                MessageBox.Show("invalid input");
                return;
            }
           

            //if (_orderManager.Update(nameTextBox.Text, itemTextBox.Text, Convert.ToInt32(quantityTextBox.Text), Convert.ToInt32(priceTextBox.Text),Convert.ToInt32(idTextBox.Text)))
            //{
            //    MessageBox.Show("Updated");
            //    // showDataGridView.DataSource = _customerManager.Display();
            //}
            //else
            //{
            //    MessageBox.Show("Not Updated");
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OrderUi_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _orderManager.CustomerComboDisplay();
            itemComboBox.DataSource = _orderManager.ItemComboDisplay();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            priceTextBox.Text =Convert.ToString (_orderManager.pricefetch(order));
            
        }

        private void itemComboBox_TextUpdate(object sender, EventArgs e)
        {
            //order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            //priceTextBox.Text = Convert.ToString(_orderManager.pricefetch(order));
        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                priceTextBox.Text = Convert.ToString(Convert.ToInt32(quantityTextBox.Text) * _orderManager.pricefetch(order));
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Enter a quantity");
            }
        }
    }
}
