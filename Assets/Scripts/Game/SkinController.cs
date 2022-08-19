using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinController : MonoBehaviour
{
    public bool unlocked;
    public Sprite UnlockedSkin;
    public Image SkinImage;
    public TMP_Text TMP_Titel;
    public GameObject NewLabel;
    public string Titel;
    public int SkinNumber;

    public bool IsActive = false;

    public int NewCount = 0;
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

            if(PlayerPrefs.GetInt("SkinUnlock"+SkinNumber) == 1)
            {
                unlocked = true;
            }

            
            

            if(unlocked == true) {
                SkinImage.sprite = UnlockedSkin;
                TMP_Titel.text = Titel;

                
            if(PlayerPrefs.GetInt("NewSkin"+SkinNumber) != 1)
                {
                    NewLabel.SetActive(true);
                    NewCount = PlayerPrefs.GetInt("NewSkin"+SkinNumber);
                    PlayerPrefs.SetInt("NewSkin"+SkinNumber, 1);
                    
                }
            else
            {
                NewLabel.SetActive(false);
            }
                
            }

        }

    }
}
