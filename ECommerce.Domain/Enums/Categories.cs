using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Enums
{
    public enum Categories
    {
        [Display(Name = "Mum Çakmağı")]
        Mumluk,
        [Display(Name = "Çakmak")]
        Cakmak,
        Aksesuar
    }
}
