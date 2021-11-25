using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SolutionNumbers : MonoBehaviour {
    public float NumbersSolution;

    public float VariableSolution;

    public float Solution;

    public GameObject LevelOne;
    public GameObject LevelOneComplete;
    public int EatenNumberCounter;

    public bool spinOne = false;
    public bool spinTwo = false;
    public bool spinThree = false;

    public GameObject FinalScreen;

    public GameObject LevelTwo;

    public GameObject LevelThree;

    public GameObject Xbert;
    public float speed = 50.0f;

    public bool LevelOneFinished;
    public bool LevelTwoFinished;
    public bool LevelThreeFinished;

    public GameObject Particles;
    public bool PlayParticle = true;

    public float rotationSpeed = 10.0f;


    public GameObject Pause;

    public SpriteRenderer SolutionSprite;
    public Sprite SolutionQ;
    public Sprite SolutionEmpty;

    public GameObject[] Buttons;
    public GameObject PauseButton;

    public AudioSource XBertTeleport;

    public int WinCount = 0;

    bool BoolSpace;

    Vector3 destination = new Vector3 (0, 0, 359);
    // Start is called before the first frame update
    void Start () {
        //Particles.GetComponent<ParticleSystem>().Stop();

        BoolSpace = Pause.GetComponent<PauseScript>().SpaceBool;
    }

    // Update is called once per frame
    void Update () {

        if (VariableSolution != 0) {
            Solution = NumbersSolution / VariableSolution;
        }

        if (VariableSolution == 0 && NumbersSolution == 0) {
            GetComponent<TMP_Text> ().text = "";
            SolutionSprite.sprite = SolutionQ;
        }
        if (VariableSolution == 0 && NumbersSolution != 0) {
            GetComponent<TMP_Text> ().text = "";
            SolutionSprite.sprite = SolutionEmpty;
        }
        if (VariableSolution != 0 && NumbersSolution != 0) {
            GetComponent<TMP_Text> ().text = "x = " + Solution.ToString ();
            SolutionSprite.sprite = null;
        }
        if (VariableSolution != 0 && NumbersSolution == 0) {
            GetComponent<TMP_Text> ().text = "x = " + Solution.ToString ();
            SolutionSprite.sprite = null;
        }
        // if(Solution >= 10.0f && LevelOneFinished == false)
        // {
        //     LevelOne.SetActive(false);
        //     LevelOneComplete.SetActive(true);
        //     Solution = 0.0f;
        //     LevelOneFinished = true; 
        // }

        // if(LevelOneFinished == true && LevelTwoFinished == false && Solution < 0.0f)
        // {
        //     LevelOne.SetActive(false);
        //     LevelOneComplete.SetActive(true);
        //     Solution = 0.0f;
        //     LevelTwoFinished = true; 
        // }

        // if(LevelTwoFinished == true && Solution < -100.0f)
        // {
        //     LevelOne.SetActive(false);
        //     LevelOneComplete.SetActive(true);
        //     Solution = 0.0f;
        //     LevelThreeFinished = true; 
        // }


        // if(Solution >= 10.0f)
        // {
        //     while(Pause.GetComponent<PauseScript> ().CompleteOne == false)
        //     {
        //         Xbert.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        //     }
            

        //     //Xbert.GetComponent<Rigidbody2D>().AddTorque(10 * Time.deltaTime* rotationSpeed);
        // }

        


        StartCoroutine (WinningTime ());

    }

    public IEnumerator WinningTime () {

        if (Solution >= 10.0f && LevelOneFinished == false) {

            Pause.GetComponent<PauseScript>().SpaceBool = false;
            LevelOneFinished = true;

            PauseButton.GetComponent<Button>().interactable = false;

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(false);
            }
            PauseButton.GetComponent<Button>().interactable = false;
            XBertTeleport.Play();
            


            //Xbert.transform.Rotate(Vector3.forward * speed * Time.deltaTime);

            // Xbert.GetComponent<Animator>().applyRootMotion = false;

            // Xbert.GetComponent<Animator>().SetBool("SpinTrigger", true);


            yield return new WaitForSeconds (1.0f);

            Particles.transform.SetParent (null);

            if (PlayParticle) {
                Particles.GetComponent<ParticleSystem> ().Play ();
                PlayParticle = false;
            }


            // Xbert.GetComponent<Animator>().SetBool("SpinTrigger", false);
            // Xbert.GetComponent<Animator>().applyRootMotion = true;

            Xbert.SetActive (false);

            yield return new WaitForSeconds (0.5f);



            Pause.GetComponent<PauseScript> ().CompleteOne = true;

            yield return new WaitForSeconds (1.0f);

            Xbert.transform.Rotate (Vector3.forward * 0);
            //Xbert.SetActive(true);

            LevelOne.SetActive (false);
            LevelOneComplete.SetActive (true);

            Particles.GetComponent<ParticleSystem> ().Stop ();

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(true);
            }
            PauseButton.GetComponent<Button>().interactable = true;

            Solution = 0;

            spinOne = true;

            PlayParticle = true;

        }

        if (LevelOneFinished == true && LevelTwoFinished == false && Solution <= -10.0f) {

            Pause.GetComponent<PauseScript>().SpaceBool = false;
            LevelTwoFinished = true;
            

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(false);
            }
            PauseButton.GetComponent<Button>().interactable = false;

            XBertTeleport.Play();

            // Xbert.GetComponent<Animator>().applyRootMotion = false;

            // Xbert.GetComponent<Animator>().SetBool("SpinTrigger", true);


            yield return new WaitForSeconds (1.0f);

            Particles.transform.SetParent (null);

            if (PlayParticle) {
                Particles.GetComponent<ParticleSystem> ().Play ();
                PlayParticle = false;
            }

            // Xbert.GetComponent<Animator>().SetBool("SpinTrigger", false);
            // Xbert.GetComponent<Animator>().applyRootMotion = true;

            Xbert.SetActive (false);

            yield return new WaitForSeconds (0.5f);

            

            Pause.GetComponent<PauseScript> ().CompleteTwo = true;

            yield return new WaitForSeconds (1.0f);

            Xbert.transform.Rotate (Vector3.forward * 0);
            //Xbert.SetActive(true);

            LevelTwo.SetActive (false);
            LevelOneComplete.SetActive (true);

            spinTwo = true;

            PlayParticle = true;

            Particles.GetComponent<ParticleSystem> ().Stop ();

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(true);
            }
            PauseButton.GetComponent<Button>().interactable = true;

            Solution =0;
            NumbersSolution = 0;
            VariableSolution = 0;


        }

        if (LevelTwoFinished == true && Solution >= 10.0f && WinCount == 0) {

             WinCount = 1;
             Pause.GetComponent<PauseScript>().SpaceBool = false;

            LevelThreeFinished = true;

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(false);
            }
            PauseButton.GetComponent<Button>().interactable = false;

            

            

            // Xbert.GetComponent<Animator>().applyRootMotion = false;

            // Xbert.GetComponent<Animator>().SetBool("SpinTrigger", true);

            for(int x = 0; x< 1; x++)
            {
                XBertTeleport.Play();
            }

            

            yield return new WaitForSeconds (1.0f);

            Particles.transform.SetParent (null);

            if (PlayParticle) {
                Particles.GetComponent<ParticleSystem> ().Play ();
                PlayParticle = false;
            }

            // Xbert.GetComponent<Animator>().SetBool("SpinTrigger", false);
            // Xbert.GetComponent<Animator>().applyRootMotion = true;

            Xbert.SetActive (false);

            yield return new WaitForSeconds (0.5f);

            

            Pause.GetComponent<PauseScript> ().CompleteThree = true;

            Solution = 0;

            yield return new WaitForSeconds (1.0f);

            Xbert.transform.Rotate (Vector3.forward * 0);
            //Xbert.SetActive(true);

            LevelThree.SetActive (false);
            LevelOneComplete.SetActive (true);

            spinThree = true;
            PlayParticle = true;

            Particles.GetComponent<ParticleSystem> ().Stop ();

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(true);
            }
            PauseButton.GetComponent<Button>().interactable = true;

           


        }

    }


}