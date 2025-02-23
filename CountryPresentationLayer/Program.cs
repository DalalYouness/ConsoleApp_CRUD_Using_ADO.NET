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

        public static void UpdateCountryByID(int ID)
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

          if(clsCountry.IsCountryExist(ID))
          {
            Console.WriteLine("Yes Country is exist");
          }
          else
          {
            Console.WriteLine("No, Country is not");

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

        public static void DeleteCountryByID(int ID)
        {
           if( clsCountry.IsCountryExist(ID))
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
        static void Main(string[] args)
        {
            //TestFindByID(7);
            //TestAddNewCountry();
            //TestIsCountryExistByID(9);
            DeleteCountryByID(7);
            //UpdateCountryByID(9);

            Console.ReadKey();
        }
    }

