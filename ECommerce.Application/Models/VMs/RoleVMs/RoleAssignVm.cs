using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.VMs.RoleVMs
{
    public class RoleAssignVm
    {
       
        public string RoleId { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; }
    }
}
