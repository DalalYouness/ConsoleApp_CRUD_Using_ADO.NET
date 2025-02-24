using System;
using System.Data;
using BusinessLayer;


namespace PresentationLayer
{
    internal class Program
    {
        public static void TestFindCountactByID(int ID)
        {
            clsContact contact = clsContact.Find(ID);

            if (contact != null)
            {
                Console.WriteLine(contact.ContactID);
                Console.WriteLine(contact.FirstName);
                Console.WriteLine(contact.LastName);
                Console.WriteLine(contact.Email);
                Console.WriteLine(contact.Phone);
                Console.WriteLine(contact.Address);
                Console.WriteLine(contact.DateOfBirth);
                Console.WriteLine(contact.CountryID);
                Console.WriteLine(contact.ImagePath);
            }
            else
            {
                Console.WriteLine($"Contact with ID:[{ID}] not found");
            }
        }

        static void TestAddNewContact()
        {
            clsContact contact = new clsContact();
            contact.FirstName = "Mohammed";
            contact.LastName = "Fares";
            contact.Email = "Mohammed@gmail.com";
            contact.Phone = "06589632";
            contact.Address = "Bournazil";
            contact.DateOfBirth = new DateTime(1994, 02, 27);
            contact.ImagePath = "C://Image.png";
            contact.CountryID = 1;
           
            if(contact.Save())
            {
                Console.WriteLine("Contact Added Successfuly");
            }
            else
            {
                Console.WriteLine("Add contact Failed");
            }


        }

        static void TestUpdateContactByID(int ID)
        {
            clsContact contact = clsContact.Find(ID);

            if(contact!=null)
            {
                //update whatever info you want
                contact.FirstName = "Abdelkader";
                contact.LastName = "Dalal";
                contact.Email = "Abdo@Gmail.com";
                contact.Phone = "06457896";
                contact.Address = "Casa n4523";
                contact.DateOfBirth = new DateTime(1999,02,12);
                contact.CountryID = 2;
                contact.ImagePath = "";

                if (contact.Save())
                {
                    Console.WriteLine("Contact Updated with success");
                }
                else
                {
                    Console.WriteLine("Contact Update Failed");
                }

            }
            else
            {
                Console.WriteLine("Contact not Found");
            }
        }

        static void DeleteContactByID(int ID)
        {

            if (clsContact.IsContactExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Deleted Successufuly");
                }
                else
                {
                    Console.WriteLine("Failed To delete Contact");
                }
            }
            else
            {
                Console.WriteLine("No Contact isn't there");
            }

            

        }
        
        static void getAllContacts()
        {
            DataTable dataTabe = clsContact.GetAllContacts();

            Console.WriteLine("==============================");
            Console.WriteLine("\t   Contacts Info");
            Console.WriteLine("==============================");
            if (dataTabe!=null)
            {

                foreach(DataRow row in dataTabe.Rows)
                {
                    Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]}, {row["LastName"]}");
                }
            }
        }


        public static void IsContactExistByID(int ID)
        {
            if (clsContact.IsContactExist(ID))
                Console.WriteLine("Yes Contact is there");
            else
                Console.WriteLine("No Contact isn't there");

        }


        // Test Country Methodes


        // Modification dans la methode FindByID
        //validate
        public static void TestFindCountryByID(int ID)
        {
            clsCountry country = clsCountry.Find(ID);


            if (country != null)
            {

                Console.WriteLine($"CountryID   : {country.CountryID}");
                Console.WriteLine($"CountryName : {country.CountryName}");
                Console.WriteLine($"CountryCode : {country.Code}");
                Console.WriteLine($"PhoneCode   : {country.PhoneCode}");

            }
            else
            {
                Console.WriteLine("Country Doesn't Exist");
            }

        }

        // validate
        public static void TestUpdateCountryByID(int ID)
        {
            clsCountry country = clsCountry.Find(ID);
            if (country != null)
            {
                //update whatever info you want
                country.CountryName = "Mexico";
                country.Code = "458";
                country.PhoneCode = "745";

                if (country.Save())
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

        // validate
        public static void TestIsCountryExistByID(int ID)
        {

            if (clsCountry.IsCountryExistByID(ID))
            {
                Console.WriteLine("Yes Country  exists");
            }
            else
            {
                Console.WriteLine("No, Country doesn't exist");

            }
        }

        //validate
        public static void TestAddNewCountry()
        {
            clsCountry country = new clsCountry();
            country.CountryName = "Jordan";
            country.Code = "123";
            country.PhoneCode = "890";

             if (country.Save())
                Console.WriteLine("Country Added Succesfully");
            else
                Console.WriteLine("Country Add Failed");
        }

        // in progress
        public static void TestDeleteCountryByID(int ID)
        {
            if (clsCountry.IsCountryExistByID(ID))
            {
                if (clsCountry.DeleteByID(ID))
                {

                    Console.WriteLine("Country Deleted Succesfuly");

                }
                else
                {

                    Console.WriteLine("Faild to delete Country.");
                }

            }
            else
            {
                Console.WriteLine("Faild to delete: The Country with id = " + ID + " is not found");

            }

        }


        //validate
        public static void TestGetAllCountries()
        {
            DataTable datatable = clsCountry.GetAllCountries();

            if (datatable != null)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    Console.WriteLine($"CountryID =  {row["CountryID"]} : CountryName = {row["CountryName"]} : Code = {row["Code"]} : PhoneCode = {row["PhoneCode"]}");

                }
            }
            else
            {
                Console.WriteLine("There is No Countries");
            }
        }

        // validate
        public static void TestFindCountryByName(string CountryName)
        {
            clsCountry country = clsCountry.FindByName(CountryName);

            if (country != null)
            {
                Console.WriteLine($"CountryID   : {country.CountryID}");
                Console.WriteLine($"CountryName : {country.CountryName}");
                Console.WriteLine($"CountryCode : {country.Code}");
                Console.WriteLine($"PhoneCode   : {country.PhoneCode}");

            }
            else
            {
                Console.WriteLine("Country [" + CountryName + "] Is Not found!");
            }

        }

        //validate
        public static void TestIsCountryExistByName(string Name)
        {
            if (clsCountry.IsCountryExistByName(Name))
            {
                Console.WriteLine("Yes Country Exists");

            }
            else
            {
                Console.WriteLine("No Country doesn't exist");

            }

        }
        static void Main(string[] args)
        {
            TestGetAllCountries();
            Console.ReadLine();
        }
    }
}