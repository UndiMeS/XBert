﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject WorldOne;
    public GameObject ShadowOne;
    public static bool NotFirstStart;
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
        if(NotFirstStart == true)
        {
            StartMenu.SetActive(false);
            WorldOne.SetActive(true);
        }
    }

    public void ToStartMenu()
    {
        StartMenu.SetActive(true);
        WorldOne.SetActive(false);
        NotFirstStart = false;
    }


    public void ToWorldOne()
    {
        StartMenu.SetActive(false);
        WorldOne.SetActive(true);
        NotFirstStart = true;
    }

    public void SwitchToNightOne()
    {
        WorldOne.SetActive(false);
        ShadowOne.SetActive(true);
    }

    public void SwitchToWorldOne()
    {
        ShadowOne.SetActive(false);
        WorldOne.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
