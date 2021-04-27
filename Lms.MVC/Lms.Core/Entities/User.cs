﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace Lms.MVC.Core.Entities
{
    public class User : IdentityUser
    {        
        public string Name { get; set; }

        // nav prop

        public ICollection<Document> Documents { get; set; }

    }
}
