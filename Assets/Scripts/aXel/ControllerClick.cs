using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerClick : MonoBehaviour {

    public bool selected;
    public bool pressed;
    public bool holding;
    public float HoldingTime;
    public float starttime;
    public bool runPress;

    public bool ios;
    public bool android;
    // Start is called before the first frame update
    void Start () {

        #if UNITY_IPHONE
            ios = true;
        #endif
        #if UNITY_ANDROID
            android = true;
        #endif

    }

    // IEnumerator HoldingTimer()
    // {
    //     yield return new WaitForSeconds(HoldingTime);
    //     if(this.gameObject.name == "ButtonDown")
    //     {
    //         if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
    //         {
    //             holding = true;
    //         }
    //     }
        
    // }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp (0)) {
            
            pressed = false;

        }
        if(ios == false && android == false)
        {
            if(this.gameObject.name == "ButtonDown")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
            {
                selected = true;
                pressed = true;

                runPress = false;
                starttime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
            {
                selected = false;
                pressed = false;
                runPress = false;
            }
            
            if(Input.GetKey(KeyCode.DownArrow) && Time.time - starttime > HoldingTime || Input.GetKey("s") && Time.time - starttime > HoldingTime)
            {
                runPress = true;
                starttime = 0.0f;
            }
        }
        if(this.gameObject.name == "ButtonUp")
        {

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {
                pressed = true;
                selected = true;

                runPress = false;
                starttime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp("w"))
            {
                pressed = false;
                selected = false;
                runPress = false;
            }


            if(Input.GetKey(KeyCode.UpArrow) && Time.time - starttime > HoldingTime || Input.GetKey("w") && Time.time - starttime > HoldingTime)
            {
                runPress = true;
                starttime = 0.0f;
            }
        }

        if(this.gameObject.name == "ButtonRight")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
            {
                pressed = true;
                selected = true;

                runPress = false;
                starttime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp("d"))
            {
                pressed = false;
                selected = false;
                runPress = false;
            }

            if(Input.GetKey(KeyCode.RightArrow) && Time.time - starttime > HoldingTime || Input.GetKey("d") && Time.time - starttime > HoldingTime)
            {
                runPress = true;
                starttime = 0.0f;
            }

        }

        if(this.gameObject.name == "ButtonLeft")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
            {
                pressed = true;
                selected = true;

                runPress = false;
                starttime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp("a"))
            {
                pressed = false;
                selected = false;
                runPress = false;
            }

            if(Input.GetKey(KeyCode.LeftArrow) && Time.time - starttime > HoldingTime || Input.GetKey("a") && Time.time - starttime > HoldingTime)
            {
                runPress = true;
                starttime = 0.0f;
            }
        }
        }
        

        
        
        
    }

    void OnMouseOver () {

        if (Input.GetMouseButtonDown (0)) {

            selected = true;
            pressed = true;

            runPress = false;
            starttime = Time.time;
        

        }
        if (Input.GetMouseButtonUp (0)) {
            
            selected = false;
            runPress = false;
            //pressed = false;

        }

        if(Input.GetMouseButton(0) && Time.time - starttime > HoldingTime)
        {
            runPress = true;
            starttime = 0.0f;
        }


        
    }

    // IEnumerator waiter () {
    //     selected = true;
    //     yield return new WaitForSeconds (0.0f);
    //     selected = false;
    //     yield return new WaitForSeconds (0.0f);
    // }
}