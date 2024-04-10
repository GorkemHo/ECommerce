using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class MessageRepo : BaseRepo<Message>, IMessageRepo
    {
        public MessageRepo(AppDbContext context) : base(context)
        {
        }
    }
}
