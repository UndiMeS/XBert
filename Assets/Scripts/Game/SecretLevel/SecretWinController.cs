using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWinController : MonoBehaviour
{
    public GameObject NewSkin;
    public GameObject NewSkinGlow;
    public bool SkinAnimation;

    public GameObject GlitchStar;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("SecretSkin") == 1 && SkinAnimation == false)
        {
            NewSkin.SetActive(true);
            LeanTween.scale(NewSkin, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.25f).setEase(LeanTweenType.easeOutElastic);
            
            SkinAnimation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        NewSkinGlow.transform.Rotate(Vector3.forward, Time.deltaTime * 5.0f);



        LeanTween.scale(GlitchStar, new Vector3(1.5f,1.5f,1.5f), 2f).setDelay(0.25f).setEase(LeanTweenType.easeOutElastic);
                        
    }
}
