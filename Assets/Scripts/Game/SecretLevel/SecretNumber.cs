using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Kino;

public class SecretNumber : MonoBehaviour
{

    public GameObject LevelComplete;
    public GameObject LevelCompleteGlitch;
    public GameObject Level;
    public GameObject Xbert;
    public GameObject Pause;
    public GameObject PauseButton;
    public GameObject Particles;
    public AudioSource XBertTeleport;
    public bool PlayParticle = true;
    public GameObject[] Buttons;
    public float speed;
    public bool winning;
    public GameObject DivideZero;

    public DigitalGlitch digitalGlitch;
    public AnalogGlitch analogGlitch;
    public GameObject[] GlitchTriggers;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("SecretSkin") == 1)
        {
            DivideZero.SetActive(false);
            this.gameObject.SetActive(false);
            foreach(GameObject glitchtrigger in GlitchTriggers)
            {
                glitchtrigger.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WinningTime () {
        
        Debug.Log("Winning");

            //Xbert.transform.Rotate(Vector3.forward * speed * Time.deltaTime);

            digitalGlitch.intensity = 0;
            analogGlitch.scanLineJitter = 0;
            analogGlitch.verticalJump = 0;
            analogGlitch.horizontalShake = 0;
            analogGlitch.colorDrift = 0;


            Xbert.gameObject.GetComponent<BoxCollider2D>().enabled = false;


            Pause.GetComponent<PauseScript>().SpaceBool = false;

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
            //winning = false;
            //Xbert.transform.Rotate (Vector3.forward * 0);

            PlayerPrefs.SetInt("SecretSkin",1);

            Level.SetActive (false);
            LevelComplete.SetActive (true);
            LevelCompleteGlitch.SetActive (true);

            Particles.GetComponent<ParticleSystem> ().Stop ();

            foreach (GameObject Button in Buttons)
            {
                Button.SetActive(true);
            }
            PauseButton.GetComponent<Button>().interactable = true;

            // Spin = true;

            PlayParticle = true;


            digitalGlitch.intensity = 0.05f;
            analogGlitch.scanLineJitter = 0.05f;
            analogGlitch.verticalJump = 0.05f;
            analogGlitch.horizontalShake = 0.05f;
            analogGlitch.colorDrift = 0.05f;

        }

        void OnTriggerEnter2D(Collider2D col)
    {

        if(col.transform.gameObject.name =="aXel")
        {
            winning = true;
            DivideZero.SetActive(false);
            StartCoroutine(WinningTime());
        }

    }

    }

