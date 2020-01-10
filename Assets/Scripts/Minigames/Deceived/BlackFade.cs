using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    
    Animator animator;
    string SceneToLoad;
    public static BlackFade instance;

    void Awake(){
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
        animator = GetComponent<Animator>();
    }
    public void FadeOutToScene(string sceneName){
        SceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }
    public void LoadSceneOnFadeOutComplete(){
        SceneManager.LoadScene(SceneToLoad);
    }
}
