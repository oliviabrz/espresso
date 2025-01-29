using System;

namespace EspressoJournal.Models;

public class EspressoBeanModel : RoastTypeLookupModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime RoastDate { get; set; }
    public DateTime PurchasedDate { get; set; }
    public string PurchasedFrom { get; set; }
}