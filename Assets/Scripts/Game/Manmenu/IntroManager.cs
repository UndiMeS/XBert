using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public bool ScreenOne = false;
    public bool ScreenTwo = false;
    public bool ScreenThree = false;
    public bool ScreenFour = false;
    public bool ScreenFive = false;
    public bool ScreenSix = false;
    public bool ScreenSeven = false;
    public bool ScreenEight = false;
    public bool ScreenNine = false;
    public bool ScreenTen = false;
    public bool ScreenEleven = false;
    public bool ScreenTwelve = false;
    public bool ScreenThirteen = false;
    public bool ScreenFourteen = false;
    public bool ScreenFifteen = false;
    public bool ScreenSixteen = false;
    public bool ScreenSeventeen = false;

    public DialogueManager dialogueManager;
    public DialogueVertexAnimator dialogueVertexAnimator;

    public GameObject ScreenOneArrowOne;
    public GameObject ScreenOneArrowTwo;
    public GameObject ScreenOneArrowThree;
    public GameObject ScreenOneArrowFour;
    public GameObject ScreenOneXBertArrowGroup;
    public GameObject ScreenTwoNumberOne;
    public GameObject ScreenTwoNumberTwo;
    public GameObject ScreenThreeNumberOne;
    public GameObject ScreenThreeNumberTwo;
    public GameObject ScreenThreeNumberThree;
    public GameObject ScreenThreeTextOne;
    public GameObject ScreenThreeTextTwo;
    public GameObject ScreenFourCloudOne;
    public GameObject ScreenFourCloudTwo;
    public GameObject ScreenFourCloudThree;
    public GameObject ScreenFourCloudFour;
    public SpriteRenderer ScreenFourCake;
    public GameObject ScreenFiveTextOne;
    public GameObject ScreenFiveTextTwo;
    public SpriteRenderer ScreenFivePiBertBlack;
    public GameObject ScreenSixTextOne;
    public GameObject ScreenSevenTextOne;
    public GameObject ScreenEightTextOne;
    public GameObject ScreenEightCircleShine;
    public GameObject ScreenEightCircleOne;
    public GameObject ScreenEightCircleTwo;
    public GameObject ScreenEightCircleNumber;
    public GameObject ScreenNineTextOne;
    public GameObject ScreenTenTextOne;
    public GameObject ScreenTenCircleShine;
    public GameObject ScreenTenCircleOne;
    public GameObject ScreenTenCircleTwo;
    public GameObject ScreenTenCircleNumber;
    public GameObject ScreenElevenTextOne;
    public GameObject ScreenElevenCircleShine;
    public GameObject ScreenElevenCircleOne;
    public GameObject ScreenElevenCircleTwo;
    public GameObject ScreenElevenCircleNumber;
    public GameObject ScreenTwelveTextOne;
    public GameObject ScreenThirteenTextOne;
    public GameObject ScreenFourteenTextOne;

    public GameObject[] NextScreenButtons;
    public GameObject[] SpeedUpButtons;
    public bool speedBool;
    public static float SpeedWaitMultiplier = 1.0f;
    public SpriteRenderer[] NextArrowButtons;
    // Start is called before the first frame update
    void Start()
    {
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
        if(dialogueManager.finishedAnimating[1] == true)
        {
            NextScreenButtons[1].SetActive(true);
            SpeedUpButtons[1].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[4] == true)
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
        if(dialogueManager.finishedAnimating[10] == true)
        {
            NextScreenButtons[5].SetActive(true);
            SpeedUpButtons[5].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[11] == true)
        {
            NextScreenButtons[6].SetActive(true);
            SpeedUpButtons[6].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[12] == true)
        {
            NextScreenButtons[7].SetActive(true);
            SpeedUpButtons[7].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[13] == true)
        {
            NextScreenButtons[8].SetActive(true);
            SpeedUpButtons[8].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[14] == true)
        {
            NextScreenButtons[9].SetActive(true);
            SpeedUpButtons[9].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[15] == true)
        {
            NextScreenButtons[10].SetActive(true);
            SpeedUpButtons[10].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[16] == true)
        {
            NextScreenButtons[11].SetActive(true);
            SpeedUpButtons[11].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[17] == true)
        {
            NextScreenButtons[12].SetActive(true);
            SpeedUpButtons[12].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[18] == true)
        {
            NextScreenButtons[13].SetActive(true);
            SpeedUpButtons[13].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[19] == true)
        {
            NextScreenButtons[14].SetActive(true);
            SpeedUpButtons[14].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[20] == true)
        {
            NextScreenButtons[15].SetActive(true);
            SpeedUpButtons[15].SetActive(false);
        }
        if(dialogueManager.finishedAnimating[21] == true)
        {
            NextScreenButtons[16].SetActive(true);
            SpeedUpButtons[16].SetActive(false);
        }


        // if(ScreenOne == true)
        // {
        //     StartCoroutine(IntroScreenOneAnimation());
            
        //     ScreenOne = false;
        // }

        // if(ScreenTwo == true)
        // {
        //     StartCoroutine(IntroScreenTwoAnimation());

        //     ScreenTwo = false;
        // }
        // if(ScreenThree == true)
        // {
        //     StartCoroutine(IntroScreenThreeAnimation());

        //     ScreenThree = false;
        // }

        // if(ScreenFour == true)
        // {
        //     StartCoroutine(IntroScreenFourAnimation());

        //     ScreenFour = false;
        // }

        // if(ScreenFive == true)
        // {
        //     StartCoroutine(IntroScreenFiveAnimation());

        //     ScreenFive = false;
        // }

        // if(ScreenSix == true)
        // {
        //     StartCoroutine(IntroScreenSixAnimation());

        //     ScreenSix = false;
        // }

        // if(ScreenSeven == true)
        // {
        //     StartCoroutine(IntroScreenSevenAnimation());

        //     ScreenSeven = false;
        // }

        // if(ScreenEight == true)
        // {
        //     StartCoroutine(IntroScreenEightAnimation());

        //     ScreenEight = false;
        // }

        // if(ScreenNine == true)
        // {
        //     StartCoroutine(IntroScreenNineAnimation());

        //     ScreenNine = false;
        // }

        // if(ScreenTen == true)
        // {
        //     StartCoroutine(IntroScreenTenAnimation());

        //     ScreenTen = false;
        // }

        // if(ScreenEleven == true)
        // {
        //     StartCoroutine(IntroScreenElevenAnimation());

        //     ScreenEleven = false;
        // }

        // if(ScreenTwelve == true)
        // {
        //     StartCoroutine(IntroScreenTwelveAnimation());

        //     ScreenTwelve = false;
        // }

        // if(ScreenThirteen == true)
        // {
        //     StartCoroutine(IntroScreenThirteenAnimation());

        //     ScreenThirteen = false;
        // }

        // if(ScreenFourteen == true)
        // {
        //     StartCoroutine(IntroScreenFourteenAnimation());

        //     ScreenFourteen = false;
        // }

        // if(ScreenFifteen == true)
        // {
        //     StartCoroutine(IntroScreenFifteenAnimation());

        //     ScreenFifteen = false;
        // }

        // if(ScreenSixteen == true)
        // {
        //     StartCoroutine(IntroScreenSixteenAnimation());

        //     ScreenSixteen = false;
        // }

        // if(ScreenSeventeen == true)
        // {
        //     StartCoroutine(IntroScreenSeventeenAnimation());

        //     ScreenSeventeen = false;
        // }
    }

    public void ScreenOneFunction()
    {
        StartCoroutine(IntroScreenOneAnimation());
    }
    public void ScreenTwoFunction()
    {
        StartCoroutine(IntroScreenTwoAnimation());
    }
    public void ScreenThreeFunction()
    {
        StartCoroutine(IntroScreenThreeAnimation());
    }
    public void ScreenFourFunction()
    {
        StartCoroutine(IntroScreenFourAnimation());
    }
    public void ScreenFiveFunction()
    {
        StartCoroutine(IntroScreenFiveAnimation());
    }
    public void ScreenSixFunction()
    {
        StartCoroutine(IntroScreenSixAnimation());
    }
    public void ScreenSevenFunction()
    {
        StartCoroutine(IntroScreenSevenAnimation());
    }
    public void ScreenEightFunction()
    {
        StartCoroutine(IntroScreenEightAnimation());
    }
    public void ScreenNineFunction()
    {
        StartCoroutine(IntroScreenNineAnimation());
    }
    public void ScreenTenFunction()
    {
        StartCoroutine(IntroScreenTenAnimation());
    }
    public void ScreenElevenFunction()
    {
        StartCoroutine(IntroScreenElevenAnimation());
    }
    public void ScreenTwelveFunction()
    {
        StartCoroutine(IntroScreenTwelveAnimation());
    }
    public void ScreenThirteenFunction()
    {
        StartCoroutine(IntroScreenThirteenAnimation());
    }
    public void ScreenFourteenFunction()
    {
        StartCoroutine(IntroScreenFourteenAnimation());
    }
    public void ScreenFifteenFunction()
    {
        StartCoroutine(IntroScreenFifteenAnimation());
    }
    public void ScreenSixteenFunction()
    {
        StartCoroutine(IntroScreenSixteenAnimation());
    }
    public void ScreenSeventeenFunction()
    {
        StartCoroutine(IntroScreenSeventeenAnimation());
    }
    public IEnumerator IntroScreenOneAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            LeanTween.moveLocalX(ScreenOneArrowOne.gameObject,-6.4f, 1.0f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.moveLocalY(ScreenOneArrowOne.gameObject, 2.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();

            LeanTween.moveLocalX(ScreenOneArrowTwo.gameObject, 6.4f, 1.0f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.moveLocalY(ScreenOneArrowTwo.gameObject, 2.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();

            LeanTween.moveLocalX(ScreenOneArrowThree.gameObject, 6.4f, 1.0f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.moveLocalY(ScreenOneArrowThree.gameObject, -5.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();

            LeanTween.moveLocalX(ScreenOneArrowFour.gameObject, -6.4f, 1.0f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.moveLocalY(ScreenOneArrowFour.gameObject, -5.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();

            

            
    }

    public IEnumerator IntroScreenTwoAnimation()
    {
            SpeedWaitMultiplier = 1.0f;
            if(dialogueManager.finishedAnimating[1] == false)
            yield return new WaitForSeconds(0.1f * SpeedWaitMultiplier);
            LeanTween.rotateZ(ScreenTwoNumberOne.gameObject, -20.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.rotateZ(ScreenTwoNumberTwo.gameObject, 20.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();

            dialogueManager.PlayDialogue2();
    }

    public IEnumerator IntroScreenThreeAnimation()
    {

            SpeedWaitMultiplier = 1.0f;

            LeanTween.rotateZ(ScreenThreeNumberOne.gameObject, -4.0f, 0.1f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.rotateZ(ScreenThreeNumberTwo.gameObject, 3.0f, 0.1f).setEaseInOutCubic().setLoopPingPong();
            LeanTween.rotateZ(ScreenThreeNumberThree.gameObject, -5.0f, 0.1f).setEaseInOutCubic().setLoopPingPong();

            dialogueManager.PlayDialogue3();
            // if(dialogueManager.finishedAnimating[2] == false)
            // {
            //     yield return new WaitForSeconds();
            // }

            yield return new WaitForFixedUpdate();

            if(dialogueManager.Speedup == false)
            {
                yield return new WaitForSeconds(2.3f);
                Debug.Log("Sloooooow");
            }
            else
            {
                Debug.Log("Speeeeeed");
                yield return new WaitForSeconds(0.01f);
            }
                
            
            LeanTween.scale(ScreenThreeTextOne, new Vector3(0.5f, 0.5f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);

            yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
            
            dialogueManager.PlayDialogue4();
            yield return new WaitForSeconds(0.6f * SpeedWaitMultiplier);
            
            LeanTween.scale(ScreenThreeTextTwo, new Vector3(0.7f, 0.7f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
            
            dialogueManager.PlayDialogue5();
    }

    public IEnumerator IntroScreenFourAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        dialogueManager.PlayDialogue6();
        if(dialogueManager.finishedAnimating[5] == false)
        yield return new WaitForSeconds(1.2f * SpeedWaitMultiplier);

        LeanTween.scale(ScreenFourCloudOne, new Vector3(0.65f, 0.65f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        if(dialogueManager.finishedAnimating[6] == false)
        yield return new WaitForSeconds(0.2f * SpeedWaitMultiplier);

        LeanTween.scale(ScreenFourCloudTwo, new Vector3(0.65f, 0.65f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        if(dialogueManager.finishedAnimating[7] == false)
        yield return new WaitForSeconds(0.2f * SpeedWaitMultiplier);

        LeanTween.scale(ScreenFourCloudThree, new Vector3(0.65f, 0.65f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        if(dialogueManager.finishedAnimating[8] == false)
        yield return new WaitForSeconds(0.2f * SpeedWaitMultiplier);

        LeanTween.scale(ScreenFourCloudFour, new Vector3(0.65f, 0.65f, 1.0f), 1.0f).setEase(LeanTweenType.easeInOutCirc);
        if(dialogueManager.finishedAnimating[9] == false)
        yield return new WaitForSeconds(0.75f * SpeedWaitMultiplier);
        LeanTween.value( gameObject, setSpriteAlpha, 0f, 1f, 1f );

    }
    public IEnumerator IntroScreenFiveAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        ScreenFivePiBertBlack.color = new Color(1f,1f,1f,0f);

        dialogueManager.PlayDialogue7();
        if(dialogueManager.finishedAnimating[8] == false)
        yield return new WaitForSeconds(2.5f * SpeedWaitMultiplier);
        LeanTween.value( gameObject, setSpriteAlpha, 0f, 1f, 1f );
        yield return new WaitForSeconds(1.0f * SpeedWaitMultiplier);
        LeanTween.scale(ScreenFiveTextOne, new Vector3(0.62f, 0.62f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue8();
        yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
        LeanTween.scale(ScreenFiveTextTwo, new Vector3(0.62f, 0.62f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue9();
    }

    public IEnumerator IntroScreenSixAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        dialogueManager.PlayDialogue10();
        yield return new WaitForSeconds(1.3f * SpeedWaitMultiplier);
        LeanTween.scale(ScreenSixTextOne, new Vector3(0.62f, 0.62f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue11();
    }

    public IEnumerator IntroScreenSevenAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        LeanTween.scale(ScreenSevenTextOne, new Vector3(0.7f, 0.7f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue12();
    }

    public IEnumerator IntroScreenEightAnimation()
    {

        SpeedWaitMultiplier = 1.0f;

        //LeanTween.rotateZ(ScreenEightCircleShine.gameObject, -20.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();
        LeanTween.rotateAround(ScreenEightCircleShine.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenEightCircleOne.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenEightCircleTwo.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenEightCircleNumber.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();

        LeanTween.scale(ScreenEightCircleShine.gameObject, new Vector3(0.6f, 0.6f, 1.0f), 2.0f).setEaseInOutCubic().setLoopPingPong();


        LeanTween.scale(ScreenEightTextOne, new Vector3(0.62f, 0.62f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue13();
    }

    public IEnumerator IntroScreenNineAnimation()
    {

        SpeedWaitMultiplier = 1.0f;

        LeanTween.scale(ScreenNineTextOne, new Vector3(0.68f, 0.68f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue14();
    }

    public IEnumerator IntroScreenTenAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        //LeanTween.rotateZ(ScreenEightCircleShine.gameObject, -20.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();
        LeanTween.rotateAround(ScreenTenCircleShine.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenTenCircleOne.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenTenCircleTwo.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenTenCircleNumber.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();

        LeanTween.scale(ScreenTenCircleShine.gameObject, new Vector3(0.6f, 0.6f, 1.0f), 2.0f).setEaseInOutCubic().setLoopPingPong();


        LeanTween.scale(ScreenTenTextOne, new Vector3(0.6f, 0.6f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue15();
    }

    public IEnumerator IntroScreenElevenAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        //LeanTween.rotateZ(ScreenEightCircleShine.gameObject, -20.0f, 1.0f).setEaseInOutCubic().setLoopPingPong();
        LeanTween.rotateAround(ScreenElevenCircleShine.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenElevenCircleOne.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenElevenCircleTwo.gameObject, Vector3.forward, 360, 5.0f).setLoopClamp();
        LeanTween.rotateAround(ScreenElevenCircleNumber.gameObject, Vector3.forward, -360, 5.0f).setLoopClamp();

        LeanTween.scale(ScreenElevenCircleShine.gameObject, new Vector3(0.6f, 0.6f, 1.0f), 2.0f).setEaseInOutCubic().setLoopPingPong();


        LeanTween.scale(ScreenElevenTextOne, new Vector3(0.6f, 0.6f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue16();
    }

    public IEnumerator IntroScreenTwelveAnimation()
    {

        SpeedWaitMultiplier = 1.0f;

        LeanTween.scale(ScreenTwelveTextOne, new Vector3(0.6f, 0.6f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue17();
    }

    public IEnumerator IntroScreenThirteenAnimation()
    {

        SpeedWaitMultiplier = 1.0f;

        LeanTween.scale(ScreenThirteenTextOne, new Vector3(0.7f, 0.7f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue18();
    }

    public IEnumerator IntroScreenFourteenAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        LeanTween.scale(ScreenFourteenTextOne, new Vector3(0.7f, 0.7f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
        yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue19();
    }

    public IEnumerator IntroScreenFifteenAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        yield return new WaitForSeconds(0.1f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue20();
    }

    public IEnumerator IntroScreenSixteenAnimation()
    {
        SpeedWaitMultiplier = 1.0f;


        yield return new WaitForSeconds(0.1f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue21();
    }

    public IEnumerator IntroScreenSeventeenAnimation()
    {

        SpeedWaitMultiplier = 1.0f;

        yield return new WaitForSeconds(0.1f * SpeedWaitMultiplier);
        dialogueManager.PlayDialogue22();
    }

    public void setSpriteAlpha( float val )
    {
        ScreenFivePiBertBlack.color = new Color(1f,1f,1f,val);
        ScreenFourCake.color = new Color(1f,1f,1f,val);
        
    }

    public void setArrowSpriteAlpha(float val)
    {
        foreach(SpriteRenderer NextArrowButton in NextArrowButtons)
        {
            NextArrowButton.color = new Color(1f,1f,1f,val);
        }
        
    }
}
