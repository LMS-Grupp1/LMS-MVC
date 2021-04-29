﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Lms.MVC.Core.Entities;

namespace Lms.MVC.UI.Models.ViewModels
{
    public class CourseListViewModel
    {        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public bool ShowOnlyMyCourses { get; set; }

        // nav prop        
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Document> Documents { get; set; }

    }
}

