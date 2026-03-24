# RoundEndGravity
A [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp) plugin that applies low gravity at round end.

## Features
- Automatically lowers gravity when a round ends
- Restores normal gravity when the next round starts
- Configurable gravity values via `config.json`

## Configuration
A `config.json` file is automatically created in `configs/plugins/RoundEndGravity/` on first load.

| Field | Description |
|---|---|
| `low_gravity` | Gravity applied at round end. Defaults to `240`. |
| `normal_gravity` | Gravity restored at round start. Defaults to `800` (CS2 default). |

## Version
1.0

## Author
MRxMAG1C
