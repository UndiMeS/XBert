using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SolutionNumbers : MonoBehaviour {

    public float Solution;

    public GameObject Level;
    public GameObject LevelComplete;
    public int EatenNumberCounter;
    public bool spinOne = false;
    public GameObject Xbert;
    public bool LevelFinished;
    public GameObject Particles;
    public bool PlayParticle = true;
    public GameObject Pause;
    public GameObject[] Buttons;
    public GameObject PauseButton;
    public AudioSource XBertTeleport;
    bool BoolSpace;

    // Start is called before the first frame update
    void Start () {

        BoolSpace = Pause.GetComponent<PauseScript>().SpaceBool;
    }

    // Update is called once per frame
    void Update () {

        StartCoroutine (WinningTime ());

    }

    public IEnumerator WinningTime () {

        if (Solution >= 10.0f && LevelFinished == false) {

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

            Solution = 0;

            spinOne = true;

            PlayParticle = true;

        }

    }


}