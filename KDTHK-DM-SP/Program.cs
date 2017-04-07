using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.lists;
using System.Diagnostics;
using System.IO;
using System.Data;
using KDTHK_DM_SP.forms;
using KDTHK_DM_SP.eforms.cm;
using KDTHK_DM_SP.eforms.acc;
using KDTHK_DM_SP.eforms.acc.subforms;
using KDTHK_DM_SP.eforms.adm;

namespace KDTHK_DM_SP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalService.StartupPath = args.Length > 0 ? args[0] : @"\Documents";
            GlobalService.TemporaryFolderList = new List<string>();

            Application.Run(new SplashForm());
        }
    }
}
