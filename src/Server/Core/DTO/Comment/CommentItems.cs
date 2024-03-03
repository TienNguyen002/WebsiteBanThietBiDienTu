using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Comment
{
    public class CommentItems
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime CreateDate { get; set; }
        public string CustomerName { get; set; }
        public string ProductUrlSlug { get; set; }
    }
}
