namespace EspressoDataService.Dto
{
    public class JournalEntryDtoBase
    {
        public int EspressoBeanId { get; set; }
        public string? EspressoBeanName { get; set; }
        public int GrinderId { get; set; }
        public string? GrinderBrandName { get; set; }
        public string? GrinderModelName { get; set; }
        public ushort GrindSetting { get; set; }
        public ushort BeanWeightInGrams { get; set; }
        public ushort PreExtractionTimeInSeconds { get; set; }
        public ushort ExtractionTimeInSeconds { get; set; }
        public ushort EspressoWeightInGrams { get; set; }
        public ushort BitternessRank { get; set; }
        public ushort AcidityRank { get; set; }
        public ushort SourRank { get; set; }
        public ushort CremaRank { get; set; }
        public ushort SatisfactionRank { get; set; }
        public string? Comments { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}