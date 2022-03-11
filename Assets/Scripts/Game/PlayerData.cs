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
