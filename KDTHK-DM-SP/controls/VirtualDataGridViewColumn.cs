using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDTHK_DM_SP.controls
{
    class VirtualDataGridViewColumn : DataGridViewColumn
    {
        private DataGridViewColumn originalColumn;

        public VirtualDataGridViewColumn(DataGridViewColumn originalColumn)
            : base()
        {
            this.originalColumn = originalColumn;
        }

        public DataGridViewColumn OriginalColumn
        {
            get { return this.originalColumn; }
        }
    }
}
