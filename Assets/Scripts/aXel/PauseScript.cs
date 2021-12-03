using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{

    public GameObject Level;
    public GameObject PauseMenu;
    public GameObject Controler;
    public GameObject Axel;
    public Transform leftOne;
    public Transform rightOne;
    public Transform leftTwo;
    public Transform rightTwo;
    public Transform leftThree;
    public Transform rightThree;
    public GameObject LeftZeroOne;
    public GameObject RightZeroOne;
    public GameObject LeftZeroTwo;
    public GameObject RightZeroTwo;
    public GameObject LeftZeroThree;
    public GameObject RightZeroThree;
    public GameObject NumberSolution;
    public GameObject SubmitMenu;
    public GameObject StartMenu;
    public GameObject SubmitRestart;
    public GameObject LevelComplete;
    public GameObject LevelTwo;
    public GameObject Solution;
    public GameObject LevelThree;
    public GameObject TaskOne;
    public GameObject TaskTwo;
    public GameObject TaskThree;

    public GameObject Particle;

    public GameObject _TermLeft;
    public GameObject _TermRight;

    public GameObject FinalScreen;

    public Transform _MovePosition;
    public bool CompleteOne;
    public bool CompleteTwo;
    public bool CompleteThree;
    public GameObject AxelGame;
    public GameObject ArcadeRoom;

    public GameObject SolutionScript;

    public GameObject FinalPyramid;

    public bool Finished;

    public GameObject GameText;
    public GameObject EqualSign;
    public GameObject Inventory;
    public GameObject StartScreen;
    public GameObject FinishedArcadeButton;
    public GameObject StartArcadeButton;

    public GameObject InventoryArrowUp;

    public Button PauseButton;

    AudioSource BackgroundMusic;

    public bool SpaceBool;

    public float startVolume;


    
    public GameObject HelpOne;
    public GameObject HelpTwo;
    public GameObject HelpThree;
    public GameObject HelpFour;

    public Button NextLevelButton;
    // Start is called before the first frame update


    void Start()
    {

        BackgroundMusic = this.gameObject.GetComponent<AudioSource>();

        startVolume = BackgroundMusic.volume;


        PauseMenu.SetActive(false);
        SubmitMenu.SetActive(false);
        SubmitRestart.SetActive(false);
        LevelComplete.SetActive(false);
        Level.SetActive(true);

        FinalScreen.SetActive(false);

        //StartCoroutine(IntroScreen());
        //StartMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
         Finished = SolutionScript.GetComponent<SolutionNumbers>().LevelFinished;

        if(SpaceBool == true && LevelComplete.activeSelf == false){
                if (Input.GetKeyDown("space"))
            {
                PauseButton.onClick.Invoke();
            }
        }

        if(LevelComplete.activeSelf == true)
        {
            if(Input.GetKeyDown("space"))
            {
                NextLevelButton.onClick.Invoke();
            }
        }

         if(CompleteOne == true && CompleteTwo == true && CompleteThree == true)
        {


            StartCoroutine(FadeOut(BackgroundMusic, 400.0f));


    }

    }


    IEnumerator IntroScreen()
    {
        StartMenu.SetActive(false);
        StartScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        StartScreen.SetActive(false);
        StartMenu.SetActive(true);
    }
    public void StartGame()
    {
        Level.SetActive(true);
        SpaceBool = true;
        BackgroundMusic.Play();
        Axel.SetActive(true);
        Controler.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void Menu()
    {
        SpaceBool = false;
        Level.SetActive(false);
        SubmitMenu.SetActive(false);
        //SubmitRestart.SetActive(false);
        SubmitRestart.SetActive(false);
        PauseMenu.SetActive(true);
        Controler.SetActive(false);
        Axel.SetActive(false);
    }

    public void HelpMenuOne()
    {
        SpaceBool = false;
        PauseMenu.SetActive(false);
        HelpOne.SetActive(true);
        HelpTwo.SetActive(false);
    }

    public void CloseMenu()
    {
        if(Finished == false)
        {
            Level.SetActive(true);
            PauseMenu.SetActive(false);
            Controler.SetActive(true);
            Axel.SetActive(true);
            SpaceBool = true;
        }

        if(Finished == true)
        {
            LevelTwo.SetActive(true);
            PauseMenu.SetActive(false);
            Controler.SetActive(true);
            Axel.SetActive(true);
            SpaceBool = true;
        }



    }

    public void RestartSubmit()
    {
        PauseMenu.SetActive(false);
        SubmitRestart.SetActive(true);
        SpaceBool = false;
    }

    public void Restart()
    {

        // GameObject.Find("Term_Left").GetComponent<TMP_Text>().text = " ";
        // GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = " ";




        // NumberSolution.GetComponent<SolutionNumbers>().NumbersSolution = 0;
        // NumberSolution.GetComponent<SolutionNumbers>().VariableSolution = 0;
        // NumberSolution.GetComponent<SolutionNumbers>().Solution = 0;
        // NumberSolution.GetComponent<SolutionNumbers>().EatenNumberCounter = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

             
        
    }

    public void Quit()
    {
        PauseMenu.SetActive(false);
        LevelComplete.SetActive(false);
        SubmitMenu.SetActive(true);
        SpaceBool = false;
    }

    public void ReallyQuit()
    {
        

    }

    public void ReturnToPause()
    {
        PauseMenu.SetActive(true);
        SubmitMenu.SetActive(false);
        SubmitRestart.SetActive(false);
        HelpOne.SetActive(false);
        HelpTwo.SetActive(false);
        HelpThree.SetActive(false);
        HelpFour.SetActive(false);

    }

    public void ReturnToCompleteLevel()
    {
        SubmitMenu.SetActive(false);
        SubmitRestart.SetActive(false);
    }

    
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
    }

}
