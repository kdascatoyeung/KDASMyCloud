using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTHK_DM_SP.lists
{
    public class FileList
    {
        private string fileNameValue;
        private string modifiedValue;
        private string ownerValue;
        private int sharedValue;
        private string pathValue;
        private string vpathValue;
        private string countValue;
        private string favoriteValue;

        public FileList() { }

        public FileList(string fileName, string modified, string owner, int shared, string path, string vpath,
            string count, string favorite)
        {
            fileNameValue = fileName;
            modifiedValue = modified;
            ownerValue = owner;
            sharedValue = shared;
            pathValue = path;
            vpathValue = vpath;
            countValue = count;
            favoriteValue = favorite;
        }

        public string FileName
        {
            get { return fileNameValue; }
            set { fileNameValue = value; }
        }

        public string Modified
        {
            get { return modifiedValue; }
            set { modifiedValue = value; }
        }

        public string Owner
        {
            get { return ownerValue; }
            set { ownerValue = value; }
        }

        public int Shared
        {
            get { return sharedValue; }
            set { sharedValue = value; }
        }

        public string Path
        {
            get { return pathValue; }
            set { pathValue = value; }
        }

        public string Vpath
        {
            get { return vpathValue; }
            set { vpathValue = value; }
        }

        public string Count
        {
            get { return countValue; }
            set { countValue = value; }
        }

        public string Favorite
        {
            get { return favoriteValue; }
            set { favoriteValue = value; }
        }
    }
}
