using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewTest.Data.Context
{
    public class ChatContext
        : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
            :base(options)
        { }

        public DbSet<ChatMessage> Messages { get; set; }
    }


}
