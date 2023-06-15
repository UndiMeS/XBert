using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSecretLevelController : MonoBehaviour
{

    public LevelLoader levelLoader;
    public string SecretLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.gameObject.name =="aXel")
        {
            levelLoader.ActvateTransition();
            //SceneManager.LoadScene(NextScene);
            levelLoader.LoadScene = SecretLevel;

            levelLoader.OnLevelClick();

        }
    }
}
