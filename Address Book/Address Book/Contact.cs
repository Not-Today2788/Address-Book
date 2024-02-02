using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    internal class Contact
    {
        private string First_Name;
        private string Last_Name;
        private string Address;
        private string City;
        private string State;
        private int ZipCode;
        private long PhoneNumber;
        private string Email;
        public string get_firstname()
        {
            return this.First_Name;
        }
        public void set_firstname(string First)
        {
            this.First_Name = First;
        }
        public string get_lastname()
        {
            return this.Last_Name;
        }
        public void set_lastname(string Last)
        {
            this.Last_Name = Last;
        }
        public string get_address()
        {
            return this.Address;
        }
        public void set_address(string Address)
        {
            this.Address = Address;
        }
        public string get_City()
        {
            return this.City;
        }
        public void set_city(string City)
        {
            this.City = City;
        }
        public string get_State()
        {
            return this.State;
        }
        public void set_state(string State)
        {
            this.State = State;
        }
        public int get_ZipCode()
        {
            return this.ZipCode;
        }
        public void set_zipcode(int ZipCode)
        {
            this.ZipCode = ZipCode;
        }
        public long get_PhoneNumber()
        {
            return this.PhoneNumber;
        }
        public void set_phonenumber(long PhoneNumber)
        {
            this.PhoneNumber = PhoneNumber;
        }
        public string get_Email()
        {
            return this.Email;
        }
        public void set_email(string Email)
        {
            this.Email = Email;
        }
    }
}
