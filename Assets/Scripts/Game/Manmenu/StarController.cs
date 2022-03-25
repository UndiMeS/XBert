﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{
    public GameObject[] StarLoaders;
    public LoadStars[] LoadScripts;
    //public static int StarComplete;
    public bool Loaded;
    List<PlayerData> datas = new List<PlayerData>();
    List<GameDatas> Gamedatas = new List<GameDatas>();

    //public List Savedatas = new List<T>();

    //List<GameData> Gamedatas = new List<GameData>();
    private string filename = "XBertDataFile.json";

    private string statefilename = "XBertGameState.json";

    public GameObject[] StarOutputs;
    public GameObject FirstAchievement;
    public GameObject SecondAchievement;
    public GameObject ThirdAchievement;
    public GameObject FourthAchievement;
    public int ThreeStarCount;

    public int dataLength;


    public int oneLevelSuccess;
    public int firstThreeStars;
    public int gameFinished;
    public int gameComplete;
    public int datalength;
    public int LevelFinishedCount;
    // Start is called before the first frame update

    void awake()
        {

        }
    
    void Start()
    {


        if(File.Exists(Application.persistentDataPath + "/XBertDataFile.json") && Loaded == false)
         {

        Gamedatas = FileHandler.ReadFromJSONP<GameDatas> (filename);
        datas = FileHandler.ReadFromJSON<PlayerData>(filename);

            if(Gamedatas.Count > 0)
            {
                

                oneLevelSuccess = Gamedatas[0].OneLevelSuccess;
                firstThreeStars = Gamedatas[0].FirstThreeStars;
                gameFinished = Gamedatas[0].GameFinished;
                gameComplete = Gamedatas[0].GameComplete;
            }
         }


         if(datas.Count > 0)
            {
                Solution.StarComplete = 0;
                for(int i = 0; i < datas.Count; i++)
                {

                    

                    Solution.StarComplete += datas[i].score;

                   

                }

            }
        

                    
    }

    // Update is called once per frame
    void Update()
    {

        datalength = datas.Count;
        StarOutputs = GameObject.FindGameObjectsWithTag("StarCount");

        foreach (GameObject StarOutput in StarOutputs)
        {
            StarOutput.GetComponent<TMP_Text>().text = Solution.StarComplete.ToString();
        }


        if(firstThreeStars == 1)
        {
            SecondAchievement.SetActive(true);
        }
        if(oneLevelSuccess == 1)
        {
            FirstAchievement.SetActive(true);
        }
        if(gameFinished == 1)
        {
            ThirdAchievement.SetActive(true);
        }
        if(gameComplete == 1)
        {
            FourthAchievement.SetActive(true);
        }
    }



    public void CloseFirstAchievment()
    {

        Gamedatas = FileHandler.ReadFromJSONP<GameDatas> (filename);
        oneLevelSuccess = 2;
        Gamedatas[0].OneLevelSuccess = oneLevelSuccess;

        Gamedatas[0] = new GameDatas(oneLevelSuccess, firstThreeStars, gameFinished, gameComplete);
        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);

    }

    public void CloseSecondAchievment()
    {

        Gamedatas = FileHandler.ReadFromJSONP<GameDatas> (filename);
        firstThreeStars = 2;

        Gamedatas[0].FirstThreeStars = firstThreeStars;



        Gamedatas[0] = new GameDatas(oneLevelSuccess, firstThreeStars, gameFinished, gameComplete);
        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);

    }

    public void CloseThirdAchievment()
    {

        Gamedatas = FileHandler.ReadFromJSONP<GameDatas> (filename);
        gameFinished = 2;

        Gamedatas[0].GameFinished = gameFinished;



        Gamedatas[0] = new GameDatas(oneLevelSuccess, firstThreeStars, gameFinished, gameComplete);
        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);

    }

    public void CloseFourthAchievment()
    {

        Gamedatas = FileHandler.ReadFromJSONP<GameDatas> (filename);
        gameComplete = 2;

        Gamedatas[0].GameComplete = gameComplete;



        Gamedatas[0] = new GameDatas(oneLevelSuccess, firstThreeStars, gameFinished, gameComplete);
        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);

    }
}
