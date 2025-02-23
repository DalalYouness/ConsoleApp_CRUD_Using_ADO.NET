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


        public static void TestAddNewCountry()
        {
           clsCountry country = new clsCountry();
           country.CountryName = "Palestine";

           if(country.Save())
                Console.WriteLine("Country Added Succesfully");
           else
                Console.WriteLine("Country Add Failed");
    }
        static void Main(string[] args)
        {
             //TestFindByID(7);
             TestAddNewCountry();
             Console.ReadKey();
        }
    }

