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



        public static int AddNewAddNewCountry(string CountryName) {

            int CountryID = -1;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"INSERT INTO Countries
                             VALUES
                             (@CountryName);
                             SELECT SCOPE_IDENTITY()";
                             
            SqlCommand command = new SqlCommand(Query, connection);

            if(CountryName == "")
                command.Parameters.AddWithValue("@CountryName", System.DBNull.Value);
            else
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open ();
                object ReturnedValue = command.ExecuteScalar();

                if(ReturnedValue != null && int.TryParse(ReturnedValue.ToString(), out int ID))
                {
                    CountryID = ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return CountryID;
        
        
        
        }

    }
}
