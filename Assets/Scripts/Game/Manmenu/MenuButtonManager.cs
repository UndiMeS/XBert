using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
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
    public GameObject ShadowWorldThreeTransition;
    public GameObject StartPopUps;

    public GameObject SkinMenu;

    public GameObject Tutorial;
    public GameObject NightPopUp;
    public bool NightPopUpBool;


    public Animator MenuTransition;
    public float MenuTransTime;
    public int worldNumber;

    public int MenuNumber;
    // Start is called before the first frame update
    void Start()
    {


        if(!File.Exists(Application.persistentDataPath + "/XBertDataFile.json"))
        {
            StartPopUps.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        worldNumber = World;
    }

    public void OnEnable()
    {
        if(World == 1 && ShadowWorld == false)
        {
            WorldOne.SetActive(true);
            WorldOneTransition.SetActive(true);
            //StartCoroutine(ShadowToWorldOneTransition());
            StartMenu.SetActive(false);
            ShadowOne.SetActive(false);
            //WorldOne.SetActive(true);
            MenuNumber = 1;
        }
        else if(World == 1 && ShadowWorld == true)
        {
            //StartCoroutine(ShadowOneTransition());
            
        ShadowOne.SetActive(true);
        ShadowWorldOneTransition.SetActive(true);
        //ShadowWorldOneTransition.SetActive(true);
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);

            MenuNumber = 4;
            
            //ShadowOne.SetActive(true);
        }
        else if(World == 2 && ShadowWorld == false)
        {
            WorldTwo.SetActive(true);
            WorldTwoTransition.SetActive(true);
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
            MenuNumber = 2;
        }
        else if(World == 2 && ShadowWorld == true)
        {
            StartMenu.SetActive(false);
            ShadowTwo.SetActive(true);
            ShadowWorldTwoTransition.SetActive(true);
            //ShadowWorldTwoTransition.SetActive(true);
            WorldOne.SetActive(false);
            WorldTwo.SetActive(false);
            MenuNumber = 5;
        }
        else if(World == 3 && ShadowWorld == false)
        {
            
            WorldThree.SetActive(true);
            WorldThreeTransition.SetActive(true);
            StartMenu.SetActive(false);
            WorldTwo.SetActive(false);
            WorldOne.SetActive(false);
            MenuNumber = 3;
        }
        else if(World == 3 && ShadowWorld == true)
        {
            StartMenu.SetActive(false);
            ShadowThree.SetActive(true);
            ShadowWorldThreeTransition.SetActive(true);
            WorldOne.SetActive(false);
            WorldTwo.SetActive(false);
            MenuNumber = 6;
        }
        else if(World == 0)
        {
            WorldOneTransition.SetActive(true);
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

        MenuNumber = 1;

        

        StartCoroutine(MenuTransitioning(WorldTwo,StartMenu,ShadowOne,WorldOne));

        if(!File.Exists(Application.persistentDataPath + "/XBertDataFile.json"))
        {
            Tutorial.SetActive(true);
        }
        
        // WorldTwo.SetActive(false);
        // WorldOne.SetActive(true);
        // World = 1;
    }

    public void ToWorldTwo()
    {
        // WorldTwoTransition.SetActive(true);
        // WorldOneTransition.SetActive(false);

        //StartCoroutine(WorldOneToWorldTwo());
        MenuNumber = 2;
        ShadowTwo.SetActive(false);
        StartCoroutine(MenuTransitioning(WorldThree,WorldOne,ShadowTwo,WorldTwo));

        
        
    }

    public void ToWorldThree()
    {
        // WorldTwoTransition.SetActive(true);
        // WorldOneTransition.SetActive(false);

        //StartCoroutine(WorldTwoToWorldThree());
        MenuNumber = 3;

        StartCoroutine(MenuTransitioning(ShadowOne, WorldTwo,ShadowThree,WorldThree));
        
        
    }

    public void ToShadowOne()
    {
        MenuNumber = 4;
        if(StarController.NightButtonShine == true)
        {
            StarController.NightButtonShine = false;
        }
        StartCoroutine(MenuTransitioning(WorldOne,WorldTwo,WorldThree,ShadowOne));
    }
    public void ToShadowTwo()
    {
        MenuNumber = 5;
        if(StarController.NightButtonShine == true)
        {
            StarController.NightButtonShine = false;
        }
        StartCoroutine(MenuTransitioning(WorldOne,WorldTwo,WorldThree,ShadowTwo));
    }
    public void ToShadowThree()
    {
        MenuNumber = 6;
        if(StarController.NightButtonShine == true)
        {
            StarController.NightButtonShine = false;
        }
        StartCoroutine(MenuTransitioning(WorldThree,WorldTwo, WorldOne, ShadowThree));
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

    public void ToSkinMenu()
    {
        if(MenuNumber <= 3)
        {
            StartCoroutine(MenuTransitioning(WorldOne,WorldTwo,WorldThree,SkinMenu));
        }
        else if(MenuNumber >= 4)
        {
            StartCoroutine(MenuTransitioning(ShadowOne,ShadowTwo,ShadowThree,SkinMenu));
        }
        
    }

    public void FromSkinMenuToWorld()
    {
        if(MenuNumber == 1)
        {
            StartCoroutine(MenuTransitioning(SkinMenu,WorldTwo,WorldThree,WorldOne));
        }
        if(MenuNumber == 2)
        {
            StartCoroutine(MenuTransitioning(SkinMenu,WorldOne,WorldThree,WorldTwo));
        }
        if(MenuNumber == 3)
        {
            StartCoroutine(MenuTransitioning(SkinMenu,WorldTwo,WorldOne,WorldThree));
        }
        if(MenuNumber == 4)
        {
            StartCoroutine(MenuTransitioning(SkinMenu,ShadowTwo,ShadowThree,ShadowOne));
        }
        if(MenuNumber == 5)
        {
            StartCoroutine(MenuTransitioning(SkinMenu,ShadowOne,ShadowThree,ShadowTwo));
        }
        if(MenuNumber == 6)
        {
            StartCoroutine(MenuTransitioning(SkinMenu,ShadowTwo,ShadowOne,ShadowThree));
        }
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

    public IEnumerator MenuTransitioning(GameObject DeactivateScreenOne, GameObject DeactivateScreenTwo, GameObject DeactivateScreenThree, GameObject ActivateScreen)
    {
        MenuTransition.SetTrigger("start");
        DeactivateScreenOne.SetActive(false);
        DeactivateScreenTwo.SetActive(false);
        DeactivateScreenThree.SetActive(false);
        yield return new WaitForSeconds(MenuTransTime);
        MenuTransition.SetTrigger("end");
        ActivateScreen.SetActive(true);
        
    }

}
