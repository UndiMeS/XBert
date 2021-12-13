using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class LoadStars : MonoBehaviour
{

    public int StarScore;
    public int World;
    public int Level;
    

    public SpriteRenderer StarOne;
    public SpriteRenderer StarTwo;
    public SpriteRenderer StarThree;
    public Sprite YellowStar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnEnable()
    {
        //PlayerData.current = (PlayerData)SerializationManager.LoadPlayer(Application.persistentDataPath + "/player.fun");
        SaveSystem.LoadPlayer();

        StarScore = PlayerData.current.score;

        if(World == PlayerData.current.world && Level == PlayerData.current.level)
        {
            if(StarScore == 1)
            {
                StarOne.sprite = YellowStar;
            }
            else if(StarScore == 2)
            {
                StarOne.sprite = YellowStar;
                StarTwo.sprite = YellowStar;
            }
            else if(StarScore == 3)
            {
                StarOne.sprite = YellowStar;
                StarTwo.sprite = YellowStar;
                StarThree.sprite = YellowStar;
            }
        }

        

        Debug.Log("Score" + PlayerData.current.score );
    }
}
