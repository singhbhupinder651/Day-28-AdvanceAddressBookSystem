using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookPractice
{
    internal class CompareContactsByName : IComparer<Contact>
    {
        public int Compare(Contact c1, Contact c2) 
        { 
            string contactOneFullName = c1.FirstName + c1.LastName;
            string contactTwoFullName = c2.FirstName + c2.LastName;
            
            if (contactOneFullName.CompareTo(contactTwoFullName) > 0)
            {
                return 1;
            }
            else if(contactOneFullName.CompareTo(contactTwoFullName) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
    }
}
