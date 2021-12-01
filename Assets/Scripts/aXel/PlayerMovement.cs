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

    public Rigidbody2D rb;

    public float movementStep;
    public float step;

    public Vector3 targetposition;

    private CharacterController controller;

    public Vector3 startPosition;

    //public float dashSpeed;
    //private float dashTime;
    //public float startDashTime;

    public bool ButtonOff;

    public float timeElapsed;

    public Vector3 savedPosition;

    public Vector3 StartPosition;
    public Quaternion StartRotation;

    public GameObject[] NumbersEaten;

    public BoxCollider2D UpButton;
    public BoxCollider2D RightButton;
    public BoxCollider2D DownButton;
    public BoxCollider2D LeftButton;

    public Animator animator;

    public float speed;

    public GameObject Solution;
    public bool OneFinished;
    public bool TwoFinished;
    public bool ThreeFinished;
    public float solution;


    public float moveSpeed = 5.0f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public GameObject Pause;

    public bool Drill;
    public bool smash;

    public WallDestroy DestroyWall;
    public Collider2D Wall;

    public static bool moving = true;



    // Start is called before the first frame update
    void Start () {

        movePoint.SetParent (null);
        movePoint.position = this.gameObject.transform.position;
        StartPosition = this.transform.position;
        UpButton = Up.GetComponent<BoxCollider2D> ();
        RightButton = Right.GetComponent<BoxCollider2D> ();
        DownButton = Down.GetComponent<BoxCollider2D> ();
        LeftButton = Left.GetComponent<BoxCollider2D> ();

        rb = GetComponent<Rigidbody2D> ();

        

        //targetposition = new Vector3 (-3.0f, -43.0f, 0.0f);

        // this.transform.position = StartPosition;
        // this.transform.rotation = StartRotation;

    }

    // Update is called once per frame

    void Update () {

        OneFinished = Solution.GetComponent<SolutionNumbers>().spinOne;
        TwoFinished = Solution.GetComponent<SolutionNumbers>().spinTwo;
        ThreeFinished = Solution.GetComponent<SolutionNumbers>().spinThree;
        solution = Solution.GetComponent<SolutionNumbers>().Solution;



        NumbersEaten = FindGameObjectsWithTags(new string[] {"Numbers","Multiply","Divide","Amount","Square"});

        foreach(GameObject NumberEaten in NumbersEaten)
        {
            if(NumberEaten.GetComponent<aXelNumber>().Eaten == true)
            {
                animator.SetBool("Eat", true);
                animator.SetTrigger("EatTrigger");
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

        if(solution >= 10.0f && OneFinished == false)
        {

            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            //rb.transform.rotation = Quaternion.Euler (0, 0, 90.0f);

        }

        if(OneFinished == true && TwoFinished == false && solution <= -10.0f)
        {

            transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        }

        if(TwoFinished == true && solution >= 10.0f)
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


            //startPosition = new Vector3 (rb.transform.localPosition.x, rb.transform.localPosition.y, rb.transform.localPosition.z);

            //targetposition = new Vector3 (rb.transform.localPosition.x, rb.transform.localPosition.y + step, rb.transform.localPosition.z);

                if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3 (0.0f,step, 0.0f);
                }
                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, whatStopsMovement) && Drill == true)
            {
                //movePoint.position += new Vector3 (0.0f,step, 0.0f);
                animator.SetBool("drill", false);
            Drill = false;

            //Wall.DestroyWall.DestroyUp = true;


               
            //smash = true;
            }

                
            
            
            
            

             //UpPress = false;
             Up.GetComponent<ControllerClick> ().selected = false;

        }
        if (RightPress == true) {
            rb.transform.rotation = Quaternion.Euler (0, 0, 0.0f);

            //targetposition = new Vector3 (rb.transform.localPosition.x + step, rb.transform.localPosition.y, rb.transform.localPosition.z);
            
            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3 (step, 0.0f, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (step,0.0f, 0.0f), .2f, whatStopsMovement) && Drill == true)
            {
                //movePoint.position += new Vector3 (step,0.0f, 0.0f);
                animator.SetBool("drill", false);
            Drill = false;
            //smash = true;
            }
            

            //RightPress = false;

            Right.GetComponent<ControllerClick> ().selected = false;
        }
        if (LeftPress == true) {
            rb.transform.rotation = Quaternion.Euler (180.0f, 0, -180.0f);

            //targetposition = new Vector3 (rb.transform.localPosition.x + -step, rb.transform.localPosition.y, rb.transform.localPosition.z);
            
            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3 (-step, 0.0f, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, whatStopsMovement) && Drill == true)
            {
                //movePoint.position += new Vector3 (-step, 0.0f, 0.0f);
                animator.SetBool("drill", false);
            Drill = false;
            //smash = true;
            }
            

            //LeftPress = false;
            Left.GetComponent<ControllerClick> ().selected = false;
        }
        if (DownPress == true) {
            rb.transform.rotation = Quaternion.Euler (0, 0, -90.0f);

            //targetposition = new Vector3 (rb.transform.localPosition.x, rb.transform.localPosition.y + -step, rb.transform.localPosition.z);
            
            if(! Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3 (0.0f,-step, 0.0f);
            }
            else if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, whatStopsMovement) && Drill == true)
            {
                //movePoint.position += new Vector3 (0.0f,-step, 0.0f);
                animator.SetBool("drill", false);
            Drill = false;
            

            
        }
        //DownPress = false;
            Down.GetComponent<ControllerClick> ().selected = false;

    }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Drill" && Drill == false)
        {
            Drill = true;

            animator.SetBool("drill", true);

            Destroy(col.gameObject);
        }

        if(col.tag == "Wall" && Drill == true)
        {
            //Destroy(col.gameObject);

            

            //Destroy (col.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.0f); 

            // animator.SetBool("drill", false);
            // Drill = false;
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