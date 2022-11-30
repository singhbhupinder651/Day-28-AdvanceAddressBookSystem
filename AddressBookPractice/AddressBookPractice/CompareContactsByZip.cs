using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookPractice
{
    internal class CompareContactsByZip : IComparer<Contact>
    {
        public int Compare(Contact c1, Contact c2)
        {
            if (c1.Zip.CompareTo(c2.Zip) > 0)
            {
                return 1;
            }
            else if (c1.Zip.CompareTo(c2.Zip) < 0)
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
