using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class aXelNumber : MonoBehaviour
{
    public int LeftPlaces = 5;
    public bool Eaten = false;
    public GameObject NumberPlace;
    private BoxCollider2D BoxCollider;
    public float value;
    public float variable;

    float result;
    

    // Start is called before the first frame update
    void Start()
    {
        Eaten = false;
        BoxCollider = this.GetComponent<BoxCollider2D>();

        if(this.gameObject.GetComponent<TMP_Text>().text.Contains("x") && this.gameObject.GetComponent<TMP_Text>().text != "+x" && this.gameObject.GetComponent<TMP_Text>().text != "-x")
        {

            if(float.TryParse(this.gameObject.GetComponent<TMP_Text>().text.Substring(0, this.gameObject.GetComponent<TMP_Text>().text.Length - 1), out result))
            {
                variable = result;
                //variable = float.Parse(this.gameObject.GetComponent<TMP_Text>().text.Substring(0, this.gameObject.GetComponent<TMP_Text>().text.Length - 1));
                Debug.Log("variable with x");
            }

        }


        if(this.gameObject.GetComponent<TMP_Text>().text != "+x" && this.gameObject.GetComponent<TMP_Text>().text != "-x")
        {

             if(float.TryParse(this.gameObject.GetComponent<TMP_Text>().text, out result))
            {
                value = result;
                
            }
            
        
        }

        if(this.gameObject.GetComponent<TMP_Text>().text == "+x")
        {
            variable = +1.0f;
        }
        else if(this.gameObject.GetComponent<TMP_Text>().text == "-x")
        {
            variable = -1.0f;
        }


        
        //Debug.Log(GetComponent<TMP_Text>().text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.transform.gameObject.name =="aXel")
        {
            GameObject.Find("Solution").GetComponent<Solution>().EatenNumberCounter ++;
            Eaten = true;
            
            if(this.gameObject.tag == "Numbers")
            {
                GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution += value;
                //GameObject.Find("Solution").GetComponent<SolutionNumbers>().VariableSolution -= variable;

                if(GameObject.Find("Zero_Left") != null)
                {
                    
                    GameObject.Find("Zero_Left").SetActive(false);
                }

                GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += this.gameObject.GetComponent<TMP_Text>().text;

                
                //this.gameObject.SetActive(false);
            }


        //     if(this.gameObject.tag == "aXelNumberRight")
        //     {
        //         GameObject.Find("NumbersSolution").GetComponent<SolutionNumbers>().NumbersSolution -= value;
        //         GameObject.Find("NumbersSolution").GetComponent<SolutionNumbers>().VariableSolution += variable;

        //         if(GameObject.Find("Zero_Right") != null)
        //         {
                    
        //             GameObject.Find("Zero_Right").SetActive(false);
        //         }

        //         GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += this.gameObject.GetComponent<TMP_Text>().text;

                
        //         //this.gameObject.SetActive(false);


        //     }
            
        
        // }


    }
}
}
