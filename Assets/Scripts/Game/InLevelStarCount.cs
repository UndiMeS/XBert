using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InLevelStarCount : MonoBehaviour
{

    public Solution solution;
    public bool WorldDone;
    public int StarsDone;
    public GameObject Stars;


    public Image StarOne;
    public Image StarTwo;
    public Image StarThree;

    public GameObject StarFillOne;
    public GameObject StarFillTwo;
    public GameObject StarFillThree;
    public Sprite StarDone;

    // Start is called before the first frame update
    void Start()
    {
       for(int x = 0; x < solution.datas.Count; x++)
       {
            if(solution.datas[x].world == solution.world)
            {
                
                if(solution.datas[x].level == 7)
                {
                    //Debug.Log("World "+solution.world + "Level " + solution.level + "score " + solution.datas[solution.level-1].score);
                    
                    WorldDone = true;
                    
                }
            }
       }

       for(int x = 0; x < solution.datas.Count; x++)
       {
            if( WorldDone == true && solution.datas[x].world == solution.world && solution.datas[x].level == solution.level)
            {
                StarsDone = solution.datas[x].score;
            }
       }

       if(WorldDone == true)
        {
            Stars.SetActive(true);
            
            if(StarsDone == 1)
            {
                StarOne.sprite = StarDone;
            }
            if(StarsDone == 2)
            {
                StarOne.sprite = StarDone;
                StarTwo.sprite = StarDone;
            }
            if(StarsDone == 3)
            {
                StarOne.sprite = StarDone;
                StarTwo.sprite = StarDone;
                StarThree.sprite = StarDone;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(WorldDone == true)
        {
            if(solution.EatenNumberCounter > solution.FirstStar)
            {
                StarFillOne.SetActive(false);
            }
            if(solution.EatenNumberCounter > solution.SecondStar)
            {
                StarFillTwo.SetActive(false);
            }
            if(solution.EatenNumberCounter > solution.ThirdStar)
            {
                StarFillThree.SetActive(false);
            }
        }
    }
}
