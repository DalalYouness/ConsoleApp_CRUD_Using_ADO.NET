using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{

    
    public class clsCountryData
    {
        //updated with success
        public static bool FindCountryByID(int ID,ref string CountryName,ref string Code,ref string PhoneCode)
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

                    if (reader["Code"] == System.DBNull.Value)
                    {
                        Code = "";
                    }
                    else
                    {
                        Code = (string)reader["Code"];
                    }

                    PhoneCode = (reader["PhoneCode"] == System.DBNull.Value) ? "" : (string)reader["PhoneCode"];
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



        public static int AddNewCountry(string CountryName,string Code,string PhoneCode) {

            //this function will return the new contact id if succeeded and -1 if not.
            int CountryID = -1;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"INSERT INTO Countries
                             VALUES
                             (@CountryName,@Code,@PhoneCode);
                             SELECT SCOPE_IDENTITY()";
                             
            SqlCommand command = new SqlCommand(Query, connection);

            if(CountryName == "")
                command.Parameters.AddWithValue("@CountryName", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@CountryName", CountryName);

            if(Code == "")
                command.Parameters.AddWithValue("@Code",System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@Code", Code);

            if (PhoneCode == "")
                command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);



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


        public static bool IsCountryExistByID(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            string Query = @"SELECT Found = 1 FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) 
            {
                IsFound = false;
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return IsFound;
        }


        public static bool UpdateCountry(int ID, string CountryName,string Code,string PhoneCode)
        {
            int AffectedRows = 0;


            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            string Query = @"UPDATE Countries SET CountryName = @Name,Code = @Code,PhoneCode = @PhoneCode WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);

            if(CountryName.Equals(""))
            {
                command.Parameters.AddWithValue("@Name", System.DBNull.Value);
            }
            else
                command.Parameters.AddWithValue("@Name", CountryName);

            if (Code.Equals(""))
            {
                command.Parameters.AddWithValue("@Code", System.DBNull.Value);
            }
            else
                command.Parameters.AddWithValue("@Code", Code);

            if (PhoneCode.Equals(""))
            {
                command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);
            }
            else
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();    
            }

            return AffectedRows > 0;


        }

        public static bool DeleteCountry(int ID) 
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"DELETE FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(Query, connection);


            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("You cannot Delete a Country");
            }
            finally
            {
                connection.Close();
            }

            return AffectedRows > 0;

        }



        //validate
        public static DataTable  GetAllCountrisDataAccees()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"SELECT * FROM Countries order by CountryName desc";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception e)
            {

            }
            finally {
                connection.Close(); 
            }

            return dt;


        }

        public static bool FindCoutryByNameDAL(ref int CountryID,ref string Code,ref string PhoneCode,string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    CountryID = reader.GetInt32(0);
                    if (reader["Code"] == System.DBNull.Value)
                    {
                        Code = "";
                    }
                    else
                    {
                        Code = (string)reader["Code"];
                    }

                    if (reader["PhoneCode"] == System.DBNull.Value)
                    {
                        PhoneCode = "";
                    }
                    else
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }
                }


                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {

                connection.Close();
            }

            return IsFound;
        }

        public static bool IsCountryExistByNameDAL(string Name)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            string Query = @"SELECT Found = 1 FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return IsFound;
        }

    }
}
