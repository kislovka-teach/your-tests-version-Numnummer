using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Training Training { get; set; }
        public string Text { get; set; }
    }
}
