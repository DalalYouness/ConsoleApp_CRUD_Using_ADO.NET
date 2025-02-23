using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace ContactsDataAccessLayer
{
    public  class clsContactData
    {
      public static bool FindContactsbyID(int ID,ref string FirstName,ref string LastName, ref string Email,
          ref string Phone, ref string Adress, ref DateTime DateOfBirth, ref int CountryID,ref string ImagePath)
      {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"SELECT * FROM Contacts WHERE ContactID = @ContactId";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactId", ID);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IsFound = true;
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];
                        Email = (string)reader["Email"];
                        Phone = (string)reader["Phone"];
                        Adress = (string)reader["Address"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        CountryID = (int)reader["CountryID"];

                        if(reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)reader["ImagePath"];

                        }
                        else
                        {
                            ImagePath = "";
                        }
                    }
                }
                

            }catch (Exception ex)
            {
                IsFound=false;
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



      public static int AddnewContact(string FirstName,string LastName,string Email,string Phone,string Address,DateTime DateOfBirth
          ,int CountryID,string ImagePath)
      {
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"INSERT INTO Contacts (FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath)
                            VALUES
                            (@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath);
                            SELECT SCOPE_IDENTITY();";

             SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if(ImagePath != "") 
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath",System.DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result != null  && int.TryParse(result.ToString(),out int InsertedID)) 
                {
                    ContactID = InsertedID;
                }
                


            }
            catch(Exception ex) 
            {
                
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return ContactID;


      }

     
      public static bool UpdateContactByID(int ID,string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth
          ,int CountryID, string ImagePath)
      {

            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"UPDATE Contacts 
                             SET FirstName = @FirstName,LastName = @LastName,Email = @Email,Phone = @Phone,
                              Address = @Address,DateOfBirth = @DateBirth,CountryID = @CountryId,ImagePath = @ImagePath
                              WHERE ContactID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryId", CountryID);
            command.Parameters.AddWithValue("@ID", ID);

            if(ImagePath == "")
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (AffectedRows > 0);
      }


     public static DataTable getAllContacts()
     {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = "SELECT * FROM Contacts";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dt;

     }


      public static bool DeleteContactByID(int ID)
      {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            string Query = "DELETE FROM Contacts WHERE ContactID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            { 
                connection.Close(); 
            }

            return AffectedRows > 0;
      }

       public static bool IsContactExistByID(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            string Query = "SELECT Found = 1 FROM Contacts WHERE ContactID =@ID";
            SqlCommand command = new SqlCommand (Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
                    
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return IsFound;

        }




    }
}
