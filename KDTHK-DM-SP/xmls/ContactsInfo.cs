using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTHK_DM_SP.xmls
{
    public class ContactsInfo
    {
        public string Staff;
        public string Ext;

        public ContactsInfo() { }

        public ContactsInfo(string staff, string ext)
        {
            Staff = staff;
            Ext = ext;
        }
    }
}
