namespace Domain.DTO.Discount
{
    public class DiscountEditModel
    {
        public string CodeName { get; set; }
        public double DiscountPrice { get; set; }
        public DateTime EndDate { get; set; }
    }
}
