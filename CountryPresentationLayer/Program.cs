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
        static void Main(string[] args)
        {
             TestFindByID(7);
             Console.ReadKey();
        }
    }

