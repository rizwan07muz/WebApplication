using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TodoItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsComplete { get; set; }
        public DateTime CompletedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
