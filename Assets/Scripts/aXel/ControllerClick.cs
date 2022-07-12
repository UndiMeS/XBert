﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerClick : MonoBehaviour {

    public bool selected;
    public bool pressed;
    public bool holding;
    public float HoldingTime;
    // Start is called before the first frame update
    void Start () {

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
        if(this.gameObject.name == "ButtonDown")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
            {
                selected = true;
                pressed = true;
            }

            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
            {
                selected = false;
                pressed = false;
            }
            // if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            // {
            //     StartCoroutine(HoldingTimer());
            // }
        }
        if(this.gameObject.name == "ButtonUp")
        {

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {
                pressed = true;
                selected = true;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp("w"))
            {
                pressed = false;
                selected = false;
            }
        }

        if(this.gameObject.name == "ButtonRight")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
            {
                pressed = true;
                selected = true;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp("d"))
            {
                pressed = false;
                selected = false;
            }

        }

        if(this.gameObject.name == "ButtonLeft")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
            {
                pressed = true;
                selected = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp("a"))
            {
                pressed = false;
                selected = false;
            }
        }

        
        
        
    }

    void OnMouseOver () {

                if (Input.GetMouseButtonDown (0)) {

             selected = true;
             pressed = true;
        

        }
        if (Input.GetMouseButtonUp (0)) {
            
            selected = false;
            //pressed = false;

        }


        
    }

    // IEnumerator waiter () {
    //     selected = true;
    //     yield return new WaitForSeconds (0.0f);
    //     selected = false;
    //     yield return new WaitForSeconds (0.0f);
    // }
}