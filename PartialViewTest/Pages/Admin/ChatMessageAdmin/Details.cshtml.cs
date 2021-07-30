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
    public class DetailsModel : PageModel
    {
        private readonly PartialViewTest.Data.Context.ChatContext _context;

        public DetailsModel(PartialViewTest.Data.Context.ChatContext context)
        {
            _context = context;
        }

        public ChatMessage ChatMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChatMessage = await _context.Messages.FirstOrDefaultAsync(m => m.MessageID == id);

            if (ChatMessage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
