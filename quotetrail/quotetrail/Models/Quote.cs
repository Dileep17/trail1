using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace quotetrail.Models
{
    public class Quote
    {
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Quoted By")]
        public string QuoteBy { get; set; }

        [Required]
        [Display(Name = "Quote String")]
        public string Quotestring { get; set; }

        [Required]
        [Display(Name = "Entered By")]
        public String User { get; set; }

        public string Status { get; set; }



        public bool AddQuote()
        {

            var myDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string parentDirectory = myDirectory.Parent.FullName;
            using (
                var cn =
                    new SQLiteConnection(string.Format(@"Data Source={0}{1} Version=3;", parentDirectory,
                                                       ConfigurationManager.ConnectionStrings["connectionstring"]
                                                           .ConnectionString)))
            {
                try
                {
                    string _sql = string.Format("Insert into quotes values('{0}','{1}','{2}',{3}','');",
                                                ProjectName, QuoteBy, Quotestring, User);
                    
                        SQLiteCommand myCommand = cn.CreateCommand();
                        myCommand.CommandText = _sql;
                        cn.Open();
                        myCommand.ExecuteNonQuery();
                        cn.Close();
                    
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    cn.Close();
                    return false;
                }

            }
        }
    }
}