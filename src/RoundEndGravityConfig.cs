using System.Text.Json.Serialization;

namespace RoundEndGravity;

public class RoundEndGravityConfig
{
    // Default CS2 gravity is 800. Lower = floatier
    [JsonPropertyName("low_gravity")]
    public int LowGravity { get; set; } = 240;

    [JsonPropertyName("normal_gravity")]
    public int NormalGravity { get; set; } = 800;
}
