using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using SMS.DataContext.Entities;

namespace SMS.Common
{
    public static class Utilities
    {
        public static string Encrypt(string str)
        {
            string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        //public static List<T> ConvertToList<T>(this IEnumerable items)
        //{
        //    // see method above
        //    return items.ConvertTo<T>().ToList();
        //}
        public static IEnumerable<T> ConvertTo<T>(this IEnumerable items)
        {
            return items.Cast<object>().Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }

        public static DataTable ConvertCSVtoDataTable(string strFile, bool isPath = false)
        {
            StreamReader sr = null;
            if (!isPath)
            {
                sr = new StreamReader(FileToMemoryStream(strFile));
            }
            else
            {
                sr = new StreamReader(strFile);
            }
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            for (int i = 0; i < headers.Length; i++)
            {
                dt.Columns.Add(i.ToString());
            }
            //foreach (string header in headers)
            //{
            //    if(!dt.Columns.Contains(header))
            //    dt.Columns.Add(header);
            //}
            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static MemoryStream FileToMemoryStream(string file)
        {
            byte[] bytes = Convert.FromBase64String(file);
            return new MemoryStream(bytes);
        }
        
        //public static int GetInterfaceIdByName(string interfaceName)
        //{
        //    return Interfaces.Where(i => i.InterfaceName.RemoveAllWhiteSpaces().ToLower()
        //    .Contains(interfaceName.ToLower()))
        //    .Select(i => i.InterfaceID).LastOrDefault();
        //}
        public static List<Interface> Interfaces
        {
            get
            {
                if (HttpContext.Current.Session["Interface"] != null)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Interface>>(HttpContext.Current.Session["Interface"].ToString());
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    HttpContext.Current.Session.Remove("Interface");
                }
                else
                {
                    HttpContext.Current.Session["Interface"] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                }
            }

        }
        public static List<SMS.DataContext.Entities.RoleAccess> RoleAccess
        {
            get
            {
                if (HttpContext.Current.Session["RoleAccess"] != null)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleAccess>>(HttpContext.Current.Session["RoleAccess"].ToString());
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    HttpContext.Current.Session.Remove("RoleAccess");
                }
                else
                {
                    HttpContext.Current.Session["RoleAccess"] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                }
            }
        }
        public static List<SMS.DataContext.Entities.EventAccess> EventAccess
        {
            get
            {
                if (HttpContext.Current.Session["EventAccess"] != null)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<EventAccess>>(HttpContext.Current.Session["EventAccess"].ToString());
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    HttpContext.Current.Session.Remove("EventAccess");
                }
                else
                {
                    HttpContext.Current.Session["EventAccess"] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                }
            }
        }

        public static string RemoveAllWhiteSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }

        public static T GetConfigByKey<T>(this string key)
        {
            if (!string.IsNullOrEmpty(key.Trim()))
            {
                return (T)Convert.ChangeType(System.Configuration.ConfigurationManager.AppSettings[key], typeof(T));
            }
            return default(T);
        }

        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static Image LoadImage(string BitString)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(BitString);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            Image newImage = new Bitmap(image);
            image.Dispose();
            return newImage;
        }
        public static List<DateTime> GetNumberOfWeekendDays(DateTime start, DateTime stop)
        {
            List<DateTime> days = new List<DateTime>();
            while (start <= stop)
            {
                if (start.DayOfWeek == DayOfWeek.Friday || start.DayOfWeek == DayOfWeek.Saturday)
                {
                    days.Add(start);
                }
                start = start.AddDays(1);
            }
            return days;
        }

        public static void SendEmail(string subject, string body, string senderEmail, string senderPassword, string recieverEmail, string fileName = "")
        {
            using (MailMessage mm = new MailMessage(senderEmail, recieverEmail))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                if (fileName != "")
                {
                    mm.Attachments.Add(new Attachment(fileName));
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                credentials.UserName = senderEmail;
                credentials.Password = senderPassword;
                smtp.UseDefaultCredentials = true;

                smtp.Credentials = credentials;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
     
    }

}