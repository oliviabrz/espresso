namespace EspressoDataService.Dto
{
    public class EspressoBeanDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly RoastDate { get; set; }
        public DateOnly PurchasedDate { get; set; }
        public string? PurchasedFrom { get; set; }
        public string? RoastType { get; set; }
    }
}
