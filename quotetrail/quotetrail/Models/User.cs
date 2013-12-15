using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.IO;

namespace quotetrail.Models
{
    public class User
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
        
        public bool IsValid(string _username)
        {
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string parentDirectory = myDirectory.Parent.FullName;
            using (var cn = new SQLiteConnection(string.Format(@"Data Source={0}{1} Version=3;", parentDirectory, ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString))) 
            {
                string _sql = @"SELECT id FROM Users " + 
                       "WHERE Name = '"+_username+"';";
                cn.Open();
                var cmd = new SQLiteCommand(_sql, cn);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }
    }
}