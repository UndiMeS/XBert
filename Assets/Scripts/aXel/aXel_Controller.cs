using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aXel_Controller : MonoBehaviour
{

    public GameObject Up;
    public GameObject Right;
    public GameObject Down;
    public GameObject Left;

    public Rigidbody2D aXel;

    public bool UpPress;
    public bool RightPress;
    public bool DownPress;
    public bool LeftPress;

    public float movementStep = 0.1f;
    public float step = 100.0f;

    public Vector3 targetposition;
    // Start is called before the first frame update
    void Start()
    {
        //aXel.transform.position = new Vector3(0.0f,0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void FixedUpdate()
    {

        UpPress = Up.GetComponent<ControllerClick>().selected;
        RightPress = Right.GetComponent<ControllerClick>().selected;
        DownPress = Down.GetComponent<ControllerClick>().selected;
        LeftPress = Left.GetComponent<ControllerClick>().selected;
        move();
    }

    void move()
    {
        if(UpPress==true)
        {

            aXel.transform.rotation = Quaternion.Euler(0,0, 90.0f);

                //aXel.transform.position = Vector3.MoveTowards (aXel.transform.position, new Vector3(aXel.transform.position.x, aXel.transform.position.y + step, aXel.transform.position.z), movementStep * Time.fixedDeltaTime);
                aXel.transform.position +=Vector3.up * step;
                UpPress = false;

        }
        if(RightPress==true)
        {
            aXel.transform.rotation = Quaternion.Euler(0,0, 0.0f);
            aXel.transform.position = Vector3.MoveTowards (aXel.transform.position, new Vector3( aXel.transform.position.x + step, aXel.transform.position.y, aXel.transform.position.z), movementStep * Time.deltaTime);
            RightPress = false;
            
            //yield return new WaitForSeconds(1.0f);
        }
        if(LeftPress==true)
        {
            aXel.transform.rotation = Quaternion.Euler(180.0f,0, -180.0f);
            aXel.transform.position = Vector3.MoveTowards (aXel.transform.position, new Vector3( aXel.transform.position.x + -step, aXel.transform.position.y, aXel.transform.position.z), movementStep * Time.deltaTime);
            LeftPress = false;
        }
        if(DownPress==true)
        {
            aXel.transform.rotation = Quaternion.Euler(0,0, -90.0f);
            aXel.transform.position -=Vector3.up * step;
            //aXel.transform.position = Vector3.MoveTowards (aXel.transform.position, new Vector3(aXel.transform.position.x, aXel.transform.position.y + -step, aXel.transform.position.z), movementStep * Time.fixedDeltaTime);
            DownPress = false;
        }
    }

}
