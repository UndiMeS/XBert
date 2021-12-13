using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //public int[,,] WorldLevelScore;
    private static PlayerData _current;
    public static PlayerData current
    {
        get
        {
            if(_current == null)
            {
                _current = new PlayerData();
            }
            return _current;
        }
    }



    public PlayerProfile profile;
    public int world;
    public int level;
    public int shadow;
    public int complete;
    public int score;


    // public PlayerData (Solution player)
    // {
    //     //WorldLevelScore = player.WorldLevelScore;
    // }

}
