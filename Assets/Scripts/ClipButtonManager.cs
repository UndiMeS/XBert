using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ClipButtonManager : MonoBehaviour
{
    private string filename = "XBertDataFile.json";
    List<PlayerData> datas = new List<PlayerData>();

    public Button ClipOne;
    public Image ClipOneImage;
    public Button ClipTwo;
    public Image ClipTwoImage;
    public Button Outro;
    public Image OutroImage;

    public bool Loaded;
    
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/XBertDataFile.json") && Loaded == false)
        {


            Loaded = true;
            datas = FileHandler.ReadFromJSON<PlayerData>(filename);

            if (datas.Count > 0)
            {
                for (int i = 0; i <= datas.Count - 1; i++)
                {
                    if (datas[i].world == 1 && datas[i].level == 7)
                    {
                        if (datas[i].complete == true && datas[i].shadow == false)
                        {
                            ClipOne.interactable = true;
                            ClipOneImage.color = new Color(255,255,255, 255);
                        }
                    }
                    if (datas[i].world == 2 &&datas[i].level == 7)
                    {
                        if (datas[i].complete == true && datas[i].shadow == false)
                        {
                            ClipTwo.interactable = true;
                            ClipTwoImage.color = new Color(255,255,255, 255);
                        }
                    }
                    if (datas[i].world == 3 &&datas[i].level == 7)
                    {
                        if (datas[i].complete == true && datas[i].shadow == false)
                        {
                            Outro.interactable = true;
                            OutroImage.color = new Color(255,255,255, 255);
                        }
                    }
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
