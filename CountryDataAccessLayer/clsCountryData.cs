using System;
using System.Data;
using System.Data.SqlClient;
using ContactsDataAccessLayer;

namespace CountryDataAccessLayer
{

    
    public class clsCountryData
    {
        public static bool FindCountryByID(int ID,ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"SELECT * FROM Countries WHERE CountryID = @CountryId";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryId", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    if (reader["CountryName"] == DBNull.Value)
                    {
                        CountryName = "";

                    }
                    else
                    {
                        CountryName = (string)reader["CountryName"];
                    }
                }
                

                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally {

                connection.Close(); 
            }

            return IsFound;
        }

    }
}
