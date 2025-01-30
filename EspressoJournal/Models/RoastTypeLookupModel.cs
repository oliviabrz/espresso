using System;
using System.Text.Json.Serialization;

namespace EspressoJournal.Models;

public class RoastTypeLookupModel
{
    [JsonPropertyName("id")]
    public int RoastTypeId { get; set; }

    [JsonPropertyName("name")]
    public string RoastTypeName { get; set; }
}
