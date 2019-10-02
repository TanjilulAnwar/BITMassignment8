using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;
namespace MyWindowsFormsApp.BLL
{
    class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        
        public bool Add(Order order)
        {
            return _orderRepository.Add(order);
        }

        public bool IsNameExists(string name)
        {
            return _orderRepository.IsNameExists(name);
        }

        public DataTable Display()
        {
            return _orderRepository.Display();
        }

    
        public DataTable Search(string name)
        {
            return _orderRepository.Search(name);
        }

        public int pricefetch(Order order)
        {
            return _orderRepository.pricefetch(order);
        }
        public bool Update(string customerName, string itemName, int quantity, int price, int id)
        {
            return _orderRepository.Update(customerName, itemName, quantity, price, id);
        }

        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public DataTable CustomerComboDisplay()
        {
            return _orderRepository.CustomerComboDisplay();
        }

        public DataTable ItemComboDisplay()
        {
            return _orderRepository.ItemComboDisplay();
        }

    }

}
