using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagement
{
    class DatabaseManager
    {
        private SQLiteDatabase db;

        public DatabaseManager()
        {
            db = new SQLiteDatabase();
        }

        public void addNewMaterial(String name, float quantity, InventoryManagement.Material.MeasureType mType, String group)
        {
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("MaterialName", name);
            data.Add("Quantity", quantity.ToString());
            data.Add("MeasureType", ((int) mType).ToString());
            data.Add("MaterialType", "");
            try
            {
                db.Insert("Material", data);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }
        }

        public void addNewGroup(String name)
        {
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("GroupName", name);
            try
            {
                db.Insert("Material", data);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }
        }
    }
}
