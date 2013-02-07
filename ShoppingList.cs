using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    class ShoppingList
    {
        private List<Material> content;

        public ShoppingList()
        {
            content = new List<Material>();
        }

        public void AddToList(Material material)
        {
            if (material != null)
            {
                bool add = false;
                for (int i = 0; i < content.Count; i++)
                {
                    if (content[i].Name == material.Name)
                    {
                        content[i].Quantity += material.Quantity;
                        add = true;
                    }
                }
                if(!add)
                    content.Add(material);
            }
        }

        public void RemoveFromList(Material material)
        {
            content.Remove(material);
        }

        public void ClearList()
        {
            content.Clear();
        }

        public List<Material> Content
        {
            get
            {
                return content;
            }
        }
    }
}
