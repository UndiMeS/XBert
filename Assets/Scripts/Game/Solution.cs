using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Solution : MonoBehaviour
{

    public int world;
    public int level;
    public bool shadow;
    [HideInInspector]
    public bool complete = false;
    public PlayerData player;
    //public int[,,] WorldLevelScore;
    public float NumbersSolution;
    public int EatenNumberCounter;
    public GameObject ZeroLeft;
    public GameObject ZeroRight;

    public int FirstStar;
    public int SecondStar;
    public int ThirdStar;

    public int StarScore = 0;

    public SpriteRenderer StarOne;
    public SpriteRenderer StarTwo;
    public SpriteRenderer StarThree;
    public Sprite YellowStar;

    public TMP_Text EatenCounter;
    public TMP_Text NumberCounter;


    public bool BiggerAs;
    public bool BiggerAndEqualAs;
    public bool SmallerAs;
    public bool SmallerAndEqualAs;
    public bool Equal;

    public bool Win;

    public float[] TermWerte;


    public bool LevelFinished;

    public GameObject Particles;
    public bool PlayParticle = true;
    public GameObject Pause;
    public GameObject[] Buttons;
    public GameObject PauseButton;
    public AudioSource XBertTeleport;
    public GameObject Xbert;

    public GameObject Level;
    public GameObject LevelComplete;
    public bool Spin;
    public bool save = true;
    [SerializeField]
    private string filename = "XBertDataFile.json";
    private int ListPlace;

    public int WorldCount = 4;
    public bool NextShadowLevel;
    public int DataCount;

    List<PlayerData> datas = new List<PlayerData>();
    List<GameDatas> Gamedatas = new List<GameDatas>();
    // Start is called before the first frame update
    void Start()
    {
        datas = FileHandler.ReadFromJSON<PlayerData>(filename);
        Gamedatas = FileHandler.ReadFromJSONP<GameDatas>(filename);

        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = NumbersSolution.ToString();

        EatenCounter.text = EatenNumberCounter.ToString();
        NumberCounter.text = EatenNumberCounter.ToString();


        
        Compare();

        // if(LevelFinished == true && save == true)
        // {
            
        //     player.profile.level = level;
        //     player.profile.score = StarScore;
        //     player.profile.shadow = shadow;
        //     player.profile.complete = complete;
        //     player.profile.world = world;

        //     SaveSystem.SavePlayer(player);

        //     save = false;
        // }



        

       

        if(NumbersSolution != 0)
        {
            ZeroRight.SetActive(false);

            NumbersSolution = Mathf.Round(NumbersSolution * 1000) / 1000;
        }
    }

    public void Compare(){
        if(BiggerAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution > TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }

        if(BiggerAndEqualAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution >= TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }


        if(SmallerAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution < TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }


        if(SmallerAndEqualAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution <= TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }

        if(Equal == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution == TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }
    }


    public void Stars(){

        if(shadow == false)
        { 
            if(EatenNumberCounter <= FirstStar)
            {
                StarOne.sprite = YellowStar;
                StarScore = 1;
            }

            if(EatenNumberCounter <= SecondStar)
            {
                StarTwo.sprite = YellowStar;
                StarScore = 2;
            }

            if(EatenNumberCounter <= ThirdStar)
            {
                StarThree.sprite = YellowStar;
                Debug.Log("3 star"+ EatenNumberCounter + " " + ThirdStar);
                StarScore = 3;
            }
        }

        else
        {
            if(EatenNumberCounter <= SecondStar)
            {
                StarTwo.sprite = YellowStar;
                StarScore = 1;
            }
        }


        

         

        
        
    }




    public IEnumerator WinningTime () {

        Debug.Log("Winning");

        if (LevelFinished == false) {

            if(level == 7 && world < 3 && shadow == false)
        {
            
            MenuButtonManager.World = world + 1;
        }
        else
        {
            MenuButtonManager.World = world;
        }

            Xbert.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            complete = true;
            

            Stars();
            //int[,,] WorldLevelScore = new int [world, level, StarScore];

            SaveToJson();

            Pause.GetComponent<PauseScript>().SpaceBool = false;
            LevelFinished = true;

            PauseButton.GetComponent<Button>().interactable = false;

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(false);
            }
            PauseButton.GetComponent<Button>().interactable = false;
            XBertTeleport.Play();


            yield return new WaitForSeconds (1.0f);

            Particles.transform.SetParent (null);

            if (PlayParticle) {
                Particles.GetComponent<ParticleSystem> ().Play ();
                PlayParticle = false;
            }

            Xbert.SetActive (false);

            yield return new WaitForSeconds (0.5f);



            Pause.GetComponent<PauseScript> ().Complete = true;

            yield return new WaitForSeconds (1.0f);

            Xbert.transform.Rotate (Vector3.forward * 0);

            Level.SetActive (false);
            LevelComplete.SetActive (true);

            Particles.GetComponent<ParticleSystem> ().Stop ();

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(true);
            }
            PauseButton.GetComponent<Button>().interactable = true;

            // Spin = true;

            PlayParticle = true;

        }

    }

    public void SaveToJson()
    {

        if(level == 1 && world == 1 && shadow == false)
                        {
                            //PlayerData.FirstLevelSuccess = 1;
                            //FileHandler.SaveToJSON<PlayerData> (datas.FirstLevelSuccess, filename);
                        }

        if(datas.Count > 0)
        {
            for(int i = 0; i <= datas.Count -1; i++)
            {
                    if(datas[i].world == world && datas[i].level == level + 1  && datas[i].shadow == false && datas[i].score == 3)
                {
                    NextShadowLevel = true;
                }


                if(datas[i].world == world && datas[i].level == level && datas[i].shadow == shadow)
                {
                    if(datas[i].score <= StarScore)
                    {
                        Debug.Log("replace data");
                        datas.RemoveAt(i);
                        datas.Insert (i, new PlayerData(world, level, shadow, complete, StarScore));
                        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);

                        
                        break;
                    }
                }
                else
                {
                    // Debug.Log("new data");
                    // datas.Add (new PlayerData(world, level, shadow, complete, StarScore));
                    // FileHandler.SaveToJSON<PlayerData> (datas, filename);
                    DataCount++;
                }

                
            
            }

            if(DataCount == datas.Count)
            {
                Debug.Log("new data");
                datas.Add (new PlayerData(world, level, shadow, complete, StarScore));
                FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);
            }
        }
        else
        {
            datas.Add (new PlayerData(world, level, shadow, complete, StarScore));
            FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);
            
        }
        
    }


    }

