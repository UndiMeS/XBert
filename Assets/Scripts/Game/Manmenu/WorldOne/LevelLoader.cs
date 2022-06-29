using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;
    public float transitionTime = 1.0f;
    public string LoadScene;


    // Update is called once per frame
    void Update()
    {
        
    }

        public void OnLevelClick()
    {
        Debug.Log("Load level");
        this.gameObject.GetComponent<Image>().raycastTarget = true;
        StartCoroutine(LoadLevel());
        
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);

        if(LoadScene != "")
        {
            SceneManager.LoadScene(LoadScene);
        }
        
    }

    public void DeactvateTransition()
    {
        this.gameObject.SetActive(false);
    }

    public void ActvateTransition()
    {
        this.gameObject.SetActive(true);
    }
}
