using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Solution : MonoBehaviour
{

    public int world;
    public int level;
    public int[][][] WorldLevelScore;
    public float NumbersSolution;
    public int EatenNumberCounter;
    public GameObject ZeroLeft;
    public GameObject ZeroRight;

    public int FirstStar;
    public int SecondStar;
    public int ThirdStar;

    public int StarScore = 0;

    public SpriteRenderer StarOne;
    public SpriteRenderer StarTwo;
    public SpriteRenderer StarThree;
    public Sprite YellowStar;

    public TMP_Text EatenCounter;


    public bool BiggerAs;
    public bool BiggerAndEqualAs;
    public bool SmallerAs;
    public bool SmallerAndEqualAs;
    public bool Equal;

    public bool Win;

    public float[] TermWerte;


    public bool LevelFinished;

    public GameObject Particles;
    public bool PlayParticle = true;
    public GameObject Pause;
    public GameObject[] Buttons;
    public GameObject PauseButton;
    public AudioSource XBertTeleport;
    public GameObject Xbert;

    public GameObject Level;
    public GameObject LevelComplete;
    public bool Spin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = NumbersSolution.ToString();

        EatenCounter.text = EatenNumberCounter.ToString();


        
        Compare();

        



        

       

        if(NumbersSolution != 0)
        {
            ZeroRight.SetActive(false);
        }
    }

    public void Compare(){
        if(BiggerAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution > TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }

        if(BiggerAndEqualAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution >= TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }


        if(SmallerAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution < TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }


        if(SmallerAndEqualAs == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution <= TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }

        if(Equal == true)
        {
            foreach (float TermWert in TermWerte)
            {
                if(NumbersSolution == TermWert)
                {
                    StartCoroutine(WinningTime());
                }
            }
        }
    }


    public void Stars(){

        if(EatenNumberCounter <= ThirdStar)
        {
            StarThree.sprite = YellowStar;
            Debug.Log("3 star"+ EatenNumberCounter + " " + ThirdStar);
            StarScore = 3;
        }
        if(EatenNumberCounter <= SecondStar)
        {
            StarTwo.sprite = YellowStar;
            StarScore = 2;
        }

         if(EatenNumberCounter <= FirstStar)
        {
            StarOne.sprite = YellowStar;
            //new int [world][level][StarScore];
        }

        
        
    }




    public IEnumerator WinningTime () {

        if (LevelFinished == false) {

            Stars();

            Pause.GetComponent<PauseScript>().SpaceBool = false;
            LevelFinished = true;

            PauseButton.GetComponent<Button>().interactable = false;

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(false);
            }
            PauseButton.GetComponent<Button>().interactable = false;
            XBertTeleport.Play();


            yield return new WaitForSeconds (1.0f);

            Particles.transform.SetParent (null);

            if (PlayParticle) {
                Particles.GetComponent<ParticleSystem> ().Play ();
                PlayParticle = false;
            }

            Xbert.SetActive (false);

            yield return new WaitForSeconds (0.5f);



            Pause.GetComponent<PauseScript> ().Complete = true;

            yield return new WaitForSeconds (1.0f);

            Xbert.transform.Rotate (Vector3.forward * 0);

            Level.SetActive (false);
            LevelComplete.SetActive (true);

            Particles.GetComponent<ParticleSystem> ().Stop ();

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(true);
            }
            PauseButton.GetComponent<Button>().interactable = true;

            // Spin = true;

            PlayParticle = true;

        }

    }



}
