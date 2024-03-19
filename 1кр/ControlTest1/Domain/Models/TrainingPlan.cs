using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public Training Training { get; set; }
        public Excercise Excercise { get; set; }
    }
}
