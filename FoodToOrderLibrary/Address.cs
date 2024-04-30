using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{

    public class Address
    {
        
        private int id;

        public int Id
        {
            get { return id; }
        }
        private string houseNo;

        public string HouseNo
        {
            get { return houseNo; }
            set { houseNo = value; }
        }

        private string street;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        private string area;

        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private int pincode;

        public int Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        public Address() { }   
        public Address( string houseNo, string street, string area, string city, string state, string country, int pincode, int userId)
        {
            
            HouseNo = houseNo;
            Street = street;
            Area = area;
            City = city;
            State = state;
            Country = country;
            Pincode = pincode;
            UserId = userId;
        }
    }
}
