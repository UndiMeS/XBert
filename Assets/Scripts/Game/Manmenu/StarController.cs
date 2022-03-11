using System.Collections;
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
    public static int StarComplete;
    public bool Loaded;
    List<PlayerData> datas = new List<PlayerData>();
    private string filename = "XBertDataFile.json";

    public GameObject[] StarOutputs;
    // Start is called before the first frame update

    void awake()
        {

        }
    
    void Start()
    {

        if(File.Exists(Application.dataPath + "/XBertDataFile.json") && Loaded == false)
        {
            

            Loaded = true;
            datas = FileHandler.ReadFromJSON<PlayerData>(filename);


            if(datas.Count > 0)
            {
                for(int i = 0; i <= datas.Count - 1; i++)
                {
                    StarComplete += datas[i].score;
                }
            }
        }
                    
                    



                    


         








        // StarLoaders = GameObject.FindGameObjectsWithTag("LevelButton");

        // for(int i = 0; i < StarLoaders.Length; i++)
        // {
        //     //LoadScripts[i] = StarLoaders[i].GetComponent<LoadStars>();
            
        //     StarComplete += StarLoaders[i].GetComponent<LoadStars>().score;
        // }

    }

    // Update is called once per frame
    void Update()
    {
        StarOutputs = GameObject.FindGameObjectsWithTag("StarCount");

        foreach (GameObject StarOutput in StarOutputs)
        {
            StarOutput.GetComponent<TMP_Text>().text = StarComplete.ToString();
        }
    }
}
