using LearnCleanArchitect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCleanArchitect.Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Candidate> Candidates { get;}
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
