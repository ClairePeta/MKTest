using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RacetrackGameMode : GameMode
{
    public MapManager mapManager;

    /// <summary>
    /// Called once before any players have spawned
    /// </summary>
    protected override void OnPreGameStart()
    {
        mapManager.init();
    }
}
