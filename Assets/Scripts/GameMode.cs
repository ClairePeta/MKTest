using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode : ScriptableObject
{
    [SerializeField]
    [Tooltip("Scene to load which contains Gamemode UI")]
    private string GameModeScene;

    [SerializeField]
    [Tooltip("Round Times are acessed from the top down")]
    private List<float> RoundTimes;

    public Action GameStartEvent;
    public Action InputStartEvent;

    public Action RoundStartEvent;
    public Action AllPlayersMovedEvent;
    public Action RoundEndEvent;
    public Action OnGameOverEvent;

    private List<float> gameTimes;

    /// <summary>
    /// Called once before any players have spawned
    /// </summary>
    protected virtual void OnPreGameStart() { }


    #region Public functions
    public void PreGameStart()
    {
        OnPreGameStart();
    }
    #endregion Public Functions
}
