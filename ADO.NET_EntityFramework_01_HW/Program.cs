using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET_EntityFramework_01_HW.Model;

namespace ADO.NET_EntityFramework_01_HW
{
    class Program
    {
        private static string _connstring = "";
        static void Main(string[] args)
        {

            try
            {
                using (CodeFirstDb db = new CodeFirstDb())
                {
                    _connstring = ConfigurationManager.ConnectionStrings["CodeFirstConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(_connstring))
                    {
                        var a = db.TablesManufacturers.ToList();
                        var b = db.TablesModels.ToList();
                        if (a.Count != 0 && b.Count != 0)
                        {
                            Parallel.ForEach(b, (some) =>
                            {
                               
                                Console.WriteLine("--------------------------------\nintManufacturerID = {0}\nintModelID = {1}\n" +
                                                  "intSMCSFamilyID = {2}\n" +
                                                  "strImage = {3}\n" +
                                                  "strName = {4}\n--------------------------------",
                                    some.intManufacturerID,some.intModelID,some.intSMCSFamilyID,some.strImage,some.strName);                  
                            });
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Green;
                           
                            Parallel.ForEach(a, (a1) =>
                            {
                                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\nintManufacturerID = {0}\nstrManufacturerChecklistId = {1}\nstrName = {2}" +
                                                  "\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>",
                                    a1.intManufacturerID, a1.strManufacturerChecklistId, a1.strName);
                            });
                            Console.WriteLine("Данные успешно внесены, теперь можно их получать");
                        }
                        else if(a.Count == 0 && b.Count == 0)
                        {
                            StreamReader fs =
                                new StreamReader(@"TablesManufacturers_inserts.txt");
                            StreamReader sr = new StreamReader(@"TablesModel_inserts.txt");
                            string tablesManufacturersInserts = fs.ReadToEnd();
                            string tablesModelInserts = sr.ReadToEnd();
                            SqlCommand cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = tablesManufacturersInserts;
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = null;
                            cmd.CommandText = tablesModelInserts;
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Данные успешно внесены, теперь можно их получать");
                            foreach (TablesManufacturer manufacturer in db.TablesManufacturers.OrderBy(o => o.intManufacturerID).ToList())
                            {
                                Console.WriteLine("{0}.{1} , {2}", manufacturer.intManufacturerID, manufacturer.strName, manufacturer.strManufacturerChecklistId);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
