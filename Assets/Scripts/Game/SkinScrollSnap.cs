using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinScrollSnap : MonoBehaviour
{


    public RectTransform panel;
    public GameObject[] contents;
    public RectTransform center;


    public Image[] SkinImages;
    public Image[] TitleBackgrounds;
    public TMP_Text[] SkinText;
    public Color[] SkinColor;
    public Image[] NewLabel;

    public GameObject[] SkinContainers;

    public Vector3 SkinImageSize;

    public float ScaleMultiplier;

    public bool next = false;
    public bool back = false;
    public bool backpressed = false;
    public bool nextpressed = false;
    public Button Nextbutton;
    public Button Backbutton;
    public Button SelectButton;
    public float nextX;
    public float backX;
    public float currentX;


    public float[] distance;
    public float[] distReposition;
    private bool dragging = false;
    private int contentDistance;
    private int minContentNum;

    public Vector3 initialScale;
    // Start is called before the first frame update
    void Start()
    {
        int ContentLength = contents.Length;
        distance = new float[ContentLength];
        distReposition = new float[ContentLength];
        initialScale = SkinImages[0].transform.localScale;

        contentDistance = (int)Mathf.Abs(contents[1].GetComponent<RectTransform>().anchoredPosition.x - contents[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < contents.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - contents[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            if(distReposition[i] > 25)
            {
                float curX = contents[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = contents[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchorPos = new Vector2(curX + (contents.Length * contentDistance), curY);
                contents[i].GetComponent<RectTransform>().anchoredPosition = newAnchorPos;
            }
            if(distReposition[i] < -25)
            {
                 float curX = contents[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = contents[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchorPos = new Vector2(curX - (contents.Length * contentDistance), curY);
                contents[i].GetComponent<RectTransform>().anchoredPosition = newAnchorPos;
            }
            
            if(SkinContainers[i].transform.localScale.x >= 0.01f)
            {

                SkinImageSize = Vector3.Lerp(SkinContainers[i].transform.localScale,new Vector3(Mathf.Clamp(1.5f/distance[i],0.1f,1.0f),Mathf.Clamp(1.5f/distance[i],0.1f,1.0f),1.0f), 10f);
                SkinContainers[i].transform.localScale = new Vector3(SkinImageSize.x,SkinImageSize.y,1.0f);

                SkinColor[i] = SkinImages[i].color;
                SkinImages[i].color = Color.Lerp(SkinColor[i],new Color(SkinColor[i].r, SkinColor[i].g, SkinColor[i].b, Mathf.Clamp(1/distance[i],0.1f,1.0f)), 1f);


                SkinColor[i] = TitleBackgrounds[i].color;
                TitleBackgrounds[i].color = Color.Lerp(SkinColor[i],new Color(SkinColor[i].r, SkinColor[i].g, SkinColor[i].b, Mathf.Clamp(1/distance[i],0.1f,1.0f)), 1f);
            

                SkinColor[i] = SkinText[i].color;
                SkinText[i].color = Color.Lerp(SkinColor[i],new Color(SkinColor[i].r, SkinColor[i].g, SkinColor[i].b, Mathf.Clamp(1/distance[i],0.1f,1.0f)), 1f);
            
                SkinColor[i] = NewLabel[i].color;
                NewLabel[i].color = Color.Lerp(SkinColor[i],new Color(SkinColor[i].r, SkinColor[i].g, SkinColor[i].b, Mathf.Clamp(1/distance[i],0.1f,1.0f)), 1f);



            }

            



        }

        //Array.Sort(distance);

        float minDistance = Mathf.Min(distance);

        for(int a = 0; a < contents.Length; a++)
        {
            if(minDistance == distance[a])
            {

                minContentNum = a;

                if(contents[a].GetComponent<SkinController>().unlocked == true)
                {
                    SkinManager.selectedSkin = a;
                    SelectButton.interactable = true;
                }
                else
                {
                    SkinManager.selectedSkin = 0;
                    SelectButton.interactable = false;
                }

                

                currentX = contents[a].GetComponent<RectTransform>().anchoredPosition.x;

                if(back == true && backpressed == true) 
                    {

                        backX = currentX - contentDistance;

                        backpressed = false;
                        
                    }

                if(next == true && nextpressed == true) 
                    {

                        nextX = currentX + contentDistance;

                        nextpressed = false;
                        
                    }
                
            }
        }
        if(!dragging && back == false && next == false)
        {
            //LerpToSkin(minContentNum *- contentDistance);

            LerpToSkin(-contents[minContentNum].GetComponent<RectTransform>().anchoredPosition.x, 10.0f);

        }
        else if(!dragging && back == true) {
            LerpToSkin(-backX, 5.0f);

            if(currentX == backX)
            {
                back = false;
                backX = 0f;
            }
        }
        else if(!dragging && next == true) {
            LerpToSkin(-nextX, 5.0f);

            if(currentX == nextX)
            {
                next = false;
                nextX = 0f;
            }
        }
    }

    void LerpToSkin(float position, float time)
    {
        float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * time);
        Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }

    public void NextButton()
    {
        next = true;
        nextpressed = true;
        
    }

    public void BackButton()
    {
        back = true;
        backpressed = true;

        
    }
}
