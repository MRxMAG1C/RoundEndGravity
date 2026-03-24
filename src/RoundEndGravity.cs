using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace RoundEndGravity;

public class RoundEndGravityPlugin : BasePlugin, IPluginConfig<RoundEndGravityConfig>
{
    public override string ModuleName        => "RoundEndGravity";
    public override string ModuleVersion     => "1.0";
    public override string ModuleAuthor      => "MRxMAG1C";
    public override string ModuleDescription => "Applies low gravity at round end.";

    public RoundEndGravityConfig Config { get; set; } = new();

    public void OnConfigParsed(RoundEndGravityConfig config) => Config = config;

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventRoundEnd>(OnRoundEnd);
        RegisterEventHandler<EventRoundStart>(OnRoundStart);
        Log.Info("Plugin loaded.");
    }

    private HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo _)
    {
        Server.ExecuteCommand($"sv_gravity {Config.LowGravity}");
        Log.Info($"sv_gravity set to {Config.LowGravity}.");
        return HookResult.Continue;
    }

    private HookResult OnRoundStart(EventRoundStart @event, GameEventInfo _)
    {
        Server.ExecuteCommand($"sv_gravity {Config.NormalGravity}");
        Log.Info($"sv_gravity reset to {Config.NormalGravity}.");
        return HookResult.Continue;
    }

}
