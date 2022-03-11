// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    public int OneLevelSuccess;
    public int FirstThreeStars;
    public int GameFinished;
    public int GameComplete;


    public GameData(int OneLevelSuccess, int FirstThreeStars, int GameFinished, int GameComplete)
    {
        this.OneLevelSuccess = OneLevelSuccess;
        this.FirstThreeStars = FirstThreeStars;
        this.GameFinished = GameFinished;
        this.GameComplete = GameComplete;
    }


    // public PlayerData (Solution player)
    // {
    //     //WorldLevelScore = player.WorldLevelScore;
    // }

}
