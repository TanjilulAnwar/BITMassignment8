using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.Repository
{
    class OrderRepository
    {
        string Server = @"DESKTOP-R0RMATH\SQLEXPRESS";
        public bool Add(Order order)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //int totalPrice = quantity * price;
                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Orders(CustomerId,ItemId,Quantity,TotalPrice) VALUES ('"+order.CustomerId+"','"+order.ItemId+"',"+order.Quantity+","+order.TotalPrice+")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //if (!isNameExists(nameTextBox.Text))
                //{
                //    //Insert
                //    int isExecuted = sqlCommand.ExecuteNonQuery();
                //    if (isExecuted > 0)
                //    {
                //        isAdded = true;
                //    }

                //}
                //else
                //{
                //    MessageBox.Show(nameTextBox.Text + "Already Exists!");
                //}


                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }

            return isAdded;
        }

        public bool IsNameExists(string name)
        {
            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Orders WHERE CustomerName='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return exists;
        }




        public bool Update(string customerName, string itemName, int quantity, int price,int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                int totalPrice = quantity * price;
                string commandString = @"Update orders set CustomerName = '"+customerName+"',ItemName= '"+itemName+"',Quantity="+quantity+",TotalPrice="+totalPrice+"  WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return false;
        }


        public bool Delete(int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //DELETE FROM Items WHERE ID = 3
                string commandString = @"DELETE FROM Orders WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Delete
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return false;
        }










        public DataTable Display()
        {

            //Connection
            string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"select o.Id,  c.Name AS Customer , i.Name ,Quantity,i.Price 
FROM Orders AS o
LEFT JOIN Customers AS c ON c.Id = o.CustomerId
LEFT JOIN Items AS i ON i.Id = o.ItemId
";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //  //  MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();
            return dataTable;


        }






        public DataTable Search(string name)
        {


            //Connection
            string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Orders WHERE CustomerName='" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //   // MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();
            return dataTable;
        }


        public int pricefetch(Order order)
        {
            int price;
            //Connection
            string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Price FROM Items WHERE ID=" +order.ItemId+ "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            price =Convert.ToInt32( sqlCommand.ExecuteScalar());
            sqlConnection.Close();
            return price;

        }


        public DataTable CustomerComboDisplay()
        {

            //Connection
            string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Id,Name FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //  //  MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();
            return dataTable;


        }

        public DataTable ItemComboDisplay()
        {

            //Connection
            string connectionString = @"Server=" + Server + "; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT ID,Name FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //  //  MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();
            return dataTable;


        }


    }
}
