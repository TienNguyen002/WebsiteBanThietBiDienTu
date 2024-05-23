using Domain.Contracts;

namespace Domain.Entities
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
