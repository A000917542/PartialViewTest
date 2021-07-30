using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartialViewTest.Data;
using PartialViewTest.Data.Context;

namespace PartialViewTest.Pages.Admin.ChatMessageAdmin
{
    public class EditModel : PageModel
    {
        private readonly PartialViewTest.Data.Context.ChatContext _context;

        public EditModel(PartialViewTest.Data.Context.ChatContext context)
        {
            _context = context;
        }

        [BindProperty] // This should be a FromForm, but the scaffold does it this way.
        public ChatMessage ChatMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChatMessage = await _context.Messages.FirstOrDefaultAsync(m => m.MessageID == id); // SELECT * FROM Messages WHERE MessageID = ?34?;

            if (ChatMessage == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChatMessage).State = EntityState.Modified;
            // _context.Messages.Update(ChatMessage);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMessageExists(ChatMessage.MessageID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChatMessageExists(int id)
        {
            return _context.Messages.Any(e => e.MessageID == id);
        }
    }
}
