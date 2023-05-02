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



    public GameObject[] NextScreenButtons;
    public GameObject[] SpeedUpButtons;
    public bool speedBool;
    public static float SpeedWaitMultiplier = 1.0f;
    public SpriteRenderer[] NextArrowButtons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(dialogueManager.finishedAnimating[0] == true)
        // {
            
        //     NextScreenButtons[0].SetActive(true);
        //     SpeedUpButtons[0].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[1] == true)
        // {
        //     NextScreenButtons[1].SetActive(true);
        //     SpeedUpButtons[1].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[4] == true)
        // {
        //     NextScreenButtons[2].SetActive(true);
        //     SpeedUpButtons[2].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[5] == true)
        // {
        //     NextScreenButtons[3].SetActive(true);
        //     SpeedUpButtons[3].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[8] == true)
        // {
        //     NextScreenButtons[4].SetActive(true);
        //     SpeedUpButtons[4].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[10] == true)
        // {
        //     NextScreenButtons[5].SetActive(true);
        //     SpeedUpButtons[5].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[11] == true)
        // {
        //     NextScreenButtons[6].SetActive(true);
        //     SpeedUpButtons[6].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[12] == true)
        // {
        //     NextScreenButtons[7].SetActive(true);
        //     SpeedUpButtons[7].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[13] == true)
        // {
        //     NextScreenButtons[8].SetActive(true);
        //     SpeedUpButtons[8].SetActive(false);
        // }
        // if(dialogueManager.finishedAnimating[14] == true)
        // {
        //     NextScreenButtons[9].SetActive(true);
        //     SpeedUpButtons[9].SetActive(false);
        // }
        
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

    public void ScreenFiveEatingInfinity()
    {
        StartCoroutine(EatingInfinity());
    }
    

    public IEnumerator OutroScreenOneAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
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

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenThreeAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenFourAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenFiveAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            // if(infinityBertScript.eatingInfinity == true)
            // {
            //     transitionWhite.SetTrigger("start");

            //     yield return new WaitForSeconds(1.0f);

            //     ScreenSix.SetActive(true);
            //     transitionWhite.SetTrigger("end");
            // }

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenSixAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenSevenAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
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

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
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
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }

    public IEnumerator OutroScreenTenAnimation()
    {

            SpeedWaitMultiplier = 0.6f;

            yield return new WaitForSeconds(1.5f * SpeedWaitMultiplier);
            dialogueManager.PlayDialogue1();
            if(dialogueManager.finishedAnimating[0] == true)
            {
                yield return new WaitForSeconds(0.5f * SpeedWaitMultiplier);
                Debug.Log("Speeeeeed");
            }
            
            //LeanTween.scale(ScreenOneXBertArrowGroup, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEase(LeanTweenType.easeInOutCirc);
            
    }



    public IEnumerator EatingInfinity()
    {
                transitionWhite.SetTrigger("start");

                yield return new WaitForSeconds(1.0f);
                ScreenFive.SetActive(false);

                ScreenSix.SetActive(true);
                transitionWhite.SetTrigger("end");
    }
}
