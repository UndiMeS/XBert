using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public bool SceneOneScreenOne = false;
    public bool SceneTwoScreenOne = false;

    public GameObject CutsceneOne;
    public GameObject CutsceneTwo;


    public GameObject PacBertScreenOne;
    public GameObject SwimmRingScreenOne;
    public GameObject SlowWaterScreenOne;
    public GameObject XBertScreenTwo;
    public GameObject BoatScreenTwo;
    public GameObject SpeedWaterScreenTwo;

    public GameObject PacBertScreenThree;
    public GameObject SwimmRingScreenThree;
    public GameObject SlowWaterScreenThree;


    public GameObject RangerBertScreenOne;
    public GameObject NumberThreeScreenOne;
    public GameObject ShovelScreenTwo;


    public GameObject[] Speedlines;
    public GameObject SpeedLineDirection;


    public GameObject ScreenOneTextOne;

    public GameObject ScreenThreeTextOne;

    public GameObject CutsceneTwoScreenOneTextOne;
    public GameObject CutsceneTwoScreenOneTextTwo;

    public GameObject CutsceneTwoScreenTwoTextOne;
    public GameObject CutsceneTwoScreenTwoTextTwo;


    public CutsceneDialogueManager dialogueManager;
    public DialogueVertexAnimator dialogueVertexAnimator;


    public GameObject[] NextScreenButtons;
    public SpriteRenderer[] NextArrowButtons;

    public GameObject[] SpeedUpButtons;


    public static float SpeedWaitMultiplier = 1.0f;


    public float NumberThreeTimer;
    public bool NumberThreeMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(SceneOneScreenOne == false && CutsceneOne.active == true)
        {
            LeanTween.value( gameObject, setArrowSpriteAlpha, 0f, 1f, 1f ).setEaseInOutCubic().setLoopPingPong();
            ScreenOneFunction();

            SceneOneScreenOne = true;
        }

        if(SceneTwoScreenOne == false && CutsceneTwo.active == true)
        {
            LeanTween.value( gameObject, setArrowSpriteAlpha, 0f, 1f, 1f ).setEaseInOutCubic().setLoopPingPong();
            CutsceneTwoScreenOneFunction();

            SceneTwoScreenOne = true;
        }


        if(dialogueManager.finishedAnimating[1] == true)
        {
            
            NextScreenButtons[0].SetActive(true);
            SpeedUpButtons[0].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[2] == true)
        {
            NextScreenButtons[1].SetActive(true);
            SpeedUpButtons[1].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[3] == true)
        {
            NextScreenButtons[2].SetActive(true);
            SpeedUpButtons[2].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[5] == true)
        {
            NextScreenButtons[3].SetActive(true);
            SpeedUpButtons[3].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[8] == true)
        {
            NextScreenButtons[4].SetActive(true);
            SpeedUpButtons[4].SetActive(false);
        }
        
    }

    public void ScreenOneFunction()
    {
        StartCoroutine(CutsceneScreenOneAnimation());
    }

    public void ScreenTwoFunction()
    {
        StartCoroutine(CutsceneScreenTwoAnimation());
    }

    public void ScreenThreeFunction()
    {
        StartCoroutine(CutsceneScreenThreeAnimation());
    }

    public void CutsceneTwoScreenOneFunction()
    {
        StartCoroutine(CutsceneTwoScreenOneAnimation());
    }

    public void CutsceneTwoScreenTwoFunction()
    {
        StartCoroutine(CutsceneTwoScreenTwoAnimation());
    }

    public IEnumerator CutsceneScreenOneAnimation()
    {
        SpeedWaitMultiplier = 0.6f;

        LeanTween.moveY(SlowWaterScreenOne, SlowWaterScreenOne.transform.position.y+0.3f, 0.75f).setEaseInOutSine().setLoopPingPong();

        LeanTween.moveY(SwimmRingScreenOne, SwimmRingScreenOne.transform.position.y-0.1f, 0.75f).setEaseInOutSine().setLoopPingPong();

        yield return new WaitForSeconds(2.0f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue1();
        if(dialogueManager.finishedAnimating[0] == true)
        {
            yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
            Debug.Log("Speeeeeed");
        }

        yield return new WaitForSeconds(2.0f * SpeedWaitMultiplier);

        LeanTween.rotateY(PacBertScreenOne, 180.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();

        

        LeanTween.scale(ScreenOneTextOne, new Vector3(0.4f, 0.4f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue2();

    }

    public IEnumerator CutsceneScreenTwoAnimation()
    {
        LeanTween.moveY(XBertScreenTwo, XBertScreenTwo.transform.position.y+0.1f, 0.3f).setEaseInOutCubic().setLoopPingPong();
        LeanTween.rotateZ(XBertScreenTwo, 2.0f, 0.3f).setEaseInOutCubic().setLoopPingPong();

        LeanTween.rotateZ(BoatScreenTwo, 4.0f, 0.75f).setEaseInOutCubic().setLoopPingPong();

        LeanTween.moveY(SpeedWaterScreenTwo, SpeedWaterScreenTwo.transform.position.y+0.2f, 0.3f).setEaseInOutSine().setLoopPingPong();


        foreach(GameObject Speedline in Speedlines)
        {

            Vector3 Mittelpunkt = Vector3.Lerp(new Vector3(Speedline.transform.position.x, Speedline.transform.position.y, 0.0f), new Vector3(SpeedLineDirection.transform.position.x, SpeedLineDirection.transform.position.y, 0.0f), 0.15f);
            yield return new WaitForSeconds(0.01f);

            LeanTween.move(Speedline,Mittelpunkt, 0.1f).setEaseInOutCubic().setLoopPingPong();
        }
        //yield return new WaitForSeconds(0.1f * SpeedWaitMultiplier);

        dialogueManager.PlayDialogue3();

        
    }
    public IEnumerator CutsceneScreenThreeAnimation()
    {
        LeanTween.moveY(SlowWaterScreenThree, SlowWaterScreenThree.transform.position.y+0.3f, 0.75f).setEaseInOutSine().setLoopPingPong();
        LeanTween.moveY(PacBertScreenThree, PacBertScreenThree.transform.position.y+0.4f, 0.75f).setEaseInOutSine().setLoopPingPong();
        LeanTween.rotateZ(PacBertScreenThree, 60.0f, 0.75f).setEaseInOutSine().setLoopPingPong();

        LeanTween.moveY(SwimmRingScreenThree, SwimmRingScreenThree.transform.position.y-0.1f, 0.75f).setEaseInOutSine().setLoopPingPong();

        LeanTween.scale(ScreenThreeTextOne, new Vector3(0.4f, 0.4f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue4();
    }

    public IEnumerator CutsceneTwoScreenOneAnimation()
    {

        //LeanTween.moveY(NumberThreeScreenOne, NumberThreeScreenOne.transform.position.y-0.1f, 7.0f).setEaseInOutSine().setLoopPingPong();


        
        LeanTween.moveY(NumberThreeScreenOne, NumberThreeScreenOne.transform.position.y+ 0.25f, 7.0f).setEaseInOutCubic().setLoopPingPong().setDelay(4.0f);
        LeanTween.rotateY(NumberThreeScreenOne, 180.0f, 0.8f).setEaseInOutCubic().setLoopPingPong();
        

        yield return new WaitForSeconds(2.0f );
        LeanTween.scale(CutsceneTwoScreenOneTextOne, new Vector3(0.34f, 0.34f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(1.0f);
        dialogueManager.PlayDialogue5();
        if(dialogueManager.finishedAnimating[0] == true)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Speeeeeed");
        }

        yield return new WaitForSeconds(2.25f);
        LeanTween.rotateY(RangerBertScreenOne, 180.0f, 1.8f).setEaseInOutCubic().setLoopPingPong();
        LeanTween.scale(CutsceneTwoScreenOneTextTwo, new Vector3(0.52f, 0.52f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(1.0f);

        dialogueManager.PlayDialogue6();
    }

    public IEnumerator CutsceneTwoScreenTwoAnimation()
    {

        LeanTween.moveLocalY(ShovelScreenTwo, ShovelScreenTwo.transform.localPosition.y+ 0.25f, 0.25f).setEaseInOutCubic().setLoopPingPong();


        yield return new WaitForSeconds(0.5f);
        dialogueManager.PlayDialogue7();
        

        


        yield return new WaitForSeconds(2.2f);
        LeanTween.scale(CutsceneTwoScreenTwoTextTwo, new Vector3(0.6f, 0.6f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(1.0f);

        dialogueManager.PlayDialogue9();


        LeanTween.scale(CutsceneTwoScreenTwoTextOne, new Vector3(0.52f, 0.52f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(1.2f);
        dialogueManager.PlayDialogue8();


        //yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
        
        if(dialogueManager.finishedAnimating[0] == true)
        {
            yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
            Debug.Log("Speeeeeed");
        }

        // yield return new WaitForSeconds(2.2f * SpeedWaitMultiplier);
        // LeanTween.scale(CutsceneTwoScreenTwoTextTwo, new Vector3(0.6f, 0.6f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        // yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);

        // dialogueManager.PlayDialogue9();
    }



    public void setArrowSpriteAlpha(float val)
    {
        foreach(SpriteRenderer NextArrowButton in NextArrowButtons)
        {
            NextArrowButton.color = new Color(1f,1f,1f,val);
        }
        
    }
}
