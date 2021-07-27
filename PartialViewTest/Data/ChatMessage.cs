using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewTest.Data
{
    public class ChatMessage
    {
        [Key]
        public int MessageID { get; set; }
        
        [StringLength(128, MinimumLength = 3)]
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool WasRead { get; set; } = false;
    }
}
