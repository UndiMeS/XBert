using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroManager : MonoBehaviour
{


    public OutroDialogueManager dialogueManager;
    public DialogueVertexAnimator dialogueVertexAnimator;

    public EatInfinityBert infinityBertScript;
    public GameObject ScreenFive;
    public GameObject ScreenSix;


    public GameObject TransitionWhite;
    public Animator transitionWhite;


    public GameObject ScreenOneWorld;

    public GameObject ScreenTwoLabel;

    public GameObject ScreenFourCircleShine;
    public GameObject ScreenFourCircleOne;
    public GameObject ScreenFourCircleTwo;
    public GameObject ScreenFourCircleNumber;
    public GameObject ScreenFourTextOne;

    public GameObject ScreenSixTextOne;

    public GameObject ScreenSevenTextOne;
    public GameObject ScreenSevenTextTwo;

    public GameObject ScreenEightBackground;

    public GameObject ScreenTenTextOne;
    public GameObject ScreenTenTextTwo;
    public GameObject ScreenTenTextThree;
    public GameObject ScreenTenTextFour;
    public GameObject ScreenTenTextFive;
    public GameObject ScreenTenTextSix;

    public GameObject ScreenTenNumberOne;
    public GameObject ScreenTenNumberTwo;
    public GameObject ScreenTenNumberThree;
    public GameObject ScreenTenNumberFour;
    public GameObject ScreenTenNumberFive;
    public GameObject ScreenTenNumberSix;

    private Vector3 ScreenTenNumberOnePosition;
    private Vector3 ScreenTenNumberTwoPosition;
    private Vector3 ScreenTenNumberThreePosition;
    private Vector3 ScreenTenNumberFourPosition;
    private Vector3 ScreenTenNumberFivePosition;
    private Vector3 ScreenTenNumberSixPosition;

    private Vector3 ScreenTenNumberOneScale;
    private Vector3 ScreenTenNumberTwoScale;
    private Vector3 ScreenTenNumberThreeScale;
    private Vector3 ScreenTenNumberFourScale;
    private Vector3 ScreenTenNumberFiveScale;
    private Vector3 ScreenTenNumberSixScale;

    public GameObject ScreenTenXBert;


    public GameObject ScreenElevenStar;

    public GameObject ScreenTwelveTextOne;
    public GameObject ScreenTwelveTextTwo;
    public GameObject ScreenTwelveNumberOne;
    public GameObject ScreenTwelveNumberTwo;
    public GameObject ScreenTwelveNumberThree;

    public GameObject ScreenThirteenWorld;

    public bool CreditScreenOne;
    public bool CreditScreenTwo;


    public GameObject[] NextScreenButtons;
    public GameObject[] SpeedUpButtons;
    public bool speedBool;
    public static float SpeedWaitMultiplier = 1.0f;
    public SpriteRenderer[] NextArrowButtons;

    public GameObject SkipButton;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.reset();

        LeanTween.value( gameObject, setArrowSpriteAlpha, 0f, 1f, 1f ).setEaseInOutCubic().setLoopPingPong();
        ScreenOneFunction();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.finishedAnimating[0] == true)
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
        if(dialogueManager.finishedAnimating[4] == true)
        {
            NextScreenButtons[3].SetActive(true);
            SpeedUpButtons[3].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[6] == true)
        {
            NextScreenButtons[4].SetActive(true);
            SpeedUpButtons[4].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[9] == true)
        {
            NextScreenButtons[5].SetActive(true);
            SpeedUpButtons[5].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[10] == true)
        {
            NextScreenButtons[6].SetActive(true);
            SpeedUpButtons[6].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[11] == true)
        {
            NextScreenButtons[7].SetActive(true);
            SpeedUpButtons[7].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[18] == true)
        {
            NextScreenButtons[8].SetActive(true);
            SpeedUpButtons[8].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[19] == true)
        {
            NextScreenButtons[9].SetActive(true);
            SpeedUpButtons[9].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[22] == true)
        {
            NextScreenButtons[10].SetActive(true);
            SpeedUpButtons[10].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[23] == true)
        {
            NextScreenButtons[11].SetActive(true);
            SpeedUpButtons[11].SetActive(false);
        }
        if(CreditScreenOne == true)
        {
            NextScreenButtons[12].SetActive(true);
            SpeedUpButtons[12].SetActive(false);
            CreditScreenOne = false;
        }
        if(CreditScreenTwo == true)
        {
            NextScreenButtons[13].SetActive(true);
            SpeedUpButtons[13].SetActive(false);
            CreditScreenTwo = false;
        }
        
    }

    public void ScreenOneFunction()
    {
        StartCoroutine(OutroScreenOneAnimation());
    }
    public void ScreenTwoFunction()
    {
        StartCoroutine(OutroScreenTwoAnimation());
    }
    public void ScreenThreeFunction()
    {
        StartCoroutine(OutroScreenThreeAnimation());
    }
    public void ScreenFourFunction()
    {
        StartCoroutine(OutroScreenFourAnimation());
    }
    public void ScreenFiveFunction()
    {
        StartCoroutine(OutroScreenFiveAnimation());
    }
    public void ScreenSixFunction()
    {
        StartCoroutine(OutroScreenSixAnimation());
    }
    public void ScreenSevenFunction()
    {
        StartCoroutine(OutroScreenSevenAnimation());
    }
    public void ScreenEightFunction()
    {
        StartCoroutine(OutroScreenEightAnimation());
    }
    public void ScreenNineFunction()
    {
        StartCoroutine(OutroScreenNineAnimation());
    }
    public void ScreenTenFunction()
    {
        StartCoroutine(OutroScreenTenAnimation());
    }

    public void ScreenElevenFunction()
    {
        StartCoroutine(OutroScreenElevenAnimation());
    }

    public void ScreenTwelveFunction()
    {
        StartCoroutine(OutroScreenTwelveAnimation());
    }
    public void ScreenThirteenFunction()
    {
        StartCoroutine(OutroScreenThirteenAnimation());
    }
    public void ScreenFourteenFunction()
    {
        StartCoroutine(OutroScreenFourteenAnimation());
    }
    public void ScreenFivteenFunction()
    {
        StartCoroutine(OutroScreenFivteenAnimation());
    }

    public void ScreenFiveEatingInfinity()
    {
        StartCoroutine(EatingInfinity());
    }
    

    public IEnumerator OutroScreenOneAnimation()
    {

            LeanTween.rotateAround(ScreenOneWorld, Vector3.forward, 360, 7.0f).setLoopClamp();

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenTwoAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue2();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }

            yield return new WaitForSeconds(3.0f * SpeedWaitMultiplier);

            LeanTween.moveLocal(ScreenTwoLabel, new Vector3(6.181f,-4.571f,0f), 1.0f);
            LeanTween.rotateZ(ScreenTwoLabel,0f,1.0f);
            LeanTween.scale(ScreenTwoLabel, new Vector3(0.169f, 0.383f, 0.0f), 1.0f).setEase(LeanTweenType.easeInOutCirc);

            yield return new WaitForSeconds(1.75f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue3();
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenThreeAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue4();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenFourAnimation()
    {

        LeanTween.rotateAround(ScreenFourCircleShine.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenFourCircleOne.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenFourCircleTwo.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenFourCircleNumber.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();

        LeanTween.scale(ScreenFourCircleShine.gameObject, new Vector3(0.6f, 0.6f, 1.0f), 2.0f).setEaseInOutCubic().setLoopPingPong();

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenFourTextOne, new Vector3(0.476f, 0.476f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);

            SkipButton.SetActive(false);


            dialogueManager.PlayDialogue5();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenFiveAnimation()
    {

            yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenSixAnimation()
    {

        SkipButton.SetActive(true);

            SpeedWaitMultiplier = 0.6f;

            // if(infinityBertScript.eatingInfinity == true)
            // {
            //     transitionWhite.SetTrigger("start");

            //     yield return new WaitForSeconds(1.0f);

            //     ScreenSix.SetActive(true);
            //     transitionWhite.SetTrigger("end");
            // }

            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue6();


            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenSixTextOne, new Vector3(0.438f, 0.438f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);


            dialogueManager.PlayDialogue7();


            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
    }

    public IEnumerator OutroScreenSevenAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue8();


            yield return new WaitForSeconds(4.5f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenSevenTextOne, new Vector3(0.4f, 0.4f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue9();

            yield return new WaitForSeconds(4.0f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenSevenTextTwo, new Vector3(0.4f, 0.4f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue10();





            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenEightAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            LeanTween.rotateAround(ScreenEightBackground, Vector3.forward, 360, 15.0f).setLoopClamp();

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue11();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenNineAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue12();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenTenAnimation()
    {

            ScreenTenNumberOnePosition = ScreenTenNumberOne.transform.position;
            ScreenTenNumberTwoPosition = ScreenTenNumberTwo.transform.position;
            ScreenTenNumberThreePosition = ScreenTenNumberThree.transform.position;
            ScreenTenNumberFourPosition = ScreenTenNumberFour.transform.position;
            ScreenTenNumberFivePosition = ScreenTenNumberFive.transform.position;
            ScreenTenNumberSixPosition = ScreenTenNumberSix.transform.position;

            ScreenTenNumberOneScale = ScreenTenNumberOne.transform.localScale;
            ScreenTenNumberTwoScale = ScreenTenNumberTwo.transform.localScale;
            ScreenTenNumberThreeScale = ScreenTenNumberThree.transform.localScale;
            ScreenTenNumberFourScale = ScreenTenNumberFour.transform.localScale;
            ScreenTenNumberFiveScale = ScreenTenNumberFive.transform.localScale;
            ScreenTenNumberSixScale = ScreenTenNumberSix.transform.localScale;

            ScreenTenNumberOne.transform.position = ScreenTenXBert.transform.position;
            ScreenTenNumberTwo.transform.position = ScreenTenXBert.transform.position;
            ScreenTenNumberThree.transform.position = ScreenTenXBert.transform.position;
            ScreenTenNumberFour.transform.position = ScreenTenXBert.transform.position;
            ScreenTenNumberFive.transform.position = ScreenTenXBert.transform.position;
            ScreenTenNumberSix.transform.position = ScreenTenXBert.transform.position;


            ScreenTenNumberOne.transform.localScale = new Vector3(0,0,0);
            ScreenTenNumberTwo.transform.localScale = new Vector3(0,0,0);
            ScreenTenNumberThree.transform.localScale = new Vector3(0,0,0);
            ScreenTenNumberFour.transform.localScale = new Vector3(0,0,0);
            ScreenTenNumberFive.transform.localScale = new Vector3(0,0,0);
            ScreenTenNumberSix.transform.localScale = new Vector3(0,0,0);


            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue13();

            yield return new WaitForSeconds(5.0f * SpeedWaitMultiplier);

            LeanTween.move(ScreenTenNumberOne, ScreenTenNumberOnePosition, 0.5f);
            LeanTween.move(ScreenTenNumberTwo, ScreenTenNumberTwoPosition, 0.5f);
            LeanTween.move(ScreenTenNumberThree, ScreenTenNumberThreePosition, 0.5f);
            LeanTween.move(ScreenTenNumberFour, ScreenTenNumberFourPosition, 0.5f);
            LeanTween.move(ScreenTenNumberFive, ScreenTenNumberFivePosition, 0.5f);
            LeanTween.move(ScreenTenNumberSix, ScreenTenNumberSixPosition, 0.5f);


            LeanTween.scale(ScreenTenNumberOne, ScreenTenNumberOneScale, 0.5f).setEase(LeanTweenType.easeInOutCirc);
            LeanTween.scale(ScreenTenNumberTwo, ScreenTenNumberTwoScale, 0.5f).setEase(LeanTweenType.easeInOutCirc);
            LeanTween.scale(ScreenTenNumberThree, ScreenTenNumberThreeScale, 0.5f).setEase(LeanTweenType.easeInOutCirc);
            LeanTween.scale(ScreenTenNumberFour, ScreenTenNumberFourScale, 0.5f).setEase(LeanTweenType.easeInOutCirc);
            LeanTween.scale(ScreenTenNumberFive, ScreenTenNumberFiveScale, 0.5f).setEase(LeanTweenType.easeInOutCirc);
            LeanTween.scale(ScreenTenNumberSix, ScreenTenNumberSixScale, 0.5f).setEase(LeanTweenType.easeInOutCirc);

            yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);



            LeanTween.scale(ScreenTenTextOne, new Vector3(0.5f, 0.5f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(0.3f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue14();

            yield return new WaitForSeconds(0.25f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenTenTextTwo, new Vector3(0.5f, 0.5f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(0.3f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue15();

            yield return new WaitForSeconds(0.25f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenTenTextThree, new Vector3(0.5f, 0.5f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(0.3f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue16();

            yield return new WaitForSeconds(0.25f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenTenTextFour, new Vector3(0.5f, 0.5f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(0.3f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue17();

            yield return new WaitForSeconds(0.25f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenTenTextFive, new Vector3(0.5f, 0.5f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(0.3f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue18();

            yield return new WaitForSeconds(0.25f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenTenTextSix, new Vector3(0.5f, 0.5f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(0.3f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue19();


            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }


    public IEnumerator OutroScreenElevenAnimation()
    {

            LeanTween.rotateAround(ScreenElevenStar, Vector3.forward, 360, 10.0f).setLoopClamp();
            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue20();

            


            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            
            
    }

    public IEnumerator OutroScreenTwelveAnimation()
    {

            SpeedWaitMultiplier = 0.6f;


            LeanTween.rotateZ(ScreenTwelveNumberOne.gameObject, -4.0f, 0.1f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.rotateZ(ScreenTwelveNumberTwo.gameObject, 3.0f, 0.1f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.rotateZ(ScreenTwelveNumberThree.gameObject, -5.0f, 0.1f).setEaseInOutCubic().setLoopPingPong();



            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue21();

            yield return new WaitForSeconds(4.0f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenTwelveTextOne, new Vector3(0.345f, 0.345f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            dialogueManager.PlayDialogue22();

            yield return new WaitForSeconds(5.5f * SpeedWaitMultiplier);
            LeanTween.scale(ScreenTwelveTextTwo, new Vector3(0.345f, 0.345f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            dialogueManager.PlayDialogue23();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenThirteenAnimation()
    {

            LeanTween.rotateAround(ScreenThirteenWorld, Vector3.forward, 360, 15.0f).setLoopClamp();
            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue24();

            


            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
    }

    public IEnumerator OutroScreenFourteenAnimation()
    {

            yield return new WaitForSeconds(7.0f * SpeedWaitMultiplier);

            CreditScreenOne = true;
            
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
    }

    public IEnumerator OutroScreenFivteenAnimation()
    {

            yield return new WaitForSeconds(7.0f * SpeedWaitMultiplier);

            CreditScreenTwo = true;
            
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
    }



    public IEnumerator EatingInfinity()
    {
                transitionWhite.SetTrigger("start");

                yield return new WaitForSeconds(1.0f);
                ScreenFive.SetActive(false);

                ScreenSix.SetActive(true);

                ScreenSixFunction();
                transitionWhite.SetTrigger("end");
    }

    public void setArrowSpriteAlpha(float val)
    {
        foreach(SpriteRenderer NextArrowButton in NextArrowButtons)
        {
            NextArrowButton.color = new Color(1f,1f,1f,val);
        }
        
    }
}
