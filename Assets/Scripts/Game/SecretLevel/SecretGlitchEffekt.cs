using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class SecretGlitchEffekt : MonoBehaviour
{
    public GameObject SecondCamera;

    public float ScanLineJitterNumber;
    public float VerticalJumpNumber;
    public float HorizontalShakeNumber;
    public float ColorDriftNumber;
    public float DigitalGlitchNumber;

    public DigitalGlitch digitalGlitch;
    public AnalogGlitch analogGlitch;

    public GameObject WhiteNoiseBanner;


    public DialogueManager dialogueManager;
    public DialogueVertexAnimator dialogueVertexAnimator;
    public int dialogueNumber;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        digitalGlitch.intensity = 0;
        analogGlitch.scanLineJitter = 0;
        analogGlitch.verticalJump = 0;
        analogGlitch.horizontalShake = 0;
        analogGlitch.colorDrift = 0;

        SecondCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.finishedAnimating[dialogueNumber-1] == true)
        {
            //Debug.Log("Dialogue finished" + dialogueNumber);
            StartCoroutine(EndGlitchTrigger());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Axel")
        {
            StartCoroutine(GlitchTrigger());
        }
    }

    public IEnumerator GlitchTrigger()
    {
        WhiteNoiseBanner.SetActive(true);
        

        //yield return new WaitForSeconds(0.06f);

        playerMovement.enabled = false;

        yield return new WaitForSeconds(1.0f);

        dialogueManager.Invoke("PlayDialogue"+dialogueNumber.ToString(), 0);
        //dialogueManager.PlayDialogue1();
        
    }

    public IEnumerator EndGlitchTrigger()
    {
        yield return new WaitForSeconds(2.0f);

        dialogueManager.textBox[dialogueNumber-1].enabled = false;

        digitalGlitch.intensity = DigitalGlitchNumber;
        analogGlitch.scanLineJitter = ScanLineJitterNumber;
        analogGlitch.verticalJump = VerticalJumpNumber;
        analogGlitch.horizontalShake = HorizontalShakeNumber;
        analogGlitch.colorDrift = ColorDriftNumber;

        WhiteNoiseBanner.SetActive(false);
        playerMovement.enabled = true;

        this.gameObject.SetActive(false);
    }
}
