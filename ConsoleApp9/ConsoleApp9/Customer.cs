using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Customer
    {
        private string name;
        private string email;
        public Address address;

        public string Name
        {
            get
            { return name; }
            set
            {
                name = value;
            }
        }

        public string Email
        {
            get
            { return email; }
            set
            {
                email = value;
            }
        }

        public Customer(string name = "", string email = "example@yahoo.ru", string street="", string city="", string code="")
        {
            Name = name;
            Email = email;
            address = new Address(street, city, code);
        }
    }
    struct Address
    {
        private string Street;
        private string City;
        private string ZipCode;

        public Address(string street = "", string city = "", string zipcode = "0")
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
        }
        public override string ToString()
        {
            return $"{City}, {Street}, {ZipCode}";
        }
    }
}