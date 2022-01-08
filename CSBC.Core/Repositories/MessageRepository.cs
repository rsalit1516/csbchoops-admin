using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CSBC.Core.Models;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;

namespace CSBC.Core.Repositories
{
    public class MessageRepository : EFRepository<Message>, IMessageRepository
    {
         public MessageRepository(DbContext context) : base(context) { }
    }
}
