using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadStars : MonoBehaviour
{

    public string LoadScene;
    public int World;
    public int Level;
    public bool Shadow;
[HideInInspector]
    public int world;
    [HideInInspector]
    public int level;
    [HideInInspector]
    public bool shadow;
    [HideInInspector]
    public bool complete;
    public int score;
    public SpriteRenderer LevelSprite;
    public SpriteRenderer NextLevelSprite;
    public Button NextLevelButton;
    public Sprite ShadowUnlock;
    public SpriteRenderer ShadowLevelSprite;
    public Button ShadowLevelButton;
    public Sprite LevelSuccess;

    public Sprite NextLevelUnlock;

    public PlayerData SaveProfile;
    

    public SpriteRenderer StarOne;
    public SpriteRenderer StarTwo;
    public SpriteRenderer StarThree;
    public Sprite YellowStar;

    private string filename = "XBertDataFile.json";

    public int ListPlace;

    public bool Loaded;

    List<PlayerData> datas = new List<PlayerData>();

    public int WorldCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(Shadow == false)
        {
            ListPlace = World * 7 -7 + Level - 1;
        }
        else
        {
            ListPlace = (World * 7 -7 + Level - 1) * (WorldCount + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(File.Exists(Application.dataPath + "/XBertDataFile.json") && Loaded == false)
        {
            

            Loaded = true;
            datas = FileHandler.ReadFromJSON<PlayerData>(filename);


            if(datas.Count > 0)
            {
                for(int i = 0; i <= datas.Count - 1; i++)
                {
                    if(World == datas[i].world && Level == datas[i].level)
                    {
                        if(datas[i].complete == true && datas[i].shadow == false && Shadow == false)
                        {

                            world = datas[i].world;
                            level = datas[i].level;
                            shadow = datas[i].shadow;
                            complete = datas[i].complete;
                            score = datas[i].score;

                            LevelSprite.sprite = LevelSuccess;
                            NextLevelSprite.sprite = NextLevelUnlock;
                            NextLevelButton.interactable = true;
                            

                            if(datas[i].score == 1)
                            {
                                StarOne.sprite = YellowStar;
                            }
                            else if(datas[i].score == 2)
                            {
                                StarOne.sprite = YellowStar;
                                StarTwo.sprite = YellowStar;
                            }
                            else if(datas[i].score == 3)
                            {
                                StarOne.sprite = YellowStar;
                                StarTwo.sprite = YellowStar;
                                StarThree.sprite = YellowStar;
                                ShadowLevelButton.interactable = true;
                            ShadowLevelSprite.sprite = ShadowUnlock;
                            }
                        }
                        if(datas[i].complete == true && datas[i].shadow == true && Shadow == true)
                        {
                            if(datas[i].score == 1)
                            {
                                StarOne.sprite = YellowStar;
                            }
                            LevelSprite.sprite = LevelSuccess;
                        }
                    }
                }
            }

        //     if(datas.Count > ListPlace )
        //     {
        //     world = datas[ListPlace].world;
        //     level = datas[ListPlace].level;
        //     shadow = datas[ListPlace].shadow;
        //     complete = datas[ListPlace].complete;
        //     score = datas[ListPlace].score;


        // LevelSprite = this.gameObject.GetComponent<SpriteRenderer>();

        // if(complete == true && Shadow == false)
        // {

        //     LevelSprite.sprite = LevelSuccess;
        //     NextLevelSprite.sprite = NextLevelUnlock;
        //     NextLevelButton.interactable = true;
        //     ShadowLevelButton.interactable = true;
        //     ShadowLevelSprite.sprite = ShadowUnlock;

        //     if(World == world && Level == level && shadow == false)
        //     {
        //         if(score == 1)
        //         {
        //             StarOne.sprite = YellowStar;
        //         }
        //         else if(score == 2)
        //         {
        //             StarOne.sprite = YellowStar;
        //             StarTwo.sprite = YellowStar;
        //         }
        //         else if(score == 3)
        //         {
        //             StarOne.sprite = YellowStar;
        //             StarTwo.sprite = YellowStar;
        //             StarThree.sprite = YellowStar;
        //         }
        //     }
        // }

        

        
        // Debug.Log("List platz" + ListPlace );
        // Debug.Log("Score" + score );
        //     }



         }
    }

    void OnEnable()
    {
        
        Loaded = false;
        
    }



    public void OnLevelClick()
    {
        Debug.Log("Load level");
        SceneManager.LoadScene(LoadScene);
    }
 }
