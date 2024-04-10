using ECommerce.Application.Models.DTOs.MessageDTOs;
using ECommerce.Application.Models.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.MessageService
{
    public interface IMessageService
    {
        Task Create(CreateMessageDto model);
    }
}
