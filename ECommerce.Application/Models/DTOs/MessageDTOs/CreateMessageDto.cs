using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs.MessageDTOs
{
    public class CreateMessageDto
    {
        [Required(ErrorMessage = "Ad girişi zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-Posta girişi zorunludur.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Konu girişi zorunludur.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Mesaj girişi zorunludur.")]
        public string CustomerMessage { get; set; }
    }
}
