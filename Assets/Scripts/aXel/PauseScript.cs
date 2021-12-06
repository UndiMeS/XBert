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
    public GameObject NumberSolution;
    public GameObject SubmitMenu;
    public GameObject StartMenu;
    public GameObject LevelComplete;
    public GameObject Solution;

    public GameObject Particle;

    public GameObject _TermLeft;
    public GameObject _TermRight;
    public Transform _MovePosition;
    public bool Complete;
    public GameObject AxelGame;

    public GameObject SolutionScript;

    public bool Finished;

    public GameObject GameText;
    public GameObject EqualSign;
    public GameObject StartScreen;

    public Button PauseButton;

    AudioSource BackgroundMusic;

    public bool SpaceBool;

    public float startVolume;


    

    public Button NextLevelButton;
    // Start is called before the first frame update


    void Start()
    {

        BackgroundMusic = this.gameObject.GetComponent<AudioSource>();

        startVolume = BackgroundMusic.volume;


        PauseMenu.SetActive(false);
        SubmitMenu.SetActive(false);
        LevelComplete.SetActive(false);
        Level.SetActive(true);

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

         if(Complete == true )
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
        PauseMenu.SetActive(true);
        Controler.SetActive(false);
        Axel.SetActive(false);
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
            PauseMenu.SetActive(false);
            Controler.SetActive(true);
            Axel.SetActive(true);
            SpaceBool = true;
        }



    }

    public void Restart()
    {
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

    }

    public void ReturnToCompleteLevel()
    {
        SubmitMenu.SetActive(false);
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
