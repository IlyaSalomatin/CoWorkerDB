using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W13.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CoWorker> CoWorkers { get; set; }   // Навигационное свойство     
    }
}