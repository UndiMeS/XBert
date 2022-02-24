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

    public bool Subtract;
    

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

            if(this.gameObject.tag == "Multiply" || this.gameObject.tag == "Divide")
            {
                //this.gameObject.GetComponent<TMP_Text>().text.Substring(1);
                


                if(float.TryParse(this.gameObject.GetComponent<TMP_Text>().text.Substring(1), out result))
                {
                
                    value = result;
                    
                }
            }

            else if (this.gameObject.tag == "Numbers")
            {
                if(float.TryParse(this.gameObject.GetComponent<TMP_Text>().text, out result))
                {
                    value = result;
                    
                }
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
                
                //GameObject.Find("Solution").GetComponent<SolutionNumbers>().VariableSolution -= variable;

                if(GameObject.Find("Zero_Left") != null)
                {
                    
                    GameObject.Find("Zero_Left").SetActive(false);
                }

                if(Subtract == true)
                {
                    GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += "-(" + this.gameObject.GetComponent<TMP_Text>().text + ")";
                    GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution += -value;
                }
                else
                {
                    GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += "+(" + this.gameObject.GetComponent<TMP_Text>().text + ")";
                    GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution += +value;
                }

                

                

                
            }

            if(this.gameObject.tag == "Multiply")
            {
                    this.gameObject.GetComponent<TMP_Text>().text = this.gameObject.GetComponent<TMP_Text>().text.Replace("(","");
                this.gameObject.GetComponent<TMP_Text>().text = this.gameObject.GetComponent<TMP_Text>().text.Replace(")","");

                if(GameObject.Find("Zero_Right") != null)
                {
                    
                    GameObject.Find("Zero_Right").SetActive(false);
                    GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "0";
                }

                GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ") " + this.gameObject.GetComponent<TMP_Text>().text;
                GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution *= value;
            }

            if(this.gameObject.tag == "Divide")
            {
                    
                if(GameObject.Find("Zero_Right") != null)
                {
                    
                    GameObject.Find("Zero_Right").SetActive(false);
                    GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "0";
                }


                GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ") " + this.gameObject.GetComponent<TMP_Text>().text;
                GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution /= value;
            }


            if(this.gameObject.tag == "Amount")
            {
                if(GameObject.Find("Zero_Right") != null)
                {
                    
                    GameObject.Find("Zero_Right").SetActive(false);
                    GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "0";
                }


                GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "|" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + "| ";
                GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution = Mathf.Abs(GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution);
            }

            if(this.gameObject.tag == "Square")
            {
                if(GameObject.Find("Zero_Right") != null)
                {
                    
                    GameObject.Find("Zero_Right").SetActive(false);
                    GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "0";
                }


                GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ")<sup>2</sup> ";
                GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution = Mathf.Pow(GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution, 2.0f);
            }





    }

    

    
}
void OnTriggerStay2D(Collider2D col)
{
    if(col.gameObject.tag == "SubtractZone")
    {
        Subtract = true;
    }
}


}
