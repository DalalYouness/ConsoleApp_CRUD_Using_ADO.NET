using System;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    //Entité
    public class clsContact
    {

        public enum enMode
        {
            AddnewMode = 1,
            UdpadeMode = 2
        }
       public enMode Mode = enMode.AddnewMode;
       public int ContactID { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public string Address { get; set; }
       public int CountryID { get; set; }
       public DateTime DateOfBirth { get; set; }
       public string ImagePath { get; set; }
      
        private clsContact(int contactID, string firstName, string lastName, string email,
            string phone, string address, int countryID, DateTime dateOfBirth, string imagePath)
        {
            ContactID = contactID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            CountryID = countryID;
            DateOfBirth = dateOfBirth;
            ImagePath = imagePath;
            Mode = enMode.UdpadeMode;
        }

        public clsContact()
        {
            this.ContactID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.CountryID = 0;
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
           
            Mode = enMode.AddnewMode;
        }

        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", CountryID = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int countryID = 0;

            if(clsContactData.FindContactsbyID(ID,ref FirstName,ref LastName, ref Email, ref Phone, ref Address,ref DateOfBirth,ref countryID,ref ImagePath))
            {
                return new clsContact(ID,FirstName,LastName,Email,Phone,Address, countryID, DateOfBirth,ImagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewContact()
        {
            this.ContactID = clsContactData.AddnewContact(this.FirstName, this.LastName, this.Email,
                this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);
            return (this.ContactID != -1);

        }

       
        private bool _UpdateContact()
        {
            //call DataAccess Layer 
            return clsContactData.UpdateContactByID(this.ContactID, this.FirstName, this.LastName, this.Email,
                this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);
        }


        public static bool DeleteContact(int ID)
        {
            return clsContactData.DeleteContactByID(ID);
        }
        

        public static DataTable GetAllContacts()
        {
            return clsContactData.getAllContacts();
        }


        public static bool IsContactExist(int ID)
        {
            return clsContactData.IsContactExistByID(ID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddnewMode:
                  if (_AddNewContact())
                  {
                        Mode = enMode.UdpadeMode;
                        return true;
                  }     
                  else
                        return false;

                case enMode.UdpadeMode:
                    return _UpdateContact();



            }

            return false;
        }
    }
}
