using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Shared.Models.DTOs
{
    public class NewsDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Published_utc { get; set; }
        public string Article_url { get; set; }
    }
}
