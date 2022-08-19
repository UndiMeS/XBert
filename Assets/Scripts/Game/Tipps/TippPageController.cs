using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TippPageController : MonoBehaviour
{
    public Image PageNumberOne;
    public Image PageNumberTwo;
    public Image PageNumberThree;

    public Sprite PageOneSelected;
    public Sprite PageTwoSelected;
    public Sprite PageThreeSelected;

    public Sprite PageOneNotSelected;
    public Sprite PageTwoNotSelected;
    public Sprite PageThreeNotSelected;
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
    }
}
