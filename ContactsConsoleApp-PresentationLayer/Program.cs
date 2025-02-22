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

         static void UpdateContactByID(int ID)
        {
            clsContact contact = clsContact.Find(ID);

            if (contact != null)
            {
                contact.FirstName = "Mohammed";
                contact.LastName = "Ganine";
                contact.Email = "Gaine@gmail.com";
                contact.Phone = "0631546012";
                contact.Address = "Sidi Maarouf";
                contact.DateOfBirth = new DateTime(2001, 02, 27);
                contact.ImagePath = "C://Image.png";
                contact.CountryID = 1;

                if (contact.Save())
                {
                    Console.WriteLine("Contact Updated Successfuly");
                }
                else
                {
                    Console.WriteLine("Contact Update Fail");
                }
            }
            else
            {
                Console.WriteLine("Contact not Found");
            }
        }

        public static void TestDeleteContactByID(int ID)
        {
           
            
                /* we will delete the record from data base using
                  directly static methode for delete because is not 
                 usable to create an object then we delete it from data 
                 base , the object will stay in the memory 
                */
                if(clsContact.DeleteContactByID(ID))
                {
                    Console.WriteLine("Contact Deleted Sussefully");
                }
                else
                {
                    Console.WriteLine("Contact delet failed");
                }
         
        }
        
        static void Main(string[] args)
        {
            TestDeleteContactByID(14);
            Console.ReadLine();
        }
    }
}
