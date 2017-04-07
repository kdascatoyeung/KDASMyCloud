using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTHK_DM_SP.lists
{
    public class DictionaryUtil
    {
        public string Filename { get; set; }

        public string Keyword { get; set; }

        public string Modified { get; set; }

        public string Access { get; set; }

        public string Owner { get; set; }

        public string Shared { get; set; }

        public string Path { get; set; }

        public string Vpath { get; set; }

        public int Count { get; set; }

        public string Favorite { get; set; }

        public string Checked { get; set; }

        public string Disc { get; set; }

        public DictionaryUtil(string filename, string keyword, string modified, string access, string owner, string shared, string path
            , string vpath, int count, string favorite, string check, string disc)
        {
            Filename = filename;
            Keyword = keyword;
            Modified = modified;
            Access = access;
            Owner = owner;
            Shared = shared;
            Path = path;
            Vpath = vpath;
            Count = count;
            Favorite = favorite;
            Checked = check;
            Disc = disc;
        }
    }
}
