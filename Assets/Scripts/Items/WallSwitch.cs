using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{


    public Sprite ButtonPressen;
    public Sprite ButtonNotPressen;
    public Sprite RedWallOn;
    public Sprite RedWallOff;
    public Sprite BlueWallOn;
    public Sprite BlueWallOff;
    public SpriteRenderer ButtonRenderer;
    public GameObject[] blueWalls;
    public GameObject[] redWalls;

    public bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        blueWalls = GameObject.FindGameObjectsWithTag("BlueWall");
        redWalls = GameObject.FindGameObjectsWithTag("RedWall");
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed == true)
        {
            

        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "Axel")
        {
            ButtonRenderer.sprite = ButtonPressen;
            pressed = !pressed;


            if(pressed == true)
            {
                foreach (GameObject BlueWall in blueWalls)
                {
                    BlueWall.GetComponent<SpriteRenderer>().sprite = BlueWallOff;
                    BlueWall.GetComponent<BoxCollider2D>().enabled = false;
                }

                foreach (GameObject RedWall in redWalls)
                {
                    RedWall.GetComponent<SpriteRenderer>().sprite = RedWallOn;
                    RedWall.GetComponent<BoxCollider2D>().enabled = true;
                }
            }

            if(pressed == false)
            {
                foreach (GameObject BlueWall in blueWalls)
                {
                    BlueWall.GetComponent<SpriteRenderer>().sprite = BlueWallOn;
                    BlueWall.GetComponent<BoxCollider2D>().enabled = true;
                }

                foreach (GameObject RedWall in redWalls)
                {
                    RedWall.GetComponent<SpriteRenderer>().sprite = RedWallOff;
                    RedWall.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            

        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if(col.tag == "Axel")
        {
            ButtonRenderer.sprite = ButtonNotPressen;
        }
    }
}
