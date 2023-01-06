using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TippPageController : MonoBehaviour
{
    public Image PageNumberOne;
    public Image PageNumberTwo;
    public Image PageNumberThree;
    public Image PageNumberFour;

    public Sprite PageOneSelected;
    public Sprite PageTwoSelected;
    public Sprite PageThreeSelected;
    public Sprite PageFourSelected;

    public Sprite PageOneNotSelected;
    public Sprite PageTwoNotSelected;
    public Sprite PageThreeNotSelected;
    public Sprite PageFourNotSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PageOne()
    {
        PageNumberOne.sprite = PageOneSelected;
        PageNumberTwo.sprite = PageTwoNotSelected;
    }


    public void PageTwo()
    {
        PageNumberOne.sprite = PageOneNotSelected;
        PageNumberTwo.sprite = PageTwoSelected;
        PageNumberThree.sprite = PageThreeNotSelected;
    }


    public void PageThree()
    {
        PageNumberThree.sprite = PageThreeSelected;
        PageNumberTwo.sprite = PageTwoNotSelected;
        if(PageNumberFour)
        PageNumberFour.sprite = PageFourNotSelected;
    }

    public void PageFour()
    {
        PageNumberThree.sprite = PageThreeNotSelected;
        PageNumberFour.sprite = PageFourSelected;
    }
}
