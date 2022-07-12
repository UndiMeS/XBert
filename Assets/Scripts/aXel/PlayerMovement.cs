using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
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

    public bool UpRun;
    public bool RightRun;
    public bool DownRun;
    public bool LeftRun;

    public bool FirstUp;
    public bool FirstRight;
    public bool FirstDown;
    public bool FirstLeft;

    public bool FirstUpTwo;

    public bool UpTab;

    public float RunTimer;

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
    void Start()
    {
        movePoint.SetParent(MovePointParent.transform);
        movePoint.position = this.gameObject.transform.position;
        StartPosition = this.gameObject.transform.position;

        PlayerMovement.moving = true;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        Finished = Solution.GetComponent<Solution>().LevelFinished;

        NumbersEaten = FindGameObjectsWithTags(
            new string[] { "Numbers", "Multiply", "Divide", "Amount", "Square" }
        );

        foreach (GameObject NumberEaten in NumbersEaten)
        {
            if (NumberEaten.GetComponent<aXelNumber>().Eaten == true)
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

        UpPress = Up.GetComponent<ControllerClick>().pressed;
        RightPress = Right.GetComponent<ControllerClick>().pressed;
        DownPress = Down.GetComponent<ControllerClick>().pressed;
        LeftPress = Left.GetComponent<ControllerClick>().pressed;

        UpMove = Up.GetComponent<ControllerClick>().selected;
        RightMove = Right.GetComponent<ControllerClick>().selected;
        DownMove = Down.GetComponent<ControllerClick>().selected;
        LeftMove = Left.GetComponent<ControllerClick>().selected;

        if (UpPress == true)
        {
            RightPress = false;
            DownPress = false;
            LeftPress = false;

            //UpRun = false;

            //UpMove = true;
        }
        else if (RightPress == true)
        {
            UpPress = false;
            DownPress = false;
            LeftPress = false;

            //RightMove = true;
        }
        else if (DownPress == true)
        {
            RightPress = false;
            UpPress = false;
            LeftPress = false;

            //DownMove = true;
        }
        else if (LeftPress == true)
        {
            RightPress = false;
            DownPress = false;
            UpPress = false;

            //LeftMove = true;
        }
        if (UpPress == false)
        {
            UpRun = false;
            FirstUpTwo = false;
        }
        if (DownPress == false)
        {
            DownRun = false;
            //FirstDown = false;
        }
        if (RightPress == false)
        {
            RightRun = false;
            //FirstRight = false;
        }
        if (LeftPress == false)
        {
            LeftRun = false;
            //FirstLeft = false;
        }
        //move ();


        if (Finished == true)
        {
            UpPress = false;
            DownPress = false;
            RightPress = false;
            LeftPress = false;

            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            movePoint.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f && moving == true)
        {


            StartCoroutine(move());
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                Debug.Log("not playing");
                smash = true;
            }
        }
    }

    public IEnumerator move()
    {
        if (UpPress == true)
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 90.0f);

            if (UpRun == false && FirstUp == true)
            {
                moving = false;
                yield return new WaitForSeconds(RunTimer);
                if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
                {
                    moving = true;
                    UpRun = true;
                }
            }

            if (
                FirstUp == false
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, step, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, step, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                FirstUp = true;
                movePoint.position += new Vector3(0.0f, step, 0.0f);
                
            }
            else if (
                Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, step, 0.0f),
                    .2f,
                    BreakingWall
                )
                && Drill == true
                && UpMove == true
            )
            {
                animator.SetBool("drill", false);

                //Drill = false;
            }

            if (
                UpPress == true
                && UpRun == true
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, step, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, step, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                movePoint.position += new Vector3(0.0f, step, 0.0f);
            }
            // else if (
            //     Physics2D.OverlapCircle(
            //         movePoint.position + new Vector3(0.0f, step, 0.0f),
            //         .2f,
            //         BreakingWall
            //     )
            //     && Drill == true
            //     && UpMove == true
            // )
            // {
            //     animator.SetBool("drill", false);

            // }

          





            Up.GetComponent<ControllerClick>().selected = false;
        }
        else
        {
            FirstUp = false;
        }
        if (RightPress == true)
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 0.0f);

            if (RightRun == false && FirstRight == true)
            {
                moving = false;
                yield return new WaitForSeconds(RunTimer);
                if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
                {
                    moving = true;
                    RightRun = true;
                }
            }

            if (
                FirstRight == false
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(step, 0.0f, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(step, 0.0f, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                movePoint.position += new Vector3(step, 0.0f, 0.0f);
                FirstRight = true;
            }
            else if (
                Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(step, 0.0f, 0.0f),
                    .2f,
                    BreakingWall
                )
                && Drill == true
                && RightMove == true
            )
            {
                animator.SetBool("drill", false);
                //Drill = false;
            }

            if (
                RightPress == true
                && RightRun == true
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(step, 0.0f, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(step, 0.0f, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                movePoint.position += new Vector3(step, 0.0f, 0.0f);
            }
            // else if (
            //     Physics2D.OverlapCircle(
            //         movePoint.position + new Vector3(step, 0.0f, 0.0f),
            //         .2f,
            //         BreakingWall
            //     )
            //     && Drill == true
            //     && RightMove == true
            // )
            // {
            //     animator.SetBool("drill", false);
            //     //Drill = false;
            // }

            Right.GetComponent<ControllerClick>().selected = false;
        }
        else
        {
            FirstRight = false;
        }
        if (LeftPress == true)
        {
            rb.transform.rotation = Quaternion.Euler(180.0f, 0, -180.0f);

            if (LeftRun == false && FirstLeft == true)
            {
                moving = false;
                yield return new WaitForSeconds(RunTimer);
                if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
                {
                    moving = true;
                    LeftRun = true;
                }
            }

            if (
                FirstLeft == false
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(-step, 0.0f, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(-step, 0.0f, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                movePoint.position += new Vector3(-step, 0.0f, 0.0f);
                FirstLeft = true;
            }
            else if (
                Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(-step, 0.0f, 0.0f),
                    .2f,
                    BreakingWall
                )
                && Drill == true
                && LeftMove == true
            )
            {
                animator.SetBool("drill", false);
                //Drill = false;
            }

            if (
                LeftPress == true
                && LeftRun == true
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(-step, 0.0f, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(-step, 0.0f, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                movePoint.position += new Vector3(-step, 0.0f, 0.0f);
            }
            // else if (
            //     Physics2D.OverlapCircle(
            //         movePoint.position + new Vector3(-step, 0.0f, 0.0f),
            //         .2f,
            //         BreakingWall
            //     )
            //     && Drill == true
            //     && LeftMove == true
            // )
            // {
            //     animator.SetBool("drill", false);
            //     //Drill = false;
            // }

            Left.GetComponent<ControllerClick>().selected = false;
        }
        else
        {
            FirstLeft = false;
        }
        if (DownPress == true)
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, -90.0f);

            if (DownRun == false && FirstDown == true)
            {
                moving = false;
                yield return new WaitForSeconds(RunTimer);
                if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
                {
                    moving = true;
                    DownRun = true;
                }
            }

            if (
                FirstDown == false
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, -step, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, -step, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                movePoint.position += new Vector3(0.0f, -step, 0.0f);
                FirstDown = true;
            }
            else if (
                Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, -step, 0.0f),
                    .2f,
                    BreakingWall
                )
                && Drill == true
                && DownMove == true
            )
            {
                animator.SetBool("drill", false);
            }

            if (
                DownPress == true
                && DownRun == true
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, -step, 0.0f),
                    .2f,
                    whatStopsMovement
                )
                && !Physics2D.OverlapCircle(
                    movePoint.position + new Vector3(0.0f, -step, 0.0f),
                    .2f,
                    BreakingWall
                )
            )
            {
                movePoint.position += new Vector3(0.0f, -step, 0.0f);
            }
            // else if (
            //     Physics2D.OverlapCircle(
            //         movePoint.position + new Vector3(0.0f, -step, 0.0f),
            //         .2f,
            //         BreakingWall
            //     )
            //     && Drill == true
            //     && DownMove == true
            // )
            // {
            //     animator.SetBool("drill", false);
            // }

            Down.GetComponent<ControllerClick>().selected = false;
        }
        else
        {
            FirstDown = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Drill" && Drill == false)
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
