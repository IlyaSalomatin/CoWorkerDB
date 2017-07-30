using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace W13.Models
{
    public class CoWorkerContext : DbContext
    {
        static CoWorkerContext()
        {
            Database.SetInitializer<CoWorkerContext>(new CoWorkerContextInitializer());
        }        
        public DbSet<CoWorker> CoWorkers { get; set; }
        public DbSet<Entity> Entitys { get; set; }
        public DbSet<Hobby> Hobbys { get; set; } 
    }
}