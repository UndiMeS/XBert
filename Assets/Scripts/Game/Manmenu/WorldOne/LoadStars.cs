using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadStars : MonoBehaviour
{

    public string LoadScene;
    public int World;
    public int Level;
[HideInInspector]
    public int world;
    [HideInInspector]
    public int level;
    [HideInInspector]
    public bool shadow;
    [HideInInspector]
    public bool complete;
    public int score;
    [HideInInspector]
    public SpriteRenderer LevelSprite;
    public SpriteRenderer NextLevelSprite;
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

    // Start is called before the first frame update
    void Start()
    {
        ListPlace = World * 7 -7 + Level - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(File.Exists(Application.dataPath + "/XBertDataFile.json") && Loaded == false)
        {

            Loaded = true;
            datas = FileHandler.ReadFromJSON<PlayerData>(filename);

            world = datas[ListPlace].world;
            level = datas[ListPlace].level;
            shadow = datas[ListPlace].shadow;
            complete = datas[ListPlace].complete;
            score = datas[ListPlace].score;





        //     string json = File.ReadAllText(Application.dataPath + "/XBertDataFile.json");
        // PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        // world= data.world;
        // level = data.level;
        // shadow = data.shadow;
        // complete = data.complete;
        // score = data.score;






        LevelSprite = this.gameObject.GetComponent<SpriteRenderer>();
        //PlayerData.current = (PlayerData)SerializationManager.LoadPlayer(Application.persistentDataPath + "/player.fun"); 
        //SaveProfile = SaveSystem.LoadPlayer();

        if(complete == true)
        {

            LevelSprite.sprite = LevelSuccess;
            NextLevelSprite.sprite = NextLevelUnlock;

            if(World == world && Level == level && shadow == false)
            {
                if(score == 1)
                {
                    StarOne.sprite = YellowStar;
                }
                else if(score == 2)
                {
                    StarOne.sprite = YellowStar;
                    StarTwo.sprite = YellowStar;
                }
                else if(score == 3)
                {
                    StarOne.sprite = YellowStar;
                    StarTwo.sprite = YellowStar;
                    StarThree.sprite = YellowStar;
                }
            }
        }

        

        
        Debug.Log("List platz" + ListPlace );
        Debug.Log("Score" + score );

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
