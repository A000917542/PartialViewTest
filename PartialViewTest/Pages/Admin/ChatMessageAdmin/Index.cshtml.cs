using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PartialViewTest.Data;
using PartialViewTest.Data.Context;

namespace PartialViewTest.Pages.Admin.ChatMessageAdmin
{
    public class IndexModel : PageModel
    {
        private readonly PartialViewTest.Data.Context.ChatContext _context;

        public IndexModel(PartialViewTest.Data.Context.ChatContext context)
        {
            _context = context;
        }

        public IList<ChatMessage> ChatMessage { get;set; }

        public async Task OnGetAsync()
        {
            ChatMessage = await _context.Messages.ToListAsync();
        }
    }
}
