using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine;
using TMPro;

public class CheatCode : MonoBehaviour
{
    private string filename = "XBertDataFile.json";

    public List<PlayerData> datas = new List<PlayerData>();
    public List<GameDatas> Gamedatas = new List<GameDatas>();

    public PlayerData player;

    public string codeOne;
    public string codeTwo;
    public string codeThree;

    public TMP_InputField code;

    // Start is called before the first frame update
    void Start()
    {
        // datas = FileHandler.ReadFromJSON<PlayerData>(filename);
        // Gamedatas = FileHandler.ReadFromJSONP<GameDatas>(filename);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCheatCode()
    {
        if(code.text == codeOne || code.text == codeTwo || code.text == codeThree)
        {
            if(File.Exists(Application.persistentDataPath + "/XBertDataFile.json"))
            {
                File.Delete (Application.persistentDataPath + "/XBertDataFile.json");
                
            }

            PlayerPrefs.DeleteAll();
            File.Create(Application.persistentDataPath + "/XBertDataFile.json").Dispose();

            if(code.text == codeOne)
            {
                CheatCodeOne();
            }
            else if(code.text == codeTwo)
            {
                CheatCodeTwo();
            }
            else if(code.text == codeThree)
            {
                CheatCodeThree();
            }

            
            SceneManager.LoadScene ("XBert_MainMenu");
        }

        
    }

    public void CheatCodeOne()
    {
        for(int x=1; x<8;x++)
        {
            datas.Add (new PlayerData(1, x, false, true, 3));
            Debug.Log("Cheat safe " + datas[x-1]);
            
        }
        Gamedatas.Add (new GameDatas(2, 2, 0, 0));
        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);
        PlayerPrefs.SetInt("intro", 2);
    }

    public void CheatCodeTwo()
    {
        for(int x=1; x<8;x++)
        {
            datas.Add (new PlayerData(1, x, false, true, 3));
            datas.Add (new PlayerData(2, x, false, true, 3));
            Debug.Log("Cheat safe " + datas[x-1]);
            
        }
        Gamedatas.Add (new GameDatas(2, 2, 0, 0));
        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);
        PlayerPrefs.SetInt("intro", 4);
    }

    public void CheatCodeThree()
    {
        for(int x=1; x<8;x++)
        {
            datas.Add (new PlayerData(1, x, false, true, 3));
            datas.Add (new PlayerData(2, x, false, true, 3));
            datas.Add (new PlayerData(3, x, false, true, 3));
            Debug.Log("Cheat safe " + datas[x-1]);
            
        }
        Gamedatas.Add (new GameDatas(2, 2, 2, 0));
        FileHandler.SaveToJSONP<PlayerData> (datas, Gamedatas, filename);
        PlayerPrefs.SetInt("intro", 5);
    }
    
}
