﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject WorldOne;
    public GameObject WorldTwo;
    public GameObject WorldThree;
    public GameObject ShadowOne;
    public GameObject ShadowTwo;
    public GameObject ShadowThree;
    public static int World;
    public static bool ShadowWorld;
    public GameObject WorldTwoTransition;
    public Animator WorldOnetransition;
    public Animator WorldTwotransition;
    public GameObject WorldOneTransition;
    public GameObject WorldThreeTransition;
    public Animator WorldThreetransition;
    public Animator ShadowWorldOnetransition;
    public Animator ShadowWorldTwotransition;
    public GameObject ShadowWorldOneTransition;
    public GameObject ShadowWorldTwoTransition;


    public Animator MenuTransition;
    public float MenuTransTime;
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
            WorldOne.SetActive(true);
            StartCoroutine(ShadowToWorldOneTransition());
            StartMenu.SetActive(false);
            ShadowOne.SetActive(false);
            //WorldOne.SetActive(true);
        }
        else if(World == 1 && ShadowWorld == true)
        {
            StartCoroutine(ShadowOneTransition());
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
            
            //ShadowOne.SetActive(true);
        }
        else if(World == 2 && ShadowWorld == false)
        {
            WorldTwo.SetActive(true);
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
        }
        else if(World == 2 && ShadowWorld == true)
        {
            StartMenu.SetActive(false);
            ShadowTwo.SetActive(true);
            WorldOne.SetActive(false);
            WorldTwo.SetActive(false);
        }
        else if(World == 3 && ShadowWorld == false)
        {
            WorldTwo.SetActive(false);
            WorldThree.SetActive(true);
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
        }
        else if(World == 3 && ShadowWorld == true)
        {
            StartMenu.SetActive(false);
            ShadowThree.SetActive(true);
            WorldOne.SetActive(false);
            WorldTwo.SetActive(false);
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
        //StartCoroutine(ToWorldOneTransition());
        // WorldOneTransition.SetActive(true);
        // WorldTwoTransition.SetActive(false);
        //StartCoroutine(WorldTwoToWorldOne());

        StartCoroutine(MenuTransitioning(WorldTwo,StartMenu,WorldOne));
        
        // WorldTwo.SetActive(false);
        // WorldOne.SetActive(true);
        // World = 1;
    }

    public void ToWorldTwo()
    {
        // WorldTwoTransition.SetActive(true);
        // WorldOneTransition.SetActive(false);

        //StartCoroutine(WorldOneToWorldTwo());
        StartCoroutine(MenuTransitioning(WorldThree,WorldOne,WorldTwo));
        
        
    }

    public void ToWorldThree()
    {
        // WorldTwoTransition.SetActive(true);
        // WorldOneTransition.SetActive(false);

        //StartCoroutine(WorldTwoToWorldThree());

        StartCoroutine(MenuTransitioning(WorldOne, WorldTwo,WorldThree));
        
        
    }

    public void SwitchToNightOne()
    {
        StartCoroutine(ShadowOneTransition());
        
        
        //ShadowOne.SetActive(true);
        ShadowWorld = true;
    }

    public void SwitchToWorldOne()
    {
        StartCoroutine(ShadowToWorldOneTransition());
        // ShadowOne.SetActive(false);
        // WorldOne.SetActive(true);
        ShadowWorld = false;
    }


    public void SwitchToNightTwo()
    {
        StartCoroutine(ShadowTwoTransition());
        
        
        //ShadowOne.SetActive(true);
        ShadowWorld = true;
    }



    public void SwitchToWorldTwo()
    {
        StartCoroutine(ShadowToWorldTwoTransition());
        // ShadowOne.SetActive(false);
        // WorldOne.SetActive(true);
        ShadowWorld = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator ShadowOneTransition()
    {
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOneTransition.SetActive(false);
        ShadowWorldOneTransition.SetActive(true);
        WorldOne.SetActive(false);
        ShadowOne.SetActive(true);
    }

    IEnumerator ShadowToWorldOneTransition()
    {
        
        ShadowWorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        ShadowWorldOneTransition.SetActive(false);
        WorldOneTransition.SetActive(true);
        ShadowOne.SetActive(false);
        WorldOne.SetActive(true);
        
    }

    IEnumerator ToWorldOneTransition()
    {
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOnetransition.SetTrigger("end");
        StartMenu.SetActive(false);
        WorldOne.SetActive(true);
        World = 1;
    }



    IEnumerator ShadowTwoTransition()
    {
        WorldTwotransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldTwoTransition.SetActive(false);
        ShadowWorldTwoTransition.SetActive(true);
        WorldTwo.SetActive(false);
        ShadowTwo.SetActive(true);
    }


    IEnumerator ShadowToWorldTwoTransition()
    {
        
        ShadowWorldTwotransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        ShadowWorldTwoTransition.SetActive(false);
        WorldTwoTransition.SetActive(true);
        ShadowTwo.SetActive(false);
        WorldTwo.SetActive(true);
        
    }

    IEnumerator WorldOneToWorldTwo()
    {
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOneTransition.SetActive(false);
        WorldOne.SetActive(false);
        WorldTwo.SetActive(true);
        World = 2;

    }

    IEnumerator WorldTwoToWorldThree()
    {
        //WorldTwotransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldTwoTransition.SetActive(false);
        WorldTwo.SetActive(false);
        WorldThree.SetActive(true);
        World = 3;

    }

    IEnumerator WorldTwoToWorldOne()
    {
        if(World == 2)
        {
            WorldTwotransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOneTransition.SetActive(true);
        }
        
        WorldOne.SetActive(true);
        WorldTwo.SetActive(false);
        StartMenu.SetActive(false);
        World = 1;

    }

    public IEnumerator MenuTransitioning(GameObject DeactivateScreenOne, GameObject DeactivateScreenTwo, GameObject ActivateScreen)
    {
        MenuTransition.SetTrigger("start");
        DeactivateScreenOne.SetActive(false);
        DeactivateScreenTwo.SetActive(false);
        yield return new WaitForSeconds(MenuTransTime);
        MenuTransition.SetTrigger("end");
        ActivateScreen.SetActive(true);
        
    }

}
