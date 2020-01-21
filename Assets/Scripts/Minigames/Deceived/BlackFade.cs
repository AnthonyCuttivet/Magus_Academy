using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    
    Animator animator;
    string SceneToLoad;
    public static BlackFade instance;
    public float fadeTime = 0;

    void Awake(){
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
        animator = GetComponent<Animator>();
        fadeTime = animator.GetCurrentAnimatorStateInfo(0).length;
    }
    public void FadeOutToScene(string sceneName,float _fadeTime = 0f){
        SceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
        if(animator.GetCurrentAnimatorStateInfo(0).length < _fadeTime){
            
            animator.speed *= animator.GetCurrentAnimatorClipInfo(0)[0].clip.length / (_fadeTime - animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        }

        
    }
    public void LoadSceneOnFadeOutComplete(){
        SceneManager.LoadScene(SceneToLoad);
    }

    IEnumerator fadeTimeTimer(){
        while(fadeTime >= 0){
            fadeTime -= Time.deltaTime;
            yield return null;
        }
    }
}
