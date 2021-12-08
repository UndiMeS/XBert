using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Solution : MonoBehaviour
{

    public float NumbersSolution;
    public int EatenNumberCounter;
    public GameObject ZeroLeft;
    public GameObject ZeroRight;

    public int FirstStar;
    public int SecondStar;
    public int ThirdStar;

    public SpriteRenderer StarOne;
    public SpriteRenderer StarTwo;
    public SpriteRenderer StarThree;
    public Sprite YellowStar;

    public TMP_Text EatenCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = NumbersSolution.ToString();
        EatenCounter.text = EatenNumberCounter.ToString();

        if(EatenNumberCounter <= FirstStar)
        {
            StarOne.sprite = YellowStar;
        }

        if(EatenNumberCounter <= SecondStar)
        {
            StarTwo.sprite = YellowStar;
        }

        if(EatenNumberCounter <= ThirdStar)
        {
            StarThree.sprite = YellowStar;
        }

        if(NumbersSolution != 0)
        {
            ZeroLeft.SetActive(false);
            ZeroRight.SetActive(false);
        }
    }
}
