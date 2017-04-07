using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTHK_DM_SP.xmls
{
    public class AppsInfo
    {
        public string FileName;
        public string FilePath;
        public string Description;
        public string LastAccess;
        //public string ImageBytes;
        public string Category;

        public AppsInfo() { }

        public AppsInfo(string name, string path, string description, string lastaccess, string category)
        {
            FileName = name;
            FilePath = path;
            Description = description;
            LastAccess = lastaccess;
            Category = category;
        }
    }
}
