namespace EspressoDataService.Dto
{
    public class EspressoBeanDtoBase
    {
        public string? Name { get; set; }
        public DateTime RoastDate { get; set; }
        public DateTime PurchasedDate { get; set; }
        public string? PurchasedFrom { get; set; }
        public int RoastTypeId { get; set; }
    }
}
