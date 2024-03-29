namespace Domain.DTO.Discount
{
    public class DiscountEditModel
    {
        public decimal DiscountPrice { get; set; }
        public DateTime EndDate { get; set; }
        public int ProductId { get; set; }
    }
}
