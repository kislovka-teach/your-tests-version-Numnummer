﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface ITrainingRepository : IRepository
    {
        Task<Training?> GetTrainingByIdAsync(int id);
    }
}
