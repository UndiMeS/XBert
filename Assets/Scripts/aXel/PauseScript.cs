using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{

    public GameObject LevelOne;
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
    public GameObject SubmitRestartOne;
    public GameObject LevelOneComplete;
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

    public bool OneFinished;

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
        SubmitRestartOne.SetActive(false);
        LevelOneComplete.SetActive(false);
        LevelOne.SetActive(true);
        LevelTwo.SetActive(false);
        LevelThree.SetActive(false);
        FinalScreen.SetActive(false);

        //StartCoroutine(IntroScreen());
        //StartMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
         OneFinished = SolutionScript.GetComponent<SolutionNumbers>().LevelOneFinished;
         CompleteOne = SolutionScript.GetComponent<SolutionNumbers>().LevelOneFinished;
         CompleteTwo = SolutionScript.GetComponent<SolutionNumbers>().LevelTwoFinished;
         CompleteThree = SolutionScript.GetComponent<SolutionNumbers>().LevelThreeFinished;

        if(SpaceBool == true && LevelOneComplete.activeSelf == false){
                if (Input.GetKeyDown("space"))
            {
                PauseButton.onClick.Invoke();
            }
        }

        if(LevelOneComplete.activeSelf == true)
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
        LevelOne.SetActive(true);
        SpaceBool = true;
        BackgroundMusic.Play();
        Axel.SetActive(true);
        Controler.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void Menu()
    {
        SpaceBool = false;
        LevelOne.SetActive(false);
        SubmitMenu.SetActive(false);
        //SubmitRestart.SetActive(false);
        SubmitRestartOne.SetActive(false);
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

    public void HelpMenuTwo()
    {
        SpaceBool = false;
        PauseMenu.SetActive(false);
        HelpOne.SetActive(false);
        HelpTwo.SetActive(true);
        HelpThree.SetActive(false);
    }

        public void HelpMenuThree()
    {
        SpaceBool = false;
        PauseMenu.SetActive(false);
        HelpTwo.SetActive(false);
        HelpThree.SetActive(true);
        HelpFour.SetActive(false);
    }

        public void HelpMenuFour()
    {
        SpaceBool = false;
        PauseMenu.SetActive(false);
        HelpFour.SetActive(true);
        HelpThree.SetActive(false);
    }

    public void CloseMenu()
    {
        if(OneFinished == false)
        {
            LevelOne.SetActive(true);
            PauseMenu.SetActive(false);
            Controler.SetActive(true);
            Axel.SetActive(true);
            SpaceBool = true;
        }

        if(OneFinished == true)
        {
            LevelTwo.SetActive(true);
            PauseMenu.SetActive(false);
            Controler.SetActive(true);
            Axel.SetActive(true);
            SpaceBool = true;
        }

        // if(OneFinished == true && CompleteTwo == true)
        // {
        //     LevelThree.SetActive(true);
        //     PauseMenu.SetActive(false);
        //     Controler.SetActive(true);
        //     Axel.SetActive(true);
        //     SpaceBool = true;
        // }



    }

    public void SubmitRestart()
    {
        PauseMenu.SetActive(false);
        SubmitRestartOne.SetActive(true);
        SpaceBool = false;
    }

    public void RestartOne()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if(OneFinished == false)
        {
            foreach (Transform child in leftOne)
            {
                child.gameObject.SetActive(true);
                //child.GetComponent<aXelNumber>().value = 0;

            }

            foreach (Transform child in rightOne)
            {
                child.gameObject.SetActive(true);
                //child.GetComponent<aXelNumber>().value = 0;

            }


                LeftZeroOne.SetActive(true);
                RightZeroOne.SetActive(true);

                LevelOne.SetActive(true);
                PauseMenu.SetActive(false);
                Controler.SetActive(true);
                Axel.SetActive(true);
                SubmitRestartOne.SetActive(false);
                SpaceBool = true;

          

           
            }

            if(OneFinished == true && CompleteTwo == false)
        {
            foreach (Transform child in leftTwo)
            {
                child.gameObject.SetActive(true);
                //child.GetComponent<aXelNumber>().value = 0;

            }

            foreach (Transform child in rightTwo)
            {
                child.gameObject.SetActive(true);
                //child.GetComponent<aXelNumber>().value = 0;

            }
            LeftZeroOne.SetActive(true);
            RightZeroOne.SetActive(true);

            LevelTwo.SetActive(true);
            PauseMenu.SetActive(false);
            Controler.SetActive(true);
            Axel.SetActive(true);
            SubmitRestartOne.SetActive(false);
            SpaceBool = true;

           
            }
            if(CompleteTwo == true && CompleteThree == false)
        {
            foreach (Transform child in leftThree)
            {
                child.gameObject.SetActive(true);
                //child.GetComponent<aXelNumber>().value = 0;

            }

            foreach (Transform child in rightThree)
            {
                child.gameObject.SetActive(true);
                //child.GetComponent<aXelNumber>().value = 0;

            }
            LeftZeroOne.SetActive(true);
            RightZeroOne.SetActive(true);

            LevelThree.SetActive(true);
            PauseMenu.SetActive(false);
            Controler.SetActive(true);
            Axel.SetActive(true);
            SubmitRestartOne.SetActive(false);
            SpaceBool = true;

           
            }

            Axel.transform.position = Axel.GetComponent<PlayerMovement>().StartPosition;
            _MovePosition.position = Axel.GetComponent<PlayerMovement>().StartPosition;
            // Axel.GetComponent<PlayerMovement>().targetposition = new Vector3 (-3.0f, -43.0f, 0.0f);
            Axel.transform.rotation = Axel.GetComponent<PlayerMovement>().StartRotation;

             GameObject.Find("Term_Left").GetComponent<TMP_Text>().text = " ";
            GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = " ";




                 NumberSolution.GetComponent<SolutionNumbers>().NumbersSolution = 0;
                 NumberSolution.GetComponent<SolutionNumbers>().VariableSolution = 0;
                NumberSolution.GetComponent<SolutionNumbers>().Solution = 0;
                 NumberSolution.GetComponent<SolutionNumbers>().EatenNumberCounter = 0;
        
    }

    public void Quit()
    {
        PauseMenu.SetActive(false);
        LevelOneComplete.SetActive(false);
        SubmitMenu.SetActive(true);
        SpaceBool = false;
    }

    public void FinalQuit()
    {
        AxelGame.SetActive(false);

        FinishedArcadeButton.SetActive(true);
        StartArcadeButton.SetActive(false);

        InventoryArrowUp.SetActive(true);

        ArcadeRoom.SetActive(true);
    }

    public void ReallyQuit()
    {
        //Application.Quit();
        Axel.transform.position = Axel.GetComponent<PlayerMovement>().StartPosition;
        _MovePosition.position = Axel.GetComponent<PlayerMovement>().StartPosition;
        
        InventoryArrowUp.SetActive(true);
        

        NumberSolution.GetComponent<SolutionNumbers>().NumbersSolution = 0;
        NumberSolution.GetComponent<SolutionNumbers>().VariableSolution = 0;
        NumberSolution.GetComponent<SolutionNumbers>().Solution = 0;
        NumberSolution.GetComponent<SolutionNumbers>().EatenNumberCounter = 0;


        SolutionScript.GetComponent<SolutionNumbers>().LevelOneFinished = false;
         SolutionScript.GetComponent<SolutionNumbers>().LevelOneFinished = false;
         SolutionScript.GetComponent<SolutionNumbers>().LevelTwoFinished = false;
         SolutionScript.GetComponent<SolutionNumbers>().LevelThreeFinished = false;


        if(GameObject.Find("Term_Left").GetComponent<TMP_Text>().text != null && GameObject.Find("Term_Right").GetComponent<TMP_Text>().text != null)
        {
            GameObject.Find("Term_Left").GetComponent<TMP_Text>().text = " ";
            GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = " ";
        }
        //GameObject.Find("Term_Left").GetComponent<TMP_Text>().text = " ";
        //GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = " ";

        _TermLeft.GetComponent<TMP_Text>().color = new Color32(183, 0, 0, 255);
        _TermRight.GetComponent<TMP_Text>().color = new Color32(51, 67, 44, 255);

        LeftZeroOne.SetActive(true);
        RightZeroOne.SetActive(true);

        LeftZeroOne.GetComponent<TMP_Text>().color = new Color32(183, 0, 0, 255);
        RightZeroOne.GetComponent<TMP_Text>().color = new Color32(51, 67, 44, 255);

            foreach (Transform child in leftOne)
            {
                child.gameObject.SetActive(true);
            }

            foreach (Transform child in rightOne)
            {
                child.gameObject.SetActive(true);
            }


            foreach (Transform child in leftTwo)
            {
                child.gameObject.SetActive(true);
            }

            foreach (Transform child in rightTwo)
            {
                child.gameObject.SetActive(true);
            }


            foreach (Transform child in leftThree)
            {
                child.gameObject.SetActive(true);
            }

            foreach (Transform child in rightThree)
            {
                child.gameObject.SetActive(true);
            }

        PauseMenu.SetActive(false);
        SubmitMenu.SetActive(false);
        SubmitRestartOne.SetActive(false);
        LevelOneComplete.SetActive(false);
        Axel.SetActive(false);

        LevelOne.SetActive(false);
        LevelTwo.SetActive(false);
        LevelThree.SetActive(false);

        OneFinished = false;

        CompleteOne = false;
        CompleteTwo = false;
        CompleteThree = false;

        AxelGame.SetActive(false);

        ArcadeRoom.SetActive(true);

    }

    public void ReturnToPause()
    {
        PauseMenu.SetActive(true);
        SubmitMenu.SetActive(false);
        SubmitRestartOne.SetActive(false);
        HelpOne.SetActive(false);
        HelpTwo.SetActive(false);
        HelpThree.SetActive(false);
        HelpFour.SetActive(false);

    }

    public void LevelClearQuit()
    {

    }

    public void ReturnToCompleteLevel()
    {
        SubmitMenu.SetActive(false);
        SubmitRestartOne.SetActive(false);
    }

    public void StartLevelTwo()
    {

        // CompleteOne = SolutionScript.GetComponent<SolutionNumbers>().LevelOneFinished;
        // CompleteTwo = SolutionScript.GetComponent<SolutionNumbers>().LevelTwoFinished;
        // CompleteThree = SolutionScript.GetComponent<SolutionNumbers>().LevelThreeFinished;
        
        NumberSolution.GetComponent<SolutionNumbers>().Solution = 0;

        Axel.SetActive(true);
        Particle.transform.position = Axel.transform.position;
        Particle.transform.SetParent(Axel.transform);
        LevelOneComplete.SetActive(false);

        //SpaceBool = false;



        if(CompleteOne == true && CompleteTwo == false && CompleteThree == false)
        {
            //SpaceBool = true;
            // TaskOne.SetActive(false);
            // TaskTwo.SetActive(true);
            //TaskThree.SetActive(false);#

            //SpaceBool = false;
            SpaceBool = true;
            
            LevelOne.SetActive(false);
            LevelTwo.SetActive(true);
            LevelThree.SetActive(false);
            PauseMenu.SetActive(false);
            SubmitRestartOne.SetActive(false);
            SubmitMenu.SetActive(false);

            

            

            _TermLeft.GetComponent<TMP_Text>().color = new Color32(46, 63, 77, 255);
            _TermRight.GetComponent<TMP_Text>().color = new Color32(119, 61, 0, 255);

            LeftZeroOne.SetActive(true);
            RightZeroOne.SetActive(true);

            LeftZeroOne.GetComponent<TMP_Text>().color = new Color32(46, 63, 77, 255);
            RightZeroOne.GetComponent<TMP_Text>().color = new Color32(119, 61, 0, 255);
        }

        if(CompleteTwo == true && CompleteThree == false)
        {

            //SpaceBool = false;
            // TaskTwo.SetActive(false);
            // TaskOne.SetActive(false);
            //TaskThree.SetActive(true);
            LevelOneComplete.SetActive(false);
            LevelTwo.SetActive(false);
            LevelThree.SetActive(true);
            PauseMenu.SetActive(false);
            SubmitRestartOne.SetActive(false);
            SubmitMenu.SetActive(false);

            SpaceBool = true;

            _TermLeft.GetComponent<TMP_Text>().color = new Color32(108, 72, 53, 255);
            _TermRight.GetComponent<TMP_Text>().color = new Color32(91, 91, 91, 255);

            LeftZeroOne.SetActive(true);
            RightZeroOne.SetActive(true);

            LeftZeroOne.GetComponent<TMP_Text>().color = new Color32(108, 72, 53, 255);
            RightZeroOne.GetComponent<TMP_Text>().color = new Color32(91, 91, 91, 255);
        }
        if(CompleteOne == true && CompleteTwo == true && CompleteThree == true)
        {


            
            SpaceBool = false;
            //SpaceBool = false;
            Debug.Log("Winner");
            Controler.SetActive(false);
            FinalScreen.SetActive(true);
            LevelThree.SetActive(false);
            BackgroundMusic.Stop();
            
            Axel.SetActive(false);
            LevelOneComplete.SetActive(false);
            FinalPyramid.SetActive(true);
            GameText.SetActive(false);
            EqualSign.SetActive(false);
            PauseMenu.SetActive(false);
        }





            Axel.transform.position = Axel.GetComponent<PlayerMovement>().StartPosition;
            _MovePosition.position = Axel.GetComponent<PlayerMovement>().StartPosition;
            // Axel.GetComponent<PlayerMovement>().targetposition = new Vector3 (-3.0f, -43.0f, 0.0f);
            Axel.transform.rotation = Axel.GetComponent<PlayerMovement>().StartRotation;

            if(GameObject.Find("Term_Left") != null)
            {
                GameObject.Find("Term_Left").GetComponent<TMP_Text>().text = " ";
            }
            
            if(GameObject.Find("Term_Right") != null)
            {
                GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = " ";
            }
            
            NumberSolution.GetComponent<SolutionNumbers>().NumbersSolution = 0;
            NumberSolution.GetComponent<SolutionNumbers>().VariableSolution = 0;
                
            NumberSolution.GetComponent<SolutionNumbers>().EatenNumberCounter = 0;
        

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
