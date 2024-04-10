using AutoMapper;
using ECommerce.Application.Models.DTOs.MessageDTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.MessageService
{
    public class MessageService : IMessageService
    {
        public readonly IMapper _mapper;
        private readonly IMessageRepo _messageRepo;

        public MessageService(IMapper mapper, IMessageRepo messageRepo)
        {
            _mapper = mapper;
            _messageRepo = messageRepo;
        }

        public async Task Create(CreateMessageDto model)
        {
            var message = _mapper.Map<Message>(model);
            message.CreateDate = DateTime.Now;
            await _messageRepo.CreateAsync(message);
        }
    }
}
