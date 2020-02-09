﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models.asso_config
{
    public class ApplicationRole : IdentityRole
    {


        [StringLength(30)]
        public string Description{ get; set; }
    }
}
