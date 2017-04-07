using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.xmls;
using System.IO;
using System.Xml.Serialization;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using CustomUtil.utils.export;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.utils
{
    public class ContactUtil
    {
        static List<ContactsInfo> _contacts = new List<ContactsInfo>();

        public static FileInfo ContactFile
        {
            get { return new FileInfo(Path.Combine(Application.StartupPath, "contacts.xml")); }
        }

        public static void LoadContacts(DataGridView dgv, string search)
        {
            if (ContactFile.Exists)
            {
                dgv.Rows.Clear();

                List<ContactsInfo> lst = new List<ContactsInfo>();

                XmlSerializer xml = new XmlSerializer(lst.GetType());

                using (Stream s = ContactFile.OpenRead())
                    lst = xml.Deserialize(s) as List<ContactsInfo>;

                lst = lst.Where(x => x.Staff.Contains(search) || x.Ext.Contains(search)).ToList();

                _contacts = new List<ContactsInfo>();

                foreach (ContactsInfo info in lst)
                    _contacts.Add(new ContactsInfo(info.Staff, info.Ext));

                PlaceContacts(dgv);
            }
        }

        public static void PlaceContacts(DataGridView dgv)
        {
            dgv.Rows.Clear();

            foreach (ContactsInfo info in _contacts)
            {
                string staff = info.Staff;
                string ext = info.Ext;

                dgv.Rows.Add(staff, ext);
                dgv.Sort(dgv.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        public static void SaveContacts(List<ContactsInfo> clst)
        {
            List<ContactsInfo> lst = new List<ContactsInfo>();

            foreach (ContactsInfo info in clst)
                lst.Add(new ContactsInfo(info.Staff, info.Ext));

            XmlSerializer xmls = new XmlSerializer(lst.GetType());

            if (ContactFile.Exists)
                ContactFile.Delete();

            using (Stream s = ContactFile.OpenWrite())
            {
                xmls.Serialize(s, lst);
                s.Close();
            }
        }

        public static List<ContactList> ContactList()
        {
            List<ContactList> list = new List<ContactList>();

            string query = "select c_staff, c_company, c_email from TB_CONTACTS";

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string staff = GlobalService.Reader.GetString(0);
                    string company = GlobalService.Reader.GetString(1);
                    string email = GlobalService.Reader.GetString(2);

                    list.Add(new ContactList { Staff = staff, Company = company, Email = email });
                }
            }

            return list;
        }

        public static void DisplayGlobalAddressList()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Company", typeof(string));
            table.Columns.Add("Address", typeof(string));

            Outlook.Application outlook = new Outlook.Application();

            Outlook.AddressList gal = outlook.Session.GetGlobalAddressList();

            if (gal != null)
            {
                for (int i = 1; i < gal.AddressEntries.Count - 1; i++)
                {
                    try
                    {
                        Outlook.AddressEntry addressEntry = gal.AddressEntries[i];

                        if (addressEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry || addressEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
                        {
                            Outlook.ExchangeUser exUser = addressEntry.GetExchangeUser();
                            Debug.WriteLine(exUser.Name + "    " + exUser.CompanyName);
                            table.Rows.Add(exUser.Name, exUser.CompanyName, exUser.PrimarySmtpAddress);
                        }

                        if (addressEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeDistributionListAddressEntry)
                        {
                            Outlook.ExchangeDistributionList exList = addressEntry.GetExchangeDistributionList();
                            Debug.WriteLine(exList.Name + "   " + exList.PrimarySmtpAddress);
                            table.Rows.Add(exList.Name, "", "");
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            ExportCsvUtil.ExportCsv(table, "", "");
        }
    }
}
