using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace W13.Models
{
    public class CoWorkerContextInitializer : DropCreateDatabaseAlways<CoWorkerContext>
    {
        protected override void Seed(CoWorkerContext context)
        {

            Entity e1 = new Entity {Name = "human" };
            Entity e2 = new Entity { Name = "pet" };
            context.Entitys.Add(e1);
            context.Entitys.Add(e2);
            CoWorker cw1 = new CoWorker { Name = "Ilya", Position = "programmer", Age = 31, Entity =e1 };
            CoWorker cw2 = new CoWorker { Name = "Marino4ka", Position = "hr", Age = 29, Entity = e1 };
            CoWorker cw3 = new CoWorker { Name = "Pityun", Position = "KOTE", Age = 1, Entity = e2 };
            context.CoWorkers.Add(cw1);
            context.CoWorkers.Add(cw2);
            context.CoWorkers.Add(cw3);
            Hobby h1 = new Hobby { Name = "lazi", CoWorkers = new List<CoWorker>() {cw1,cw2,cw3 } };
            Hobby h2 = new Hobby { Name = "snowboarding", CoWorkers = new List<CoWorker>() {cw1,cw2 } };
            Hobby h3 = new Hobby { Name = "cycling", CoWorkers = new List<CoWorker>() {cw2,cw1 } };
            Hobby h4 = new Hobby { Name = "reading", CoWorkers = new List<CoWorker>() { cw2, cw1 } };
            Hobby h5 = new Hobby { Name = "study languages", CoWorkers = new List<CoWorker>() {cw2 } };
            context.Hobbys.Add(h1);
            context.Hobbys.Add(h2);
            context.Hobbys.Add(h3);
            context.Hobbys.Add(h4);
            context.Hobbys.Add(h5);
            context.SaveChanges();
        }
    }
}