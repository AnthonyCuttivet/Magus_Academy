using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFiller : MonoBehaviour
{
    Image bar;
    public float maxAmount;
    public float smoothSpeed;
    public float fillAmount;
    void Start()
    {
        bar = GetComponent<Image>();
    }
    void Update(){
        UpdateBar();
    }

    public void AddFillAmount(float value){
        
        fillAmount += value/maxAmount;
    }
    public void ChangeFillAmount(float value){
        fillAmount = value/maxAmount;
    }
    void UpdateBar(){
        float updateAmount =bar.fillAmount;
        if(bar.fillAmount < fillAmount){
            updateAmount += fillAmount  * Time.deltaTime;
        }
        if(updateAmount > fillAmount){
            updateAmount = fillAmount;
        }
        bar.fillAmount = updateAmount;
            
    }
}
