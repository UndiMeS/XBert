﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour {

    public GameObject Up;
    public GameObject Right;
    public GameObject Down;
    public GameObject Left;

    public bool UpPress;
    public bool RightPress;
    public bool DownPress;
    public bool LeftPress;

    public Rigidbody2D rb;
    public float step;
    public Vector3 StartPosition;
    public GameObject[] NumbersEaten;
    public Animator animator;

    public float speed;

    public GameObject Solution;
    public bool Finished;
    public float solution;


    public float moveSpeed;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public LayerMask BreakingWall;

    public bool Drill;
    public bool smash;
    public static bool moving = true;

    public GameObject MovePointParent;



    // Start is called before the first frame update
    void Start () {

        movePoint.SetParent (MovePointParent.transform);
        movePoint.position = this.gameObject.transform.position;
        StartPosition = this.gameObject.transform.position;

        rb = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame

    void Update () {

        Finished = Solution.GetComponent<Solution>().LevelFinished;



        NumbersEaten = FindGameObjectsWithTags(new string[] {"Numbers","Multiply","Divide","Amount","Square"});

        foreach(GameObject NumberEaten in NumbersEaten)
        {
            if(NumberEaten.GetComponent<aXelNumber>().Eaten == true)
            {

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("aXel_eats"))
                    {
                        
                        //animator.SetBool("Eat", true);
                    }
                else
                {
                    animator.SetTrigger("EatTrigger");
                    //animator.SetBool("Eat", false);
                }
                
                
                NumberEaten.GetComponent<aXelNumber>().Eaten = false;
                NumberEaten.gameObject.SetActive(false);
                
            }
            
        }

        



        UpPress = Up.GetComponent<ControllerClick> ().selected;
        RightPress = Right.GetComponent<ControllerClick> ().selected;
        DownPress = Down.GetComponent<ControllerClick> ().selected;
        LeftPress = Left.GetComponent<ControllerClick> ().selected;
        //move ();

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.01f && moving == true)
        {
            move();
        }

        if(Finished == true)
        {

            transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        }



         if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    
                    if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime> 1)
                    {
                        Debug.Log("not playing");
                        smash = true;
                    
                    }
                    
                
                }

    }

    public void move () {

        if (UpPress == true) {

            rb.transform.rotation = Quaternion.Euler (0, 0, 90.0f);

                if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, whatStopsMovement) && ! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, BreakingWall))
                {
                    movePoint.position += new Vector3 (0.0f,step, 0.0f);
                }
                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, BreakingWall) && Drill == true )
            {
            animator.SetBool("drill", false);
            Drill = false;

            }

             Up.GetComponent<ControllerClick> ().selected = false;

        }
        if (RightPress == true) {
            rb.transform.rotation = Quaternion.Euler (0, 0, 0.0f);
     
            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, whatStopsMovement)&&! Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, BreakingWall))
            {
                movePoint.position += new Vector3 (step, 0.0f, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, BreakingWall) && Drill == true)
            {

                animator.SetBool("drill", false);
            Drill = false;

            }
            



            Right.GetComponent<ControllerClick> ().selected = false;
        }
        if (LeftPress == true) {
            rb.transform.rotation = Quaternion.Euler (180.0f, 0, -180.0f);
  
            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, whatStopsMovement)&&! Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, BreakingWall))
            {
                movePoint.position += new Vector3 (-step, 0.0f, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, BreakingWall) && Drill == true)
            {

                animator.SetBool("drill", false);
            Drill = false;

            }
            


            Left.GetComponent<ControllerClick> ().selected = false;
        }
        if (DownPress == true) {
            rb.transform.rotation = Quaternion.Euler (0, 0, -90.0f);

            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, whatStopsMovement) &&! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, BreakingWall))
            {
                movePoint.position += new Vector3 (0.0f,-step, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, BreakingWall) && Drill == true)
            {

                animator.SetBool("drill", false);
            Drill = false;
            

            
        }
            Down.GetComponent<ControllerClick> ().selected = false;

    }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Drill" && Drill == false)
        {

            animator.SetBool("Eat", false);
            Drill = true;

            animator.SetBool("drill", true);

            Destroy(col.gameObject);
        }
    }

    GameObject[] FindGameObjectsWithTags(params string[] tags)
{
    var all = new List<GameObject>();

    foreach (string tag in tags)
    {
        all.AddRange(GameObject.FindGameObjectsWithTag(tag).ToList());
    }

    return all.ToArray();
}

}