using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSprites : MonoBehaviour
{
    public GameObject ControllerUp;
    public GameObject ControllerDown;
    public GameObject ControllerLeft;
    public GameObject ControllerRight;

    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;
    public Sprite Default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ControllerUp.GetComponent<ControllerClick>().pressed == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
        }
        else if(ControllerDown.GetComponent<ControllerClick>().pressed == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
        }
        else if(ControllerLeft.GetComponent<ControllerClick>().pressed == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Left;
        }
        else if(ControllerRight.GetComponent<ControllerClick>().pressed == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Right;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Default;
        }
    }
}
