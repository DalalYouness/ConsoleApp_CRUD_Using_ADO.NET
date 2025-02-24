using System;
using System.Data;
using DataAccessLayer;


namespace BusinessLayer
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
        public string Code { get; set; }
        public string PhoneCode { get; set; }


        private enMode Mode = enMode.AddNew;

        private clsCountry(int countryID, string countryName,string Code,string PhoneCode)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;
            Mode = enMode.Update;
        }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";
            Mode = enMode.AddNew;
        }

        // updated with success
        public static clsCountry Find(int ID)
        {
            string CountryName = "",Code = "",PhoneCode = "";

            if (clsCountryData.FindCountryByID(ID, ref CountryName,ref Code,ref PhoneCode))

               return new clsCountry(ID, CountryName,Code, PhoneCode);

            else
                return null;
        }

        public static clsCountry FindByName(string Name)
        {
            int CountryID = 0;
            string Code = "", PhoneCode = "";

            if (clsCountryData.FindCoutryByNameDAL(ref CountryID,ref Code,ref PhoneCode, Name))
            {
                return new clsCountry(CountryID, Name,Code, PhoneCode);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNew()
        {
            this.CountryID = clsCountryData.AddNewCountry(this.CountryName,this.Code,this.PhoneCode);

            return this.CountryID != -1;
        }

        private bool _UpdatebyID()
        {
            return clsCountryData.UpdateCountry(this.CountryID, this.CountryName,this.Code,this.PhoneCode);
        }


        public static bool DeleteByID(int ID)
        {
            return clsCountryData.DeleteCountry(ID);

        }



        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountrisDataAccees();
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

        public static bool IsCountryExistByID(int ID)
        {
            return clsCountryData.IsCountryExistByID(ID);
        }
        public static bool IsCountryExistByName(string Name)
        {
            return clsCountryData.IsCountryExistByNameDAL(Name);
        }


    }
}
