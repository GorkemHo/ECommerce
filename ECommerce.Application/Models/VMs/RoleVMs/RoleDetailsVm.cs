using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.VMs.RoleVMs
{
    public class RoleDetailsVm
    {
        public IdentityRole Role { get; set; }
        public List<AppUser> UsersInRole { get; set; }
    }
}
