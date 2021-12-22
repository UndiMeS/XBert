using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject WorldOne;
    public GameObject ShadowOne;
    public static int World;
    public static bool ShadowWorld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        if(World == 1 && ShadowWorld == false)
        {
            StartMenu.SetActive(false);
            ShadowOne.SetActive(false);
            WorldOne.SetActive(true);
        }
        else if(World == 1 && ShadowWorld == true)
        {
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
            ShadowOne.SetActive(true);
        }
    }

    public void ToStartMenu()
    {
        StartMenu.SetActive(true);
        WorldOne.SetActive(false);
        World = 0;
        ShadowWorld = false;
    }


    public void ToWorldOne()
    {
        StartMenu.SetActive(false);
        WorldOne.SetActive(true);
        World = 1;
    }

    public void SwitchToNightOne()
    {
        WorldOne.SetActive(false);
        ShadowOne.SetActive(true);
        ShadowWorld = true;
    }

    public void SwitchToWorldOne()
    {
        ShadowOne.SetActive(false);
        WorldOne.SetActive(true);
        ShadowWorld = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
