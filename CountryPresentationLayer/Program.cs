using System;
using System.Data;
using CountryBusinessLayer;


    public class Program
    {
        public static void TestFindByID(int ID)
        {
          clsCountry country = clsCountry.Find(ID);
          
           
           if(country != null) 
           {

            Console.WriteLine($"CountryID   : {country.CountryID}");
            Console.WriteLine($"CountryName : {country.CountryName}");


           }
           else
           {
             Console.WriteLine("Country Doesn't Exist");
           }

        }

        public static void TestUpdateCountryByID(int ID)
        {
            clsCountry country = clsCountry.Find(ID);
            if(country != null )
            {
                country.CountryName = "Mexico";

                if(country.Save())
                {

                     Console.WriteLine("Country Updated Successfuly");
                     
                }
                else
                {
                    Console.WriteLine("Country Update Failed");

                }
            }
            else
            {
                Console.WriteLine($"Country Not Found");
            }

        }

        public static void TestIsCountryExistByID(int ID)
        {

          if(clsCountry.IsCountryExistByID(ID))
          {
            Console.WriteLine("Yes Country  exists");
          }
          else
          {
            Console.WriteLine("No, Country doesn't exist");

          }
        }
        public static void TestAddNewCountry()
        {
           clsCountry country = new clsCountry();
           country.CountryName = "Palestine";

           if(country.Save())
                Console.WriteLine("Country Added Succesfully");
           else
                Console.WriteLine("Country Add Failed");
        }

        public static void TestDeleteCountryByID(int ID)
        {
           if( clsCountry.IsCountryExistByID(ID))
           {
              if(clsCountry.DeleteByID(ID))
              {

                Console.WriteLine("Country Deleted Succesfuly");

              }
              else
              {

                Console.WriteLine("Country Delete Failed");
              }

           }
           else
           {
            Console.WriteLine("Country Not Found");

           }

        }


        public static void TestGetAllCountries()
        {
          DataTable datatable = clsCountry.GetAllCountries();

            if(datatable != null)
            {
               foreach (DataRow row in datatable.Rows)
               {
                   Console.WriteLine($"CountryID =  {row["CountryID"]} : CountryName = {row["CountryName"]}");

               }
            }
            else
            {
               Console.WriteLine("There is No Countries");
            }
        }

        public static void TestFindCountryByName(string CountryName)
        {
           clsCountry country = clsCountry.FindByName(CountryName);
          if(country != null )
          {
            Console.WriteLine($"CountryID   : {country.CountryID}");
            Console.WriteLine($"CountryName : {country.CountryName}");
          }
          else
          {
            Console.WriteLine("Country not found");
          }

        }

        public static void TestIsCountryExistByName(string Name)
        {
           if(clsCountry.IsCountryExistByName(Name))
           {
              Console.WriteLine(@"Yes Country Exists");

           }
           else
           {
              Console.WriteLine(@"No Country doesn't exist");

           }

        }
        static void Main(string[] args)
        {
           TestIsCountryExistByName("Canada");

            Console.ReadKey();
        }
    }

