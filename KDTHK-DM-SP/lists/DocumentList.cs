using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KDTHK_DM_SP.lists
{
    public class DocumentList
    {
        public Image Icon { get; set; }

        public String Name { get; set; }

        public String Keyword { get; set; }

        public String Modified { get; set; }

        public String Shared { get; set; }

        public String Owner { get; set; }

        public String Read { get; set; }

        public String Type { get; set; }

        public String Path { get; set; }

        public String Vpath { get; set; }

        public Image Favorite { get; set; }

        public Image Status { get; set; }
    }
}
