using System;
using System.Data;
using ContactsBusinessLayer;


namespace ContactsConsoleApp_PresentationLayer
{
    internal class Program
    {
        public static void TestFindByID(int ID)
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
            contact.FirstName = "Youness";
            contact.LastName = "Dalal";
            contact.Email = "Younessdalal@gmail.com";
            contact.Phone = "0631546012";
            contact.Address = "Sidi Maarouf";
            contact.DateOfBirth = new DateTime(1998, 02, 27);
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
            if(clsContact.DeleteContact(ID))
            {
                Console.WriteLine("Contact Deleted Successufuly");
            }
            else
            {
                Console.WriteLine("Delete Contact Dailed");
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
        static void Main(string[] args)
        {
            getAllContacts();
            Console.ReadLine();
        }
    }
}
