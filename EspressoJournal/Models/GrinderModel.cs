using System;

namespace EspressoJournal.Models;

public class GrinderModel
{
    public int ID { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string GrinderName => $"{BrandName.ToUpper()} - {ModelName}";
}
