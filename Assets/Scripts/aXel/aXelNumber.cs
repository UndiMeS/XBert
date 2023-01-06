using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;

public class aXelNumber : MonoBehaviour
{
    public int LeftPlaces = 5;
    public bool Eaten = false;
    public GameObject NumberPlace;
    private BoxCollider2D BoxCollider;
    public float value;
    public float variable;

    float tweenTime = 1.2f;
    float tweenSize = 1.2f;
    public string TempText;

    

    CultureInfo culture;

    float result;

    public bool Subtract;

    public Vector3 StartScaleTerm;
    public Vector3 StartScaleSolution;

    void Awake()
    {
        StartScaleTerm = GameObject.Find("Term_Right").transform.localScale;
        StartScaleTerm = GameObject.Find("Solution").transform.localScale;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        Eaten = false;
        BoxCollider = this.GetComponent<BoxCollider2D>();

        if(this.gameObject.GetComponent<TMP_Text>().text.Contains("x") && this.gameObject.GetComponent<TMP_Text>().text != "+x" && this.gameObject.GetComponent<TMP_Text>().text != "-x")
        {

            if(float.TryParse(this.gameObject.GetComponent<TMP_Text>().text.Substring(0, this.gameObject.GetComponent<TMP_Text>().text.Length - 1), NumberStyles.Float, CultureInfo.CreateSpecificCulture("de-DE"), out result))
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
                


                if(float.TryParse(this.gameObject.GetComponent<TMP_Text>().text.Substring(1), NumberStyles.Float, CultureInfo.CreateSpecificCulture("de-DE"), out result))
                {
                
                    value = result;
                    
                }
            }

            else if (this.gameObject.tag == "Numbers")
            {
                if(float.TryParse(this.gameObject.GetComponent<TMP_Text>().text, NumberStyles.Float, CultureInfo.CreateSpecificCulture("de-DE"), out result))
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


                    if(GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Length >= 1)
                    {
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("BF0000", "000000");
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("385723", "000000");
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += "<color=#BF0000>-(" + this.gameObject.GetComponent<TMP_Text>().text + ")</color>";
                    
                    }
                    else
                    {
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += "<color=#BF0000>-(" + this.gameObject.GetComponent<TMP_Text>().text + ")</color>";
                    }



                    //GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += "-(" + this.gameObject.GetComponent<TMP_Text>().text + ")";
                    GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution += -value;

                    LeanTween.cancel(GameObject.Find("Term_Right"));
                    GameObject.Find("Term_Right").transform.localScale = StartScaleTerm;
                    GameObject.Find("Solution").transform.localScale = StartScaleTerm;
                    TweenNumber(GameObject.Find("Term_Right"));
                    TweenNumber(GameObject.Find("Solution"));

                }
                else
                {
                    //GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "<color=#000000>"+ GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + "</color>";
                    

                    if(GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Length >= 1)

                    
                    {
                        // GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Remove(0,15);
                        // GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Substring(0,GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Length-8);
                        // GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "<color=#000000>"+GameObject.Find("Term_Right").GetComponent<TMP_Text>().text  + "</color>" + "<color=#FFC100>+(" + this.gameObject.GetComponent<TMP_Text>().text + ")</color>";
                    
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("385723", "000000");
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("BF0000", "000000");

                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += "<color=#385723>+(" + this.gameObject.GetComponent<TMP_Text>().text + ")</color>";

                        //GameObject.Find("Term_Right").GetComponent<TMP_Text>().outlineWidth = 2.0f;
                        // string text = "Hello <o=2>World</o>!";

                        // GameObject.Find("Term_Right").GetComponent<TextMeshProUGUI>().SetText(text);
                    
                    }
                    else
                    {
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text += "<color=#385723>+(" + this.gameObject.GetComponent<TMP_Text>().text + ")</color>";
                    }
                    


                    
                    GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution += +value;

                    LeanTween.cancel(GameObject.Find("Term_Right"));
                    GameObject.Find("Term_Right").transform.localScale = StartScaleTerm;
                    GameObject.Find("Solution").transform.localScale = StartScaleTerm;
                    TweenNumber(GameObject.Find("Term_Right"));
                    TweenNumber(GameObject.Find("Solution"));
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


                if(GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Length >= 1)
                    {
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("385723", "000000");
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("BF0000", "000000");
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "<color=#385723>(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ")" + this.gameObject.GetComponent<TMP_Text>().text + "</color>";
                    
                    }
                    else
                    {
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "<color=#385723>(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ")" + this.gameObject.GetComponent<TMP_Text>().text + "</color>";
                    }

                //GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ") " + this.gameObject.GetComponent<TMP_Text>().text;
                GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution *= value;

                LeanTween.cancel(GameObject.Find("Term_Right"));
                GameObject.Find("Term_Right").transform.localScale = StartScaleTerm;
                GameObject.Find("Solution").transform.localScale = StartScaleTerm;
                TweenNumber(GameObject.Find("Term_Right"));
                    TweenNumber(GameObject.Find("Solution"));
            }

            if(this.gameObject.tag == "Divide")
            {
                    
                if(GameObject.Find("Zero_Right") != null)
                {
                    
                    GameObject.Find("Zero_Right").SetActive(false);
                    GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "0";
                }


                if(GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Length >= 1)
                    {
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("385723", "000000");
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = GameObject.Find("Term_Right").GetComponent<TMP_Text>().text.Replace("BF0000", "000000");
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "<color=#BF0000>(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ")" + this.gameObject.GetComponent<TMP_Text>().text + "</color>";
                    
                    }
                    else
                    {
                        GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "<color=#BF0000>(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ")" + this.gameObject.GetComponent<TMP_Text>().text + "</color>";
                    }


                //GameObject.Find("Term_Right").GetComponent<TMP_Text>().text = "(" + GameObject.Find("Term_Right").GetComponent<TMP_Text>().text + ") " + this.gameObject.GetComponent<TMP_Text>().text;
                GameObject.Find("Solution").GetComponent<Solution>().NumbersSolution /= value;

                LeanTween.cancel(GameObject.Find("Term_Right"));
                GameObject.Find("Term_Right").transform.localScale = StartScaleTerm;
                GameObject.Find("Solution").transform.localScale = StartScaleTerm;
                TweenNumber(GameObject.Find("Term_Right"));
                TweenNumber(GameObject.Find("Solution"));
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

void TweenNumber(GameObject Number)
{
    LeanTween.cancel(Number);
    transform.localScale = Vector3.one;
    LeanTween.scale(Number, Vector3.one * tweenSize,tweenTime).setEasePunch();
    
}



}
