// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
using System;

[System.Serializable]
public class PlayerData
{
    public int world;
    public int level;
    public bool shadow;
    public bool complete;
    public int score;

    // public int OneLevelSuccess;
    // public int FirstThreeStars;
    // public int GameFinished;
    // public int GameComplete;


    // public GameData(int OneLevelSuccess, int FirstThreeStars, int GameFinished, int GameComplete)
    // {
    //     this.OneLevelSuccess = OneLevelSuccess;
    //     this.FirstThreeStars = FirstThreeStars;
    //     this.GameFinished = GameFinished;
    //     this.GameComplete = GameComplete;
    // }

    // public static int FirstLevelSuccess = 0;
    // public int FirstThreeStars = 0;


    public PlayerData(int world, int level, bool shadow, bool complete, int score)
    {
        this.world = world;
        this.level = level;
        this.shadow = shadow;
        this.complete = complete;
        this.score = score;
    }


    // public PlayerData (Solution player)
    // {
    //     //WorldLevelScore = player.WorldLevelScore;
    // }

}

// public class GameData
// {
//     public int OneLevelSuccess;
//     public int FirstThreeStars;
//     public int GameFinished;
//     public int GameComplete;


//     public GameData(int OneLevelSuccess, int FirstThreeStars, int GameFinished, int GameComplete)
//     {
//         this.OneLevelSuccess = OneLevelSuccess;
//         this.FirstThreeStars = FirstThreeStars;
//         this.GameFinished = GameFinished;
//         this.GameComplete = GameComplete;
//     }


//     // public PlayerData (Solution player)
//     // {
//     //     //WorldLevelScore = player.WorldLevelScore;
//     // }

// }
