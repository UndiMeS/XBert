using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject WorldOne;
    public GameObject ShadowOne;
    public static int World;
    public static bool ShadowWorld;

    public Animator WorldOnetransition;
    public GameObject WorldOneTransition;
    public Animator ShadowWorldOnetransition;
    public GameObject ShadowWorldOneTransition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        if(World == 1 && ShadowWorld == false)
        {
            WorldOne.SetActive(true);
            StartCoroutine(ShadowToWorldOneTransition());
            StartMenu.SetActive(false);
            ShadowOne.SetActive(false);
            //WorldOne.SetActive(true);
        }
        else if(World == 1 && ShadowWorld == true)
        {
            StartCoroutine(ShadowOneTransition());
            StartMenu.SetActive(false);
            WorldOne.SetActive(false);
            
            //ShadowOne.SetActive(true);
        }
    }

    public void ToStartMenu()
    {
        StartMenu.SetActive(true);
        WorldOne.SetActive(false);
        World = 0;
        ShadowWorld = false;
    }


    public void ToWorldOne()
    {
        //StartCoroutine(ToWorldOneTransition());
        StartMenu.SetActive(false);
        WorldOne.SetActive(true);
        World = 1;
    }

    public void SwitchToNightOne()
    {
        StartCoroutine(ShadowOneTransition());
        
        
        //ShadowOne.SetActive(true);
        ShadowWorld = true;
    }

    public void SwitchToWorldOne()
    {
        StartCoroutine(ShadowToWorldOneTransition());
        // ShadowOne.SetActive(false);
        // WorldOne.SetActive(true);
        ShadowWorld = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator ShadowOneTransition()
    {
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOneTransition.SetActive(false);
        ShadowWorldOneTransition.SetActive(true);
        WorldOne.SetActive(false);
        ShadowOne.SetActive(true);
    }

    IEnumerator ShadowToWorldOneTransition()
    {
        
        ShadowWorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        ShadowWorldOneTransition.SetActive(false);
        WorldOneTransition.SetActive(true);
        ShadowOne.SetActive(false);
        WorldOne.SetActive(true);
        
    }

    IEnumerator ToWorldOneTransition()
    {
        WorldOnetransition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        WorldOnetransition.SetTrigger("end");
        StartMenu.SetActive(false);
        WorldOne.SetActive(true);
        World = 1;
    }
}
