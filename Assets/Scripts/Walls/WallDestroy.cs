﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{

    public GameObject axel;
    public PlayerMovement movement;
    public bool smash;
    public Transform movePoint;
    public float step;
    public LayerMask Axel;

    public Animator animator;
    public GameObject ThisWall;

    public bool DestroyUp;
    public bool DestroyDown;
    public bool DestroyLeft;
    public bool DestroyRight;

    void Awake()
    {
        ThisWall = this.gameObject;
        animator = this.gameObject.GetComponent<Animator>();
        movement = axel.gameObject.GetComponent<PlayerMovement>();
        movePoint = ThisWall.transform.GetChild(0).gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        smash = movement.smash;

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, Axel) && movement.UpMove == true && movement.Drill == true)
        {
            DestroyUp = true;
        }

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, Axel) && movement.DownMove == true && movement.Drill == true)
        {
            DestroyDown = true;
        }

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (step, 0.0f, 0.0f), .2f, Axel) && movement.LeftMove == true && movement.Drill == true)
        {
            DestroyLeft = true;
        }

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, Axel) && movement.RightMove == true && movement.Drill == true)
        {
            DestroyRight = true;
        }
            

        // if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, Axel) && movement.DownPress == true)
        // DestroyUp = true;

        // if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (step, 0.0f, 0.0f), .2f, Axel) && movement.LeftPress == true)
        // DestroyUp = true;

        // if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step, 0.0f, 0.0f), .2f, Axel)&&movement.RightPress == true)
        // DestroyUp = true;

        if( DestroyUp == true||
            DestroyDown == true ||
            DestroyLeft == true||
            DestroyRight == true)
            {
                //movePoint.position += new Vector3 (0.0f,-step, 0.0f);
                 if(smash == true)
                {
                    Debug.Log(ThisWall.name);
                    animator.SetBool("smash", true);
                    Destroy (ThisWall, animator.GetCurrentAnimatorStateInfo(0).length + 0.0f);
                    //Destroy(ThisWall);
                    movement.smash = false;
                    movement.Drill = false;

                    // DestroyUp = false;
                    // DestroyDown = false;
                    // DestroyLeft = false;
                    // DestroyRight = false;
                }
            }
    }
}
