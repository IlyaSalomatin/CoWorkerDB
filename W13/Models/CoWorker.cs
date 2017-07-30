using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W13.Models
{
    public class CoWorker
    {
        public int Id { get; set; }   // Первичный ключ
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int? EntityId { get; set; }   // Внешний ключ
        public virtual Entity Entity { get; set; }   // Навигационное свойство
        public virtual ICollection<Hobby> Hobbys { get; set; }
    }
}