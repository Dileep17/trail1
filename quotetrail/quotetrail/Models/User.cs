using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace quotetrail.Models
{
    public class User
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }
        
        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(string _username)
        {
            using (var cn = new SQLiteConnection(@"Data Source=C:\SQLite\Quotes.db; Version=3;")) 
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