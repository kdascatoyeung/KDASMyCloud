using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using CustomUtil.utils.authentication;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class PermissionUtil
    {
        public static void SetPermission(List<string> sharedList, string filePath)
        {
            try
            {
                FileInfo info = new FileInfo(filePath);

                FileSecurity fs = info.GetAccessControl();

                /* Start of Take Ownership by Cato Yeung 2016/04/10 */
                //SecurityIdentifier cu = WindowsIdentity.GetCurrent().User;
                //fs.SetOwner(cu);
                //File.SetAccessControl(filePath, fs);
                /* End of Take Ownership by Cato Yeung 2016/04/10 */

                fs.SetAccessRuleProtection(true, false);
                fs.AddAccessRule(new FileSystemAccessRule(@"kmhk\itadmin", FileSystemRights.FullControl, AccessControlType.Allow));
                fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), FileSystemRights.FullControl, AccessControlType.Allow));
                
                foreach (string shared in sharedList)
                {
                    string staffId = AdUtil.GetUserIdByUsername(shared.Trim(), "kmhk.local");

                    //Debug.WriteLine(shared + "  " + filePath);
                    //fs.SetAccessRuleProtection(true, false);
                    fs.AddAccessRule(new FileSystemAccessRule(staffId, FileSystemRights.Modify, AccessControlType.Allow));

                    if (UserUtil.IsSpecialUser(shared))
                    //if (shared == "Chow Chi To(周志滔,Sammy)" || shared == "Ling Wai Man(凌慧敏,Velma)" || shared == "Chan Fai Lung(陳輝龍,Onyx)" || shared == "Ng Lau Yu, Lilith (吳柳如)" ||
                    //        shared == "Lee Miu Wah(李苗華)" || shared == "Lee Ming Fung(李銘峯)" || shared == "Ho Kin Hang(何健恒,Ken)" || shared == "Yeung Wai, Gabriel (楊偉)")
                    {
                        string asText = string.Format("select as_userid from TB_USER_AS where as_user = N'{0}'", shared.Trim());
                        string asId = DataService.GetInstance().ExecuteScalar(asText).ToString().Trim();

                        fs.AddAccessRule(new FileSystemAccessRule(asId, FileSystemRights.Modify, AccessControlType.Allow));
                    }
                }

                File.SetAccessControl(filePath, fs);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show("Errors found when setting permission.");
            }
        }

        public static void RemovePermission(List<string> deleteList, string filePath)
        {
            try
            {
                FileInfo info = new FileInfo(filePath);

                string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                FileSecurity fs = info.GetAccessControl();
                AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));

                foreach (string item in deleteList)
                {
                    string staffId = AdUtil.GetUserIdByUsername(item.Trim(), "kmhk.local");

                    foreach (FileSystemAccessRule rule in rules)
                        if (rule.IdentityReference.Value == @"KMHK\" + staffId)
                            fs.RemoveAccessRuleSpecific(rule);

                    /*string tableName = "TB_" + staffId;

                    string text = string.Format("delete from " + tableName + " where r_path = N'{0}'", sPath);

                    string query = "insert into LTB_QUERY ([q_query]) values (@text)";

                    using (SqlCeCommand ceCommand = new SqlCeCommand(query, LocalDataService.GetInstance().Connection))
                    {
                        ceCommand.Parameters.AddWithValue("@text", text);
                        ceCommand.ExecuteNonQuery();
                    }*/
                }

                File.SetAccessControl(filePath, fs);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show("Errors found when deleting permission.");
            }
        }

        public static void SetGlobalPermission(List<string> list, string filePath, string domain)
        {
            try
            {
                FileInfo info = new FileInfo(filePath);

                FileSecurity fs = info.GetAccessControl();

                /* Start of Take Ownership by Cato Yeung 2016/04/10 */
                //SecurityIdentifier cu = WindowsIdentity.GetCurrent().User;
                //fs.SetOwner(cu);
                //File.SetAccessControl(filePath, fs);
                /* End of Take Ownership by Cato Yeung 2016/04/10 */

                fs.SetAccessRuleProtection(true, false);
                fs.AddAccessRule(new FileSystemAccessRule(@"kmhk\itadmin", FileSystemRights.FullControl, AccessControlType.Allow));
                fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), FileSystemRights.FullControl, AccessControlType.Allow));
                
                foreach (string shared in list)
                {
                    try
                    {
                        string staffId = AdUtil.GetUserIdByUsername(shared.Trim(), domain);

                        //fs.SetAccessRuleProtection(true, false);
                        fs.AddAccessRule(new FileSystemAccessRule(staffId, FileSystemRights.Modify, AccessControlType.Allow));
                    }
                    catch
                    {
                        continue;
                    }
                }

                File.SetAccessControl(filePath, fs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show("Errors found when setting permission.");
            }
        }

        public static void RemoveGlobalPermission(List<string> list, string filePath, string domain)
        {
            try
            {
                FileInfo info = new FileInfo(filePath);

                string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                FileSecurity fs = info.GetAccessControl();
                AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));

                foreach (string item in list)
                {
                    string staffId = AdUtil.GetUserIdByUsername(item.Trim(), domain);

                    string prefix = domain == "kmcn.local" ? @"KMCN\"
                        : domain == "kdtvn.local" ? @"KDTVN\" : @"KM\";

                    foreach (FileSystemAccessRule rule in rules)
                        if (rule.IdentityReference.Value == prefix + staffId)
                            fs.RemoveAccessRuleSpecific(rule);

                    //string query = string.Format("delete from S_OUT_SHARE where o_path = N'{0}' and o_from = N'{1}' and o_toid = '{2}'", sPath, GlobalService.User, staffId);
                    //Debug.WriteLine("Query: " + query);
                    //DataServiceMes.GetInstance().ExecuteNonQuery(query);
                }

                File.SetAccessControl(filePath, fs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show("Errors found when deleting permission.");
            }
        }

        public static void SetCnPermission(List<string> list, string filePath)
        {
            try
            {
                FileInfo info = new FileInfo(filePath);

                FileSecurity fs = info.GetAccessControl();

                fs.SetAccessRuleProtection(true, false);
                fs.AddAccessRule(new FileSystemAccessRule(@"kmhk\itadmin", FileSystemRights.FullControl, AccessControlType.Allow));
                fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), FileSystemRights.FullControl, AccessControlType.Allow));

                foreach (string shared in list)
                {
                    string staffId = AdUtil.GetUserIdByUsername(shared.Trim(), "kmcn.local");

                    //fs.SetAccessRuleProtection(true, false);
                    fs.AddAccessRule(new FileSystemAccessRule(staffId, FileSystemRights.Modify, AccessControlType.Allow));
                }

                File.SetAccessControl(filePath, fs);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show("Errors found when setting permission.");
            }
        }

        public static void RemoveCnPermission(List<string> list, string filePath)
        {
            try
            {
                FileInfo info = new FileInfo(filePath);

                string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                FileSecurity fs = info.GetAccessControl();
                AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));

                foreach (string item in list)
                {
                    string staffId = AdUtil.GetUserIdByUsername(item.Trim(), "kmcn.local");

                    foreach (FileSystemAccessRule rule in rules)
                        if (rule.IdentityReference.Value == @"KMCN\" + staffId)
                            fs.RemoveAccessRuleSpecific(rule);

                    //string query = string.Format("delete from S_OUT_SHARE where o_path = N'{0}' and o_from = N'{1}' and o_toid = '{2}'", sPath, GlobalService.User, staffId);
                    //Debug.WriteLine("Query: " + query);
                    //DataServiceMes.GetInstance().ExecuteNonQuery(query);
                }

                File.SetAccessControl(filePath, fs);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show("Errors found when deleting permission.");
            }
        }
    }
}
