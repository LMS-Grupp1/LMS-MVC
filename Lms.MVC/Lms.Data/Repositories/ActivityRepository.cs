﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Lms.MVC.Core.Entities;
using Lms.MVC.Core.Repositories;
using Lms.MVC.Data.Data;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lms.MVC.Data.Repositories
{
    internal class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext db;

        public ActivityRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(Activity added) => await db.AddAsync(added);

        public void Remove(Activity removed) => db.Remove(removed);

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync() => await db.Activities.ToListAsync();        

        public async Task<Activity> GetActivityAsync(int? id) => await db.Activities.FirstOrDefaultAsync(c => c.Id == id);
        
        public async Task<bool> SaveAsync() => (await db.SaveChangesAsync()) >= 0;        

        public async Task<bool> ActivityExists(int id) => await db.Activities.AnyAsync(c => c.Id == id);        

        public void Update(Activity activity) => db.Update(activity);

        public async Task<IEnumerable<ActivityType>> GetAllActivityTypesAsync() => await db.ActivityTypes.ToListAsync();
    }
}
