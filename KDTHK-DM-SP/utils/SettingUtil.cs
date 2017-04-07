using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using KDTHK_DM_SP.xmls;

namespace KDTHK_DM_SP.utils
{
    public class SettingUtil
    {
        static List<SettingInfo> _setting = new List<SettingInfo>();

        static string userfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KDTHK");

        public static FileInfo SettingFile
        {
            get { return new FileInfo(Path.Combine(userfilePath, "setting.xml")); }
        }

        public static string LoadSetting()
        {
            if (SettingFile.Exists)
            {
                List<SettingInfo> lst = new List<SettingInfo>();

                XmlSerializer xml = new XmlSerializer(lst.GetType());

                using (Stream s = SettingFile.OpenRead())
                    lst = xml.Deserialize(s) as List<SettingInfo>;

                foreach (SettingInfo info in lst)
                    _setting.Add(new SettingInfo(info.Extend));

                return _setting[0].Extend;
            }

            return "";
        }

        public static void SaveSetting(string extend)
        {
            List<SettingInfo> lst = new List<SettingInfo>();

            lst.Add(new SettingInfo(extend));

            XmlSerializer xmls = new XmlSerializer(lst.GetType());

            if (SettingFile.Exists)
                SettingFile.Delete();

            using (Stream s = SettingFile.OpenWrite())
            {
                xmls.Serialize(s, lst);
                s.Close();
            }
        }
    }
}
