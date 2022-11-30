using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransitionManager : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject SkinMenu;
    public Animator MenuTransition;
    public float MenuTransTime;
    public GameObject Level;
    public GameObject Controller;
    public GameObject GameText;
    public GameObject TippMenu;
    public GameObject AudioMenu;
    public GameObject WinMenu;
    public bool FromWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToPauseMenu()
    {
        GameText.SetActive(false);
        Controller.SetActive(false);
        StartCoroutine(MenuTransitioning(Level,PauseMenu));
    }
    public void ToGame()
    {
        GameText.SetActive(true);
        Controller.SetActive(true);
        StartCoroutine(MenuTransitioning(PauseMenu,Level));
    }
    public void ToSkinMenu()
    {
        StartCoroutine(MenuTransitioning(PauseMenu,SkinMenu));
    }
    public void FromSkinToPause()
    {
        if(FromWin == false)
        {
            StartCoroutine(MenuTransitioning(SkinMenu, PauseMenu));
        }
        else if(FromWin == true)
        {
            FromWin = false;
            StartCoroutine(MenuTransitioning(SkinMenu, WinMenu));
        }
    }

    public void ToTippMenu()
    {
        StartCoroutine(MenuTransitioning(PauseMenu, TippMenu));
    }
    public void FromTippToPause()
    {
        StartCoroutine(MenuTransitioning(TippMenu, PauseMenu));
    }

    public void ToAudioMenu()
    {
        StartCoroutine(MenuTransitioning(PauseMenu, AudioMenu));
    }
    public void FromAudioToPause()
    {
        StartCoroutine(MenuTransitioning(AudioMenu, PauseMenu));
    }

    public void FromWinToSkin()
    {
        FromWin = true;
        StartCoroutine(MenuTransitioning(WinMenu, SkinMenu));
    }
    

    public IEnumerator MenuTransitioning(GameObject DeactivateScreenOne, GameObject ActivateScreen)
    {
        MenuTransition.SetTrigger("start");
        
        
        yield return new WaitForSeconds(MenuTransTime);
        DeactivateScreenOne.SetActive(false);
        ActivateScreen.SetActive(true);
        MenuTransition.SetTrigger("end");
        
        
    }
}
