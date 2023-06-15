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
    public GameObject StartMenu;
    public GameObject LevelComplete;
    public string NextScene;
    public bool Complete;

    public GameObject SolutionScript;

    public bool Finished;

    public GameObject StartScreen;

    public Button PauseButton;
    public Button PauseWeiterButton;

    AudioSource BackgroundMusic;

    public bool SpaceBool = true;

    public float startVolume;
    public bool ShadowNextLevel;

    public Solution solution;

    public Button NextLevelButton;

    public LevelLoader lvlLoader;



    // Start is called before the first frame update


    void Start()
    {

        solution = SolutionScript.GetComponent<Solution>();

        BackgroundMusic = this.gameObject.GetComponent<AudioSource>();

        startVolume = BackgroundMusic.volume;


        PauseMenu.SetActive(false);
        LevelComplete.SetActive(false);
        Level.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
         Finished = SolutionScript.GetComponent<Solution>().LevelFinished;

         if(SolutionScript.GetComponent<Solution>().NextShadowLevel == true)
         {
             ShadowNextLevel = true;
         }

        if(SpaceBool == true && LevelComplete.activeSelf == false){
                if (Input.GetKeyDown("space"))
            {
                
                PauseButton.onClick.Invoke();
                SpaceBool = false;
            }
        }

        if(SpaceBool == false && LevelComplete.activeSelf == false && PauseMenu.activeSelf == true){
                if (Input.GetKeyDown("space"))
            {
                
                PauseWeiterButton.onClick.Invoke();
                SpaceBool = true;
            }
        }

        if(LevelComplete.activeSelf == true)
        {
            if(Input.GetKeyDown("space") || Input.GetKeyDown("return"))
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        lvlLoader.ActvateTransition();

        lvlLoader.LoadScene = SceneManager.GetActiveScene().name;
    }

    public void Quit()
    {
        PauseMenu.SetActive(false);
        LevelComplete.SetActive(false);
        SpaceBool = false;
    }

    public void ToPause()
    {
        Level.SetActive(false);
        PauseMenu.SetActive(true);

    }


    public void ToMainMenu()
    {
        //SceneManager.LoadScene("XBert_MainMenu");
        MenuButtonManager.World = SolutionScript.GetComponent<Solution>().world;

        if(PlayerPrefs.GetInt("intro") == 2 || PlayerPrefs.GetInt("intro") == 4)
        {
            MenuButtonManager.World += 1;
        }
        
        lvlLoader.ActvateTransition();
        lvlLoader.LoadScene = "XBert_MainMenu";
    }

    public void LoadNextLevel()
    {
        


        lvlLoader.ActvateTransition();

        if(solution.oneLevelSuccess == 1 || solution.firstThreeStars == 1 || solution.gameFinished == 1 || solution.gameComplete == 1)
        {
            lvlLoader.LoadScene = "XBert_MainMenu";
        }
        else
        {
            lvlLoader.LoadScene = NextScene;
        }
        
    }

    public void NextShadowLevelButton()
    {
        if(ShadowNextLevel == true)
        {
            lvlLoader.ActvateTransition();
            //SceneManager.LoadScene(NextScene);
            lvlLoader.LoadScene = NextScene;
        }
        else
        {
            lvlLoader.ActvateTransition();
            //SceneManager.LoadScene("XBert_MainMenu");
            lvlLoader.LoadScene = "XBert_MainMenu";
        }
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
