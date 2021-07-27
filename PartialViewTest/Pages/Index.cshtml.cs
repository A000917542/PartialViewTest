using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartialViewTest.Data;
using PartialViewTest.Data.Context;

namespace PartialViewTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private ChatContext _context {get; set;}

        public IEnumerable<ChatMessage> ChatLog;

        [FromForm]
        [FromQuery]
        public ChatMessage Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ChatContext context)
        {
            _logger = logger;
            _context = context;

            //ChatLog = new List<ChatMessage>() {
            //    new ChatMessage() { UserName = "Brent", Message="Hello" }
            //    , new ChatMessage() { UserName = "Ted", Message="Hi There!" }
            //    , new ChatMessage() { UserName = "Brent", Message="How are you?" }
            //    , new ChatMessage() { UserName = "Ted", Message="I am doing great!" }
            //    , new ChatMessage() { UserName = "Ted", Message="What did you do last week?" }
            //};
        }

        public void OnGet()
        {
            if (Message != null && Message.MessageID > 0)
            {
                Message.WasRead = true;
                _context.Messages.Update(Message);
                _context.SaveChanges();
            }

            ChatLog = _context.Messages.ToList();
        }

        public void OnPost()
        {
            if (!String.IsNullOrEmpty(Message.UserName))
            {
                _context.Messages.Add(Message);
                _context.SaveChanges();
            }

            ChatLog = _context.Messages.ToList();
        }
    }
}
