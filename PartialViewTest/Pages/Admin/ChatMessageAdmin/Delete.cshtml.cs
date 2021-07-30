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
    public class DeleteModel : PageModel
    {
        private readonly PartialViewTest.Data.Context.ChatContext _context;

        public DeleteModel(PartialViewTest.Data.Context.ChatContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChatMessage = await _context.Messages.FindAsync(id);

            if (ChatMessage != null)
            {
                _context.Messages.Remove(ChatMessage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
