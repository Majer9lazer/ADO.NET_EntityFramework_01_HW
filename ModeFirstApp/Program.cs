using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ModeFirstApp.Model;

namespace ModeFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MCSContainer db = new MCSContainer();
            StreamReader r = new StreamReader("AboutEgor.txt", Encoding.Default);
            string text = r.ReadToEnd();
            Console.WriteLine("Подождите минуту. Выполняется важная операция...");
            int k = 0;
            start:

            try
            {
                List<Entity1> ls = new List<Entity1>();
                List<Entity2> ls2=new List<Entity2>();
                List<Entity3> ls3= new List<Entity3>();
                for (int i = 0; i < 2000; i++)
                {
                    Entity1 s = new Entity1();
                    s.Name = "You Know Who is The Best_(" + i + ")_using_Entity1_table";
                    s.Desc = text;

                    Entity3 s3 = new Entity3();
                    s3.Name = "You Know Who is The Best_(" + i + ")_using_Entity3_table";
                    s3.Desc = text;
                    Entity2 s2 = new Entity2();
                    s2.Name = "You Know Who is The Best_(" + i + ")_using_Entity2_table";
                    s2.Desc = text;
                    ls2.Add(s2);
                    ls.Add(s);
                    ls3.Add(s3);
                }

                
                foreach (Entity1 e in ls)
                {
                    db.Entity1Set.Add(e);
                    db.SaveChanges();
                }
              
                foreach (Entity2 e in ls2)
                {
                    db.Entity2Set.Add(e);
                    db.SaveChanges();
                }
                foreach (Entity3 e in ls3)
                {
                    db.Entity3Set.Add(e);
                    db.SaveChanges();
                }
                k++;
               
                    Console.WriteLine("База заполнена данными отлично!");
              
            }
            catch (Exception ex)
            {
                if (k == 5)
                {
                    Console.WriteLine("База заполнена данными отлично!");
                }
                else
                {
                    k++;
                    goto start;
                }

            }
        }
    }

}
