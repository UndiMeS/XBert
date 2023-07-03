using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{

    public GameObject ScalingCanvas;
    private float screenAspect;

    public GameObject StartMenu;
    public GameObject Intro;
    public GameObject IntroFirstScreen;
    public GameObject IntroLastScreen;

    public GameObject Outro;
    public GameObject OutroTransition;
    public Animator Outrotransition;
    public DialogueManager IntroDialogueManager;
    public OutroDialogueManager outroDialogueManager;

    public GameObject CutSceneOne;
    public GameObject CutSceneTwo;
    public int IntroBool;
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

    public GameObject WorldThreeCutsceneTransition;
    public Animator WorldThreeCutscenetransition;
    public Animator ShadowWorldOnetransition;
    public Animator ShadowWorldTwotransition;
    public GameObject ShadowWorldOneTransition;
    public GameObject ShadowWorldTwoTransition;
    public GameObject ShadowWorldThreeTransition;
    public GameObject StartPopUps;

    public GameObject SkinMenu;

    public GameObject Tutorial;
    public GameObject TutorialTwo;
    public GameObject NightPopUp;
    public bool NightPopUpBool;


    public Animator MenuTransition;
    public float MenuTransTime;
    public int worldNumber;

    public int MenuNumber;




    // Start is called before the first frame update
    void Start()
    {
        screenAspect = Screen.width/Screen.height;


        if(ScalingCanvas != null)
        {
            if(screenAspect <= 16/9)
            {
                ScalingCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
            }
            else
            {
                ScalingCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            }
        }


        if(!File.Exists(Application.persistentDataPath + "/XBertDataFile.json"))
        {
            StartPopUps.SetActive(true);
            PlayerPrefs.SetInt("intro", 0);

            File.Create(Application.persistentDataPath + "/XBertDataFile.json").Dispose();
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
            IntroBool = PlayerPrefs.GetInt("intro");


            //WorldTwoTransition.SetActive(true);
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
            

            if(IntroBool == 2)
            {

                

                StartCoroutine(ToCutsceneOneTransition());

                CutSceneOne.SetActive(true);
                //WorldTwoTransition.SetActive(true);
                TutorialTwo.SetActive(true);
                PlayerPrefs.SetInt("intro", 3);

                // ClipOne.interactable = true;
                // clipOne.color = new Color(255,255,255, 255);

            }

            if(IntroBool >= 3)
            {
                WorldTwo.SetActive(true);
                WorldTwoTransition.SetActive(true);
            }
        


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
            IntroBool = PlayerPrefs.GetInt("intro");

            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
            WorldTwo.SetActive(false);

            if(IntroBool == 4)
            {
                CutSceneTwo.SetActive(true);
                StartCoroutine(ToCutsceneTwoTransition());

                
                //WorldTwoTransition.SetActive(true);
                //TutorialTwo.SetActive(true);
                PlayerPrefs.SetInt("intro", 5);

                Debug.Log("IntroBool Cutscene " + IntroBool);

                // ClipOne.interactable = true;
                // clipOne.color = new Color(255,255,255, 255);

                // ClipTwo.interactable = true;
                // clipTwo.color = new Color(255,255,255, 255);

            }

            if(IntroBool == 6)
            {
                
                ToOutroTransition();

                
                //WorldTwoTransition.SetActive(true);
                //TutorialTwo.SetActive(true);
                PlayerPrefs.SetInt("intro", 7);

                Debug.Log("IntroBool Outro " + IntroBool);
                StartPopUps.SetActive(false);

                

                // ClipOne.interactable = true;
                // clipOne.color = new Color(255,255,255, 255);

                // ClipTwo.interactable = true;
                // clipTwo.color = new Color(255,255,255, 255);

                // ClipOutro.interactable = true;
                // clipOutro.color = new Color(255,255,255, 255);



            }

            if(IntroBool >= 5 && IntroBool != 6)
            {
                WorldThree.SetActive(true);
                WorldThreeTransition.SetActive(true);
            }



            // WorldThreeTransition.SetActive(true);
            // StartMenu.SetActive(false);
            // WorldTwo.SetActive(false);
            // WorldOne.SetActive(false);
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
    public void ToIntro()
    {

    }


    public void ToWorldOne()
    {
        //StartCoroutine(ToWorldOneTransition());
        // WorldOneTransition.SetActive(true);
        // WorldTwoTransition.SetActive(false);
        //StartCoroutine(WorldTwoToWorldOne());
        IntroBool = PlayerPrefs.GetInt("intro");

        if(IntroBool == 0)
        {
            //StartCoroutine(MenuTransitioning(WorldOne,StartMenu,ShadowOne,Intro));
            StartCoroutine(ToIntroTransition());
            Tutorial.SetActive(true);
            PlayerPrefs.SetInt("intro", 1);
        }
        else
        {
            StartCoroutine(MenuTransitioning(WorldTwo,StartMenu,ShadowOne,WorldOne));

            if(!File.Exists(Application.persistentDataPath + "/XBertDataFile.json"))
            {
                Tutorial.SetActive(true);
            }
        }

        MenuNumber = 1;

        

        
        
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
        // if(StarController.NightButtonShine == true)
        // {
        //     StarController.NightButtonShine = false;
        // }
        StartCoroutine(MenuTransitioning(WorldOne,WorldTwo,WorldThree,ShadowOne));
    }
    public void ToShadowTwo()
    {
        MenuNumber = 5;
        // if(StarController.NightButtonShine == true)
        // {
        //     StarController.NightButtonShine = false;
        // }
        StartCoroutine(MenuTransitioning(WorldOne,WorldTwo,WorldThree,ShadowTwo));
    }
    public void ToShadowThree()
    {
        MenuNumber = 6;
        // if(StarController.NightButtonShine == true)
        // {
        //     StarController.NightButtonShine = false;
        // }
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
    public void FromIntroToWorldOne()
    {
        StartCoroutine(ToWorldOneTransition());
    }

    public void FromStartMenuToClip(string ClipScene)
    {
        StartCoroutine(ToClipTransition(ClipScene));
    }

    public void FromClipToStartMenu()
    {
        StartCoroutine(ToStartMenuTransition());
    }

    public void FromCutsceneToWorldTwo()
    {
        StartCoroutine(CutsceneOneToWorldTwo());
    }

    public void FromCutsceneToWorldThree()
    {
        StartCoroutine(CutsceneTwoToWorldThree());
    }

    public void ToIntroButton()
    {
        StartCoroutine(ToIntroTransition());
    }

    public void FromOutroToWorldThree()
    {
        StartCoroutine(ToWorldThreeTransition());
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

    public void HardResetGame(){
        StartCoroutine(hardResetGame());
    }
    IEnumerator hardResetGame(){
        File.Delete (Application.persistentDataPath + "/XBertDataFile.json");
        PlayerPrefs.DeleteAll();
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        //UnityEditor.AssetDatabase.Refresh();
        SceneManager.LoadScene ("XBert_MainMenu");
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
        IntroBool = PlayerPrefs.GetInt("intro");
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOnetransition.SetTrigger("end");

        IntroFirstScreen.SetActive(true);
        IntroLastScreen.SetActive(false);

        IntroDialogueManager.EndIntro();

        if(IntroBool == 0)
        {
            Intro.SetActive(false);
            StartMenu.SetActive(false);
            WorldOne.SetActive(true);
            World = 1;
        }
        else
        {
            SceneManager.LoadScene ("XBert_MainMenu");
        }

        
    }

    IEnumerator ToWorldThreeTransition()
    {
        IntroBool = PlayerPrefs.GetInt("intro");
        OutroTransition.SetActive(true);
        Outrotransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        

        outroDialogueManager.EndIntro();

        if(IntroBool == 7)
        {
            Outro.SetActive(false);
            StartMenu.SetActive(false);
            StartPopUps.SetActive(true);
            WorldThree.SetActive(true);
            World = 3;
            WorldThreeTransition.SetActive(true);
            WorldThreetransition.SetTrigger("end");
        }
        else
        {
            SceneManager.LoadScene ("XBert_MainMenu");
        }



            

        
    }

    IEnumerator ToStartMenuTransition()
    {
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOnetransition.SetTrigger("end");

        // IntroFirstScreen.SetActive(true);
        // IntroLastScreen.SetActive(false);

        // IntroDialogueManager.EndIntro();

        // Intro.SetActive(false);
        SceneManager.LoadScene ("XBert_MainMenu");
    }
    IEnumerator ToIntroTransition()
    {
        IntroBool = PlayerPrefs.GetInt("intro");
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOnetransition.SetTrigger("end");
        if(IntroBool == 0)
        {
            StartMenu.SetActive(false);
            Intro.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene ("XBert_Intro");
        }
        
    }

    IEnumerator ToClipTransition(string ClipScene)
    {
        
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOnetransition.SetTrigger("end");
        SceneManager.LoadScene (ClipScene);
        
        
    }

    public void ToOutroTransition()
    {
        IntroBool = PlayerPrefs.GetInt("intro");
        Outrotransition.SetTrigger("end");
        if(IntroBool == 6)
        {
            CutSceneTwo.SetActive(false);
            WorldThree.SetActive(false);
            Outro.SetActive(true);
        }
        else
        {
            //SceneManager.LoadScene ("XBert_Outor");
        }
        
    }

    IEnumerator ToCutsceneOneTransition()
    {
        WorldTwotransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldTwotransition.SetTrigger("end");
        CutSceneOne.SetActive(true);
    }

    IEnumerator ToCutsceneTwoTransition()
    {
        //WorldThreeCutscenetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldThreeCutscenetransition.SetTrigger("end");
        CutSceneTwo.SetActive(true);
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

    IEnumerator CutsceneOneToWorldTwo()
    {
        StartMenu.SetActive(false);
        WorldTwoTransition.SetActive(true);
        WorldTwotransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldTwoTransition.SetActive(false);
        CutSceneOne.SetActive(false);
        WorldTwo.SetActive(true);
        WorldTwoTransition.SetActive(true);
        WorldTwotransition.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        WorldTwoTransition.SetActive(false);
        World = 2;
    }

    IEnumerator CutsceneTwoToWorldThree()
    {
        StartMenu.SetActive(false);
        WorldThreeCutsceneTransition.SetActive(true);
        WorldThreeCutscenetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldThreeCutsceneTransition.SetActive(false);
        CutSceneTwo.SetActive(false);
        WorldThree.SetActive(true);
        WorldThreeTransition.SetActive(true);
        WorldThreetransition.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        WorldThreeTransition.SetActive(false);
        World = 3;
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
