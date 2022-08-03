using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NewSkinController : MonoBehaviour
{
    public GameObject NewSkin;
    public Image SkinImage;
    public Sprite[] SkinSprites;
    public int[] StarsToUnlock;
    public bool IsActive = false;

    public int StarsComplete;

    private string filename = "XBertDataFile.json";
    public bool Loaded;
    List<PlayerData> datas = new List<PlayerData>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(this.gameObject.activeInHierarchy == true && IsActive == false)
        {
            IsActive = true;

            if(File.Exists(Application.persistentDataPath + "/XBertDataFile.json") && Loaded == false)
            {
                datas = FileHandler.ReadFromJSON<PlayerData>(filename);

                if(datas.Count > 0)
                {
                    StarsComplete = 0;
                    for(int i = 0; i < datas.Count; i++)
                    {
                        StarsComplete += datas[i].score;
                    }
                }

                for(int i = 0; i <= SkinSprites.Length; i++)
                {

                    if(StarsComplete >= StarsToUnlock[i] && PlayerPrefs.GetInt("SkinUnlock"+(i+1)) != 1)
                    {
                        NewSkin.SetActive(true);
                        SkinImage.sprite = SkinSprites[i];
                        PlayerPrefs.SetInt("SkinUnlock"+(i+1),1);
                    }
                    else
                    {
                        NewSkin.SetActive(false);
                        //PlayerPrefs.SetInt("SkinUnlock"+i,0);
                    }
                }

            

            

            

        }
        
    }
}
}
