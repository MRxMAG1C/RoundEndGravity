using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace RoundEndGravity;

public class RoundEndGravityConfig : BasePluginConfig
{
    // Default CS2 gravity is 800. Lower = floatier
    [JsonPropertyName("low_gravity")]
    public int LowGravity { get; set; } = 240;
}
