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

    public Sprite LevelUnlock;

    public PlayerData SaveProfile;
    

    public SpriteRenderer StarOne;
    public SpriteRenderer StarTwo;
    public SpriteRenderer StarThree;
    public Sprite YellowStar;

    private string filename = "XBertDataFile.json";

    public int ListPlace;

    public bool Loaded;
    private bool Unlock;

    List<PlayerData> datas = new List<PlayerData>();

    public int WorldCount = 1;

    public LevelLoader lvlloader;
    public bool Shadowsuccess;


    void awake()
    {
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        // if(Shadow == false)
        // {
        //     ListPlace = World * 7 -7 + Level - 1;
        // }
        // else
        // {
        //     ListPlace = (World * 7 -7 + Level - 1) * (WorldCount + 1);
        // }





        if(File.Exists(Application.persistentDataPath + "/XBertDataFile.json") && Loaded == false)
        {
            

            Loaded = true;
            datas = FileHandler.ReadFromJSON<PlayerData>(filename);


            if(datas.Count > 0)
            {
                
                for(int i = 0; i <= datas.Count -1; i++)
                {
                    
                    



                    if(World == datas[i].world && Level == datas[i].level)
                    {
                        if(datas[i].complete == true && datas[i].shadow == false)
                        {
                            if(datas[i].score == 3)
                            {
                                
                                ShadowLevelButton.interactable = true;
                                if(Shadowsuccess == false)
                                {
                                    ShadowLevelSprite.sprite = ShadowUnlock;
                                }
                            
                            }
                        }
                        if(datas[i].complete == true && datas[i].shadow == false && Shadow == false)
                        {

                            world = datas[i].world;
                            level = datas[i].level;
                            shadow = datas[i].shadow;
                            complete = datas[i].complete;
                            score = datas[i].score;

                            

                            
                            NextLevelButton.interactable = true;

                                LevelSprite.sprite = LevelSuccess;

                            

                            //NextLevelSprite.sprite = NextLevelUnlock;
                            

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
                                if(Shadowsuccess == false)
                                {
                                    ShadowLevelSprite.sprite = ShadowUnlock;
                                }
                            
                            }
                            else
                            {

                            }
                        }

                        if(datas[i].complete == true && datas[i].shadow == true)
                        {
                            Shadowsuccess = true;
                        }
                        if(datas[i].complete == true && datas[i].shadow == true && Shadow == true)
                        {
                            if(datas[i].score == 1)
                            {
                                StarOne.sprite = YellowStar;
                            }
                            
                            LevelSprite.sprite = LevelSuccess;
                            ShadowLevelButton.interactable = true;
                        }
                    }

                    if(World == datas[i].world && Level - 1 == datas[i].level && datas[i].complete == true && complete != true && Shadow == false)
                    {
                            LevelSprite.sprite = LevelUnlock;
                        
                    }

                    if(World - 1 == datas[i].world && Level + 6 == datas[i].level && datas[i].complete == true && complete != true && Shadow == false)
                    {
                            LevelSprite.sprite = LevelUnlock;
                        
                    }


                }
            }

        


         }
    }

    // Update is called once per frame
    void Update()
    {
    
     }

    void OnEnable()
    {
        
        Loaded = false;
        
    }

    public void ClickOnLevel()
    {
        MenuButtonManager.World = World;
        MenuButtonManager.ShadowWorld = Shadow;
        lvlloader.LoadScene = LoadScene;
    }




 }
