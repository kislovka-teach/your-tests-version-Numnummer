using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Excercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Duration { get; set; }
        public float RestDuration { get; set; }
        public int ApproachesCount { get; set; }
    }
}
