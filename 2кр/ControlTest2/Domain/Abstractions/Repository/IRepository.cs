using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repository
{
    public interface IRepository
    {
        Task SaveChangesAsync();
    }
}
