using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int[][][] WorldLevelScore;


    public PlayerData (Solution player)
    {
        WorldLevelScore = player.WorldLevelScore;
    }

}
