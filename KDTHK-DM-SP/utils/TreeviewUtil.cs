using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class TreeviewUtil
    {
        private class NodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode node1 = (TreeNode)x;
                TreeNode node2 = (TreeNode)y;

                if (node1.Level == 1)
                    return string.Compare(node1.Text, node2.Text);
                else
                    return node1.Index.CompareTo(node2.Index);
            }
        }

        public static void PrintNodeRecursive(TreeNode treenode)
        {
            if (treenode.FullPath != "Documents")
                treenode.Collapse();

            foreach (TreeNode tn in treenode.Nodes)
                PrintNodeRecursive(tn);
        }

        public static void CallRecursive(TreeView treeview)
        {
            TreeNodeCollection nodes = treeview.Nodes;
            foreach (TreeNode n in nodes)
                PrintNodeRecursive(n);
        }

        public static void CreateTreeView(TreeNodeCollection nodeList, string path)
        {
            TreeNode node = null;
            string folder = string.Empty;

            int p = path.IndexOf(@"\");

            if (p == -1)
            {
                folder = path;
                path = "";
            }
            else
            {
                folder = path.Substring(0, p);
                path = path.Substring(p + 1, path.Length - (p + 1));
            }

            node = null;

            foreach (TreeNode item in nodeList)
            {
                if (item.Text == folder)
                    node = item;
            }

            if (node == null)
            {
                node = new TreeNode(folder);
                nodeList.Add(node);
            }

            if (path != "")
                CreateTreeView(node.Nodes, path);
        }

        public static void LoadPersonalFolder(TreeView tv, string person)
        {
            tv.Nodes.Clear();

            LoadRootFolder(tv, person);
            LoadFolder(tv, person);

            tv.ExpandAll();

            CallRecursive(tv);

            //if (tv.TreeViewNodeSorter == null)
               //tv.TreeViewNodeSorter = new NodeSorter();

            TreeNode result = tv.Nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text == "Documents");
            int index = result.Index;
        }

        public static void LoadFolder(TreeView tv, string person)
        {
            List<string> dataList = new List<string>();

            string query = "select r_vpath from " + GlobalService.DbTable;

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string vpath = GlobalService.Reader.GetString(0).Trim();
                    if (!dataList.Contains(vpath))
                        dataList.Add(vpath);
                }
            }

            foreach (string item in GlobalService.TemporaryFolderList)
                dataList.Add(item);

            dataList = dataList.Distinct().ToList();

            foreach (string vpath in dataList)
                CreateTreeView(tv.Nodes, vpath.Substring(1));

            tv.Sort();
        }

        public static void LoadRootFolder(TreeView tv, string person)
        {
            string query = string.Format("select fd_name from TB_DIVISION_FOLDER where fd_staff = N'{0}'", person);
            string division = DataService.GetInstance().ExecuteScalar(query).ToString();

            //tv.Nodes.Add("Documents");
            //tv.Nodes.Add(division);
            //tv.Nodes.Add("Common");

            List<string> nodeList = new List<string>();
            nodeList.Add("Documents");
            nodeList.Add(division);
            nodeList.Add("Common");

            nodeList = nodeList.OrderByDescending(x => x).ToList();

            foreach (string node in nodeList)
                tv.Nodes.Add(node);
        }
    }
}
