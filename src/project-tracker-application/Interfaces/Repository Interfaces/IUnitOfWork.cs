using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.Interfaces.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}
