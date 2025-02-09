using System;

namespace EspressoJournal.Models;

public class JournalEntryModel
{
     public int Id { get; set; }
    public int EspressoBeanId { get; set; }
    public string EspressoBeanName { get; set; }
    public int GrinderId { get; set; }
    public string GrinderBrandName { get; set; }
    public string GrinderModelName { get; set; }
    public string GrinderName =>  $"{GrinderBrandName} - {GrinderModelName}";
    public int GrindSetting { get; set; }
    public int BeanWeightInGrams { get; set; }
    public int PreExtractionTimeInSeconds { get; set; }
    public int ExtractionTimeInSeconds { get; set; }
    public int EspressoWeightInGrams { get; set; }
    public int BitternessRank { get; set; }
    public int AcidityRank { get; set; }
    public int SourRank { get; set; }
    public int CremaRank { get; set; }
    public int SatisfactionRank { get; set; }
    public string Comments { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
}