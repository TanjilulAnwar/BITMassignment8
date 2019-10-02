using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();

        public bool Add(Item item)
        {
            return _itemRepository.Add(item);
        }

        public bool IsNameExists(string name)
        {
            return _itemRepository.IsNameExists(name);
        }

        public bool Delete(Item item)
        {
            return _itemRepository.Delete(item);
        }

        public bool Update(Item item)
        {
            return _itemRepository.Update(item);
        }

        public DataTable Display()
        {
            return _itemRepository.Display();
        }

        public DataTable Search(string name)
        {

            return _itemRepository.Search(name);
        }

        public DataTable ComboDisplay()
        {
            return _itemRepository.ComboDisplay();
        }

    }
}
