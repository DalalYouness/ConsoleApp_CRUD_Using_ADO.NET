using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using CountryDataAccessLayer;

namespace CountryBusinessLayer
{
    public class clsCountry
    {
        public enum enMode : byte
        {
           AddNew = 1,
           Update = 2
        }
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private enMode Mode = enMode.AddNew;
        private clsCountry(int countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
            Mode = enMode.Update;
        }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
            Mode = enMode.AddNew;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";

            if (clsCountryData.FindCountryByID(ID, ref CountryName))
               return new clsCountry(ID, CountryName);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.CountryID = clsCountryData.AddNewAddNewCountry(this.CountryName);

            return this.CountryID != -1;
        }

        private bool _UpdatebyID()
        {
            return clsCountryData.UpdateCountry(this.CountryID, this.CountryName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                {
                   if (_AddNew())
                   {
                      Mode = enMode.Update;
                      return true;
                   }
                           
                   else return false;


                }
                case enMode.Update: 
                    return _UpdatebyID();

            }

            return false;

            
                
        }

        public static bool IsCountryExist(int ID)
        {
            return clsCountryData.IsCountryExistByID(ID);
        }


    }
}
