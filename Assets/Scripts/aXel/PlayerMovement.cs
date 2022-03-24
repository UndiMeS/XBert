using System.Collections;
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

    public bool UpMove;
    public bool RightMove;
    public bool DownMove;
    public bool LeftMove;

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

        



        UpPress = Up.GetComponent<ControllerClick> ().pressed;
        RightPress = Right.GetComponent<ControllerClick> ().pressed;
        DownPress = Down.GetComponent<ControllerClick> ().pressed;
        LeftPress = Left.GetComponent<ControllerClick> ().pressed;


        UpMove= Up.GetComponent<ControllerClick> ().selected;
        RightMove = Right.GetComponent<ControllerClick> ().selected;
        DownMove = Down.GetComponent<ControllerClick> ().selected;
        LeftMove = Left.GetComponent<ControllerClick> ().selected;

        if(UpPress == true)
        {
            RightPress = false;
            DownPress = false;
            LeftPress = false;

            //UpMove = true;
        }
        else if(RightPress == true)
        {
            UpPress = false;
            DownPress = false;
            LeftPress = false;


            //RightMove = true;
        }
        else if(DownPress == true)
        {
            RightPress = false;
            UpPress = false;
            LeftPress = false;

            //DownMove = true;
        }
        else if(LeftPress == true)
        {
            RightPress = false;
            DownPress = false;
            UpPress = false;

            //LeftMove = true;
        }
        //move ();


        if(Finished == true)
        {
            UpPress = false;
            DownPress = false;
            RightPress = false;
            LeftPress = false;

            transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.01f && moving == true)
        {
            move();
        }

        


        // if(UpMove == true || DownMove == true || RightMove == true || LeftMove == true)
        // {
            
        // }
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
                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, BreakingWall) && Drill == true && UpMove == true )
            {
            animator.SetBool("drill", false);
            //Drill = false;

            }
            

            // if( Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, whatStopsMovement) &&  Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, BreakingWall))
            //     {
            //         UpMove = false;
            //     }

             Up.GetComponent<ControllerClick> ().selected = false;

        }
        if (RightPress == true) {
            rb.transform.rotation = Quaternion.Euler (0, 0, 0.0f);
     
            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, whatStopsMovement)&&! Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, BreakingWall))
            {
                movePoint.position += new Vector3 (step, 0.0f, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, BreakingWall) && Drill == true && RightMove == true)
            {

                animator.SetBool("drill", false);
            //Drill = false;

            }
            
            // if( Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, whatStopsMovement) &&  Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, BreakingWall))
            //     {
            //         RightMove = false;
            //     }


            Right.GetComponent<ControllerClick> ().selected = false;
        }
        if (LeftPress == true) {
            rb.transform.rotation = Quaternion.Euler (180.0f, 0, -180.0f);
  
            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, whatStopsMovement)&&! Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, BreakingWall))
            {
                movePoint.position += new Vector3 (-step, 0.0f, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, BreakingWall) && Drill == true && LeftMove == true)
            {

                animator.SetBool("drill", false);
            //Drill = false;

            }
            
            // if( Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, whatStopsMovement) &&  Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, BreakingWall))
            //     {
            //         LeftMove = false;
            //     }

            Left.GetComponent<ControllerClick> ().selected = false;
        }
        if (DownPress == true) {
            rb.transform.rotation = Quaternion.Euler (0, 0, -90.0f);

            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, whatStopsMovement) &&! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, BreakingWall))
            {
                movePoint.position += new Vector3 (0.0f,-step, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, BreakingWall) && Drill == true && DownMove == true)
            {

                animator.SetBool("drill", false);
            //Drill = false;
            

            
        }

        // if( Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f, -step, 0.0f), .2f, whatStopsMovement) &&  Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f, -step, 0.0f), .2f, BreakingWall))
        //         {
        //             DownMove = false;
        //         }
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