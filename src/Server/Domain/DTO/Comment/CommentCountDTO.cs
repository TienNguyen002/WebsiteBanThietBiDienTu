using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Comment
{
    public class CommentCountDTO
    {
        public int TotalRating { get; set; }
        public int Total5Rating { get; set; }
        public int Total4Rating { get; set; }
        public int Total3Rating { get; set; }
        public int Total2Rating { get; set;}
        public int Total1Rating { get; set; }
    }
}
