using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Security.Principal;

namespace Common
{
    public class AdUtil
    {
        public static List<string> domainList = new List<string>(new string[] { "kmhk.local", "kmas.local" });
        public static string getUsernameByUserId(string userId, string domain)
        {
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            SearchResult searchResult = new DirectorySearcher(searchRoot)
            {
                Filter = "(&(objectClass=user)(sAMAccountName=" + userId + "))"
            }.FindOne();
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();
            return directoryEntry.Properties["displayName"].Value.ToString();
        }

        public static string GetEmailByUserId(string userId, string domain)
        {
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            SearchResult searchResult = new DirectorySearcher(searchRoot)
            {
                Filter = "(&(objectClass=user)(sAMAccountName=" + userId + "))"
            }.FindOne();
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();
            return directoryEntry.Properties["mail"].Value.ToString();
        }

        public static string GetEmailByUserId(string userId)
        {
            DirectoryEntry directoryEntry = null;

            foreach (string domain in domainList)
            {
                DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
                SearchResult searchResult = new DirectorySearcher(searchRoot)
                {
                    Filter = "(&(objectClass=user)(sAMAccountName=" + userId + "))"
                }.FindOne();
                if (searchResult != null)
                {
                    directoryEntry = searchResult.GetDirectoryEntry();
                }
            }
            return directoryEntry.Properties["mail"].Value.ToString();
        }

        public static string GetEmailByUsername(string username, string domain)
        {
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            SearchResult searchResult = new DirectorySearcher(searchRoot)
            {
                Filter = "(&(objectClass=user)(displayName=" + username + "))"
            }.FindOne();
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();
            return directoryEntry.Properties["mail"].Value.ToString();
        }

        public static string GetEmailByUsername(string username)
        {
            DirectoryEntry directoryEntry = null;

            foreach (string domain in domainList)
            {
                DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
                SearchResult searchResult = new DirectorySearcher(searchRoot)
                {
                    Filter = "(&(objectClass=user)(displayName=" + username + "))"
                }.FindOne();
                if (searchResult != null)
                {
                    directoryEntry = searchResult.GetDirectoryEntry();
                }
            }
            return directoryEntry.Properties["mail"].Value.ToString();
        }

        public static string GetUserIdByUsername(string username)
        {
            DirectoryEntry directoryEntry = null;

            foreach (string domain in domainList)
            {
                DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
                SearchResult searchResult = new DirectorySearcher(searchRoot)
                {
                    Filter = "(&(objectClass=user)(displayName=" + username + "))"
                }.FindOne();
                if (searchResult != null)
                {
                    directoryEntry = searchResult.GetDirectoryEntry();
                }
            }
            return directoryEntry.Properties["sAMAccountName"].Value.ToString();
        }

        public static string GetUserId()
        {
            string username = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            string str = username.Substring(username.IndexOf('\\') + 1);

            string domain = "";
            if (username.StartsWith("KMHK"))
            {
                domain = "kmhk.local";
            }
            else if (username.StartsWith("KMAS"))
            {
                domain = "kmas.local";
            }
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            SearchResult searchResult = new DirectorySearcher(searchRoot)
            {
                Filter = "(&(objectClass=user)(sAMAccountName=" + str + "))"
            }.FindOne();
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();
            return directoryEntry.Properties["sAMAccountName"].Value.ToString();
        }

        public static string getUsername(string domain)
        {
            string name = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            string str = name.Substring(name.IndexOf('\\') + 1);
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            SearchResult searchResult = new DirectorySearcher(searchRoot)
            {
                Filter = "(&(objectClass=user)(sAMAccountName=" + str + "))"
            }.FindOne();
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();
            return directoryEntry.Properties["displayName"].Value.ToString();
        }

        public static string getAccount()
        {
            string name = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            string domain = "";
            if (name.StartsWith("KMHK"))
            {
                domain = "kmhk.local";
            }
            else if (name.StartsWith("KMAS"))
            {
                domain = "kmas.local";
            }
            string str = name.Substring(name.IndexOf('\\') + 1);
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            SearchResult searchResult = new DirectorySearcher(searchRoot)
            {
                Filter = "(&(objectClass=user)(sAMAccountName=" + str + "))"
            }.FindOne();
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();
            return directoryEntry.Properties["sAMAccountName"].Value.ToString();
        }

        public static string getAccount(string domain)
        {
            string name = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            string str = name.Substring(name.IndexOf('\\') + 1);
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            SearchResult searchResult = new DirectorySearcher(searchRoot)
            {
                Filter = "(&(objectClass=user)(sAMAccountName=" + str + "))"
            }.FindOne();
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();
            return directoryEntry.Properties["sAMAccountName"].Value.ToString();
        }

        public static System.Collections.Generic.List<string> GetUserList(string domain)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domain);
            DirectorySearcher directorySearcher = new DirectorySearcher(searchRoot);
            SearchResultCollection searchResultCollection = directorySearcher.FindAll();
            return result;
        }

        public static bool Authenticate(string domain, string username, string password)
        {
            string text = domain + "\\" + username;
            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + domain, username, password);
            directoryEntry.AuthenticationType = AuthenticationTypes.ServerBind;
            bool result;
            try
            {
                object nativeObject = directoryEntry.NativeObject;
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
