using System.Text.Json;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace RoundEndGravity;

public class RoundEndGravityPlugin : BasePlugin
{
    public override string ModuleName        => "RoundEndGravity";
    public override string ModuleVersion     => "1.0";
    public override string ModuleAuthor      => "MRxMAG1C";
    public override string ModuleDescription => "Applies low gravity at round end.";

    private RoundEndGravityConfig _config = new();

    public override void Load(bool hotReload)
    {
        _config = LoadConfig();
        RegisterEventHandler<EventRoundEnd>(OnRoundEnd);
        RegisterEventHandler<EventRoundStart>(OnRoundStart);
        Log.Info("Plugin loaded.");
    }

    private HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo _)
    {
        Server.ExecuteCommand($"sv_gravity {_config.LowGravity}");
        Log.Info($"sv_gravity set to {_config.LowGravity}.");
        return HookResult.Continue;
    }

    private HookResult OnRoundStart(EventRoundStart @event, GameEventInfo _)
    {
        Server.ExecuteCommand($"sv_gravity {_config.NormalGravity}");
        Log.Info($"sv_gravity reset to {_config.NormalGravity}.");
        return HookResult.Continue;
    }

    private RoundEndGravityConfig LoadConfig()
    {
        var configPath = Path.Combine(ModuleDirectory, "config.json");

        if (!File.Exists(configPath))
        {
            var defaultConfig = new RoundEndGravityConfig();
            File.WriteAllText(configPath, JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true }));
            return defaultConfig;
        }

        return JsonSerializer.Deserialize<RoundEndGravityConfig>(File.ReadAllText(configPath)) ?? new RoundEndGravityConfig();
    }
}
