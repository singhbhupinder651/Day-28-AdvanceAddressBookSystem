using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookPractice
{
    internal class CompareContactsByState : IComparer<Contact>
    {
        public int Compare(Contact c1, Contact c2)
        {
            if (c1.State.CompareTo(c2.State) > 0)
            {
                return 1;
            }
            else if (c1.State.CompareTo(c2.State) < 0)
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
