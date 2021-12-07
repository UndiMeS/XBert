using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{


    public Sprite ButtonPressed;
    public Sprite ButtonNotPressed;
    public Sprite RedWallOn;
    public Sprite RedWallOff;
    public Sprite BlueWallOn;
    public Sprite BlueWallOff;
    public SpriteRenderer ButtonRenderer;
    public GameObject[] blueWalls;
    public GameObject[] redWalls;
    public bool SingleSwitch;

    public bool pressed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "Axel")
        {
            ButtonRenderer.sprite = ButtonPressed;

            if(SingleSwitch == true)
            {
                pressed = true;
            }
            else if (SingleSwitch == false)
            {
                pressed = !pressed;
            }
            


            if(pressed == true)
            {
                if(blueWalls != null)
                {
                    foreach (GameObject BlueWall in blueWalls)
                    {
                        BlueWall.GetComponent<SpriteRenderer>().sprite = BlueWallOff;
                        BlueWall.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
                
                if(redWalls != null)
                {
                    foreach (GameObject RedWall in redWalls)
                    {
                        RedWall.GetComponent<SpriteRenderer>().sprite = RedWallOn;
                        RedWall.GetComponent<BoxCollider2D>().enabled = true;
                    }
                }
                
            }

            if(pressed == false)
            {
                if(blueWalls != null)
                {
                    foreach (GameObject BlueWall in blueWalls)
                    {
                        BlueWall.GetComponent<SpriteRenderer>().sprite = BlueWallOn;
                        BlueWall.GetComponent<BoxCollider2D>().enabled = true;
                    }
                }
                
                if(redWalls != null)
                {
                    foreach (GameObject RedWall in redWalls)
                    {
                        RedWall.GetComponent<SpriteRenderer>().sprite = RedWallOff;
                        RedWall.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
                
            }
            

        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if(col.tag == "Axel")
        {
            if(SingleSwitch == false)
            {
                ButtonRenderer.sprite = ButtonNotPressed;
            }
            
        }
    }
}
