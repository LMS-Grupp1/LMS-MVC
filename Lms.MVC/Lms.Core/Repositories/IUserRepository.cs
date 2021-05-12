﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Lms.MVC.Core.Entities;

namespace Lms.MVC.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();

        string GetRole(ApplicationUser user);

        Task<ApplicationUser> FindAsync(string id, bool includeCourses);

        void Update(ApplicationUser user);

        void Remove(ApplicationUser user);

        public bool Any(string id);

        Task ChangeRoleAsync(ApplicationUser user);
    }
}