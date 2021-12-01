using System.Collections;
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

    public bool DestroyUp;
    public bool DestroyDown;
    public bool DestroyLeft;
    public bool DestroyRight;
    // Start is called before the first frame update
    void Start()
    {
        movement = axel.gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,-step, 0.0f), .2f, Axel) && movement.UpPress == true)
        {
            DestroyUp = true;
        }

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (0.0f,step, 0.0f), .2f, Axel) && movement.DownPress == true)
        {
            DestroyDown = true;
        }

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (step, 0.0f, 0.0f), .2f, Axel) && movement.LeftPress == true)
        {
            DestroyLeft = true;
        }

        if(Physics2D.OverlapCircle(movePoint.position + new Vector3 (-step,0.0f, 0.0f), .2f, Axel) && movement.RightPress == true)
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
                 if(movement.smash == true)
                {
                    animator.SetBool("smash", true);
                    Destroy (this.gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.0f);
                    movement.smash = false;

                    // DestroyUp = false;
                    // DestroyDown = false;
                    // DestroyLeft = false;
                    // DestroyRight = false;
                }
            }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Axel")
        {
           
            
        }
    }
}
