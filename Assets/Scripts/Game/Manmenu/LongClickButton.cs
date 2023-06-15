using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.EventSystem;
using UnityEngine.UI;
using TMPro;

public class LongClickButton : MonoBehaviour
{

    public bool pointerDown;
    public float pointerDownTimer;

    //[SerializieField]
    public float requiredHoldTime;
    public float timeToShowText;
    public TMP_Text ButtonText;
    public float textAlpha;
    public bool onLongClick;

    //[SerializieField]
    public Image fillImage;

    //public MenuButtonManager ButtonManager;

    public UnityEvent buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        textAlpha = ButtonText.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //pointerDown = true;

            if(pointerDown == false)
            {
                Debug.Log("pressDown");
                pointerDownTimer = 0.0f;
                pointerDown = true;
            }
           else
            {
                pointerDownTimer += Time.deltaTime;

                if(pointerDownTimer >= timeToShowText)
                {
                    ButtonText.color = new Color(1.0f,1.0f,1.0f,textAlpha);
                }
                else
                {
                    ButtonText.color = new Color(1.0f,1.0f,1.0f,textAlpha);
                }

                

                if (pointerDownTimer >= requiredHoldTime)
                {
                    // Perform long-hold action here
                    onLongClick = true;
                    //ButtonManager.FromIntroToWorldOne();
                    buttonClick.Invoke();
                }
                fillImage.fillAmount = pointerDownTimer / requiredHoldTime;

                textAlpha = Mathf.Lerp(0, timeToShowText, pointerDownTimer/timeToShowText);
            }
        }
        else
        {
            ButtonText.color = new Color(255,255,255,0);
            pointerDown = false;
            pointerDownTimer = 0.0f;
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;

            textAlpha = Mathf.Lerp(0, timeToShowText, pointerDownTimer/timeToShowText);
        }
    }

    // private void Reset()
    // {
    //     pointerDown = false;
    //     pointerDownTimer = 0;
    //     fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    // }
}
