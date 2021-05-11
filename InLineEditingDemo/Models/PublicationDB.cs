using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InLineEditingDemo.Models
{
    public class PublicationDB
    {
        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        //Return list of all Employees  
        public List<PublicationType> ListAll()
        {
            List<PublicationType> lst = new List<PublicationType>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdatePublicationType", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Get");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new PublicationType
                    {
                        ID = Convert.ToInt32(rdr["ID"]),
                        PUB_TYPE = rdr["PUB_TYPE"].ToString(),
                        PUB_NAME = rdr["PUB_NAME"].ToString(),
                        SIZE = Convert.ToDecimal(rdr["SIZE"].ToString()),
                        RATE = Convert.ToDecimal(rdr["RATE"].ToString()),
                    });
                }
                return lst;
            }
        }

        //Method for Adding an Employee  
        public int Add(PublicationType emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdatePublicationType", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.ID);
                com.Parameters.AddWithValue("@PubType", emp.PUB_TYPE);
                com.Parameters.AddWithValue("@PubName", emp.PUB_NAME);
                com.Parameters.AddWithValue("@Size", emp.SIZE);
                com.Parameters.AddWithValue("@Rate", emp.RATE);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();

            }
            return i;
        }

        //Method for Updating Employee record  
        public int Update(PublicationType emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdatePublicationType", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.ID);
                com.Parameters.AddWithValue("@PubType", emp.PUB_TYPE);
                com.Parameters.AddWithValue("@PubName", emp.PUB_NAME);
                com.Parameters.AddWithValue("@Size", emp.SIZE);
                com.Parameters.AddWithValue("@Rate", emp.RATE);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee  
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdatePublicationType", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                com.Parameters.AddWithValue("@Action", "Delete");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}