using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// List of all public game events used
/// </summary>
public struct GameEvents
{
    public delegate void GameAction();

    // loss due to paradox
    public static event GameAction OnParadox;
    public static void InitiateParadox() => OnParadox?.Invoke();

    // generic win
    public static event GameAction OnWin;
    public static void Win() => OnWin?.Invoke();

    // player starts rewinding
    public static event GameAction OnRewind;
    public static void Rewind() => OnRewind?.Invoke();

    // player stops rewinding
    public static event GameAction OnStopRewind;
    public static void StopRewind() => OnStopRewind?.Invoke();

    // player reloads game
    public static GameAction OnReload;
    public static void Reload() => OnReload?.Invoke();

    // player quits game
    public static GameAction OnQuit;
    public static void Quit() => OnQuit?.Invoke();

}
