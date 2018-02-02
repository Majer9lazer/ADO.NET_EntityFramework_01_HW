using System;
using System.Diagnostics;
using System.Linq;
using DataBaseFirstApp.Model;

namespace DataBaseFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MCSEntities db = new MCSEntities();
            var a = db.TablesManufacturers.ToList();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            foreach (TablesManufacturer m in a)
            {
                Console.WriteLine("intManufacturerID = {0}\nstrName = {1}", m.intManufacturerID, m.strName);
            }
            stp.Stop();
            Console.WriteLine("usal for {0}\n\n\n", stp.ElapsedMilliseconds);
            //stp = new Stopwatch();
            //stp.Start();
            //Parallel.ForEach(a, (m) =>
            //{
            //    Console.WriteLine("intManufacturerID = {0}\nstrName = {1}", m.intManufacturerID, m.strName);
            //});
            //stp.Stop();
            //Console.WriteLine("{0}", stp.ElapsedMilliseconds);
        }
    }
}
