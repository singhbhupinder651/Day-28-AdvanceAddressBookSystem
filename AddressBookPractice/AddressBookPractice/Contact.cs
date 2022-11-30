using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookPractice
{
    public class Contact
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override bool Equals(object? obj)
        {
            Contact incomingContact = (Contact)obj;

            if (incomingContact.FirstName == this.FirstName && incomingContact.LastName == this.LastName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string personEntry = "First Name: " + this.FirstName + "\nLast Name: " + this.LastName +
                "\nAddress: " + this.Address + "\nCity: " + this.City + "\nState: " + this.State +
                "\nZip: " + this.Zip + "\nPhone number: " + this.PhoneNumber + "\nEmail: " + this.Email;

            return personEntry;
        }

    }
}
