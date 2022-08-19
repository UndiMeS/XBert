using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class NewWinController : MonoBehaviour
{
    public GameObject NewSkin;
    public Image SkinImage;
    public Sprite[] SkinSprites;
    public int[] StarsToUnlock;
    public bool IsActive = false;


    public GameObject YellowStarOne;
    public GameObject YellowStarTwo;
    public GameObject YellowStarThree;

    public Solution SolutionScript;


    public int StarsComplete;

    private string filename = "XBertDataFile.json";
    public bool Loaded;
    List<PlayerData> datas = new List<PlayerData>();


    public TMP_Text Headline;
    public TMP_Text Underline;

    public string HeadlineStringOne;
    public string UnderLineStringOne;

    public string HeadlineStringTwo;
    public string UnderLineStringTwo;

    public string HeadlineStringThree;
    public string UnderLineStringThree;
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




            if(SolutionScript.shadow == false)
        {
            if(SolutionScript.StarScore == 1)
            {
                Headline.text = HeadlineStringOne;
                Underline.text = UnderLineStringOne;
                LeanTween.scale(YellowStarOne, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.25f).setEase(LeanTweenType.easeOutElastic);
            }
            if(SolutionScript.StarScore == 2)
            {
                Headline.text = HeadlineStringTwo;
                Underline.text = UnderLineStringTwo;


                LeanTween.scale(YellowStarOne, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.25f).setEase(LeanTweenType.easeOutElastic);
                LeanTween.scale(YellowStarTwo, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
            }
            if(SolutionScript.StarScore == 3)
            {
                Headline.text = HeadlineStringThree;
                Underline.text = UnderLineStringThree;
                
                LeanTween.scale(YellowStarOne, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.25f).setEase(LeanTweenType.easeOutElastic);
                LeanTween.scale(YellowStarTwo, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
                LeanTween.scale(YellowStarThree, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.75f).setEase(LeanTweenType.easeOutElastic);
            }
        }
        if(SolutionScript.shadow == true)
            {
                if(SolutionScript.StarScore == 1)
                    {
                        LeanTween.scale(YellowStarTwo, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.25f).setEase(LeanTweenType.easeOutElastic);
                    }
            }




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

                for(int i = 0; i < SkinSprites.Length; i++)
                {
//  
                    if(StarsComplete >= StarsToUnlock[i] && PlayerPrefs.GetInt("SkinUnlock"+(i+1)) != 1)
                    {
                        NewSkin.SetActive(true);
                        SkinImage.sprite = SkinSprites[i];
                        LeanTween.scale(NewSkin, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.25f).setEase(LeanTweenType.easeOutElastic);
                        PlayerPrefs.SetInt("SkinUnlock"+(i+1),1);
                    }
                }

            

            

            

        }
        
    }
}
}
