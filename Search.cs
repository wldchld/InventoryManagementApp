using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagement
{
    class Search
    {
       private List<string> searchContent;

        public Search()
        {
            searchContent = new List<string>();
        }


        public List<string> SearchRecipes(string input)
        {
            
            SqlConnection connection = new SqlConnection("...");
            connection.Open(); searchContent.Clear();

            string query = "SELECT * FROM X WHERE NAME = '" + input + "'";

            SqlCommand sqlquery = new SqlCommand(query, connection);

            SqlDataReader reader = sqlquery.ExecuteReader();

           DataTable matchedContent = new DataTable();

           matchedContent.Load(reader);

            for (int i = 0; i < 5; i++)
            {
                String matchedContentText = string.Empty;
                foreach (DataColumn column in matchedContent.Columns)
                {
                    matchedContentText += matchedContent.Rows[i][column.ColumnName] + " - ";
                    searchContent.Add(matchedContentText);
                }
            }

            connection.Close();
            
            return searchContent;
        }

        public List<string> SearchInventory(string input)
        {
        
            return searchContent;
        }

        public List<string> SearchContent
        {
            get
            {
                return SearchContent;
            }
        }
    }
}
