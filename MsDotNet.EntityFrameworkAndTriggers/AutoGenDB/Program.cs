using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AutoGenDB.AutoGenDBEntities())
            {
                // if master table is empty, then it inserts some master records.
                if (!context.Masters.Any())
                {
                    for (int masterIndex = 0; masterIndex < 5; masterIndex++)
                    {
                        var isAutoGenEnabled = masterIndex % 2 == 0;
                        var newMaster = new Master { IsAutoGen = isAutoGenEnabled, AutoGenPrefix = isAutoGenEnabled ? "GRP" + Convert.ToChar((masterIndex % 65) + 65) : default(string) };
                        context.Masters.Add(newMaster);
                    }
                    context.SaveChanges();
                }

                // Inserts some details on different groups
                List<Detail> details = new List<Detail>();
                List<Master> masters = context.Masters.AsNoTracking().ToList();
                for (int i = 0; i < 100; i++)
                {
                    var masterId = masters[i % masters.Count].Id;
                    details.Add(new Detail() { MasterId = masterId });
                }
                context.Details.AddRange(details);
                context.SaveChanges();

                // Prints 10 auto generated IDS
                foreach (var master in context.Masters.AsNoTracking().Take(3))
                    foreach (var detail in master.Details.Take(5))
                        Console.WriteLine(master.IsAutoGen ? "Ticket:{0}-{1}" : @"N/A", detail.AutoGenPrefix, detail.AutoGenNumber);
            }
            Console.ReadKey();
        }
    }
}
