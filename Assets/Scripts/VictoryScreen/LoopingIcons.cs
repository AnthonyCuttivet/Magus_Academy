using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingIcons : MonoBehaviour
{
    public int direction = 1;
    public float scrollSpeed;

    [Space]
    [SerializeField] private float horizontalValue;
    [SerializeField] private float verticalValue;

    private int first = 0;
    private int second = 1;
    private int third = 2;


    // Start is called before the first frame update
    void Start()
    {
        switch(direction){
            case 0 :
                SetHorizontalDirection();
            break;
            case 1 : 
                SetVerticalDirection();
            break;
            case 2 :
                SetDiagonalDirection();
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(direction){
            case 0 :
                MoveHorizontally();
            break;
            case 1 : 
                MoveVertically();
            break;
            case 2 :
                MoveDiagonally();
            break;
        }
    }

    public void SetHorizontalDirection(){
        this.transform.GetChild(first + 1).transform.position = new Vector3(-horizontalValue, 0f, 0f);
        this.transform.GetChild(first + 2).transform.position = new Vector3((-horizontalValue * 2), 0f, 0f);
    }

    public void SetVerticalDirection(){
        this.transform.GetChild(first + 1).transform.position = new Vector3(0f, verticalValue, 0f);
        this.transform.GetChild(first + 2).transform.position = new Vector3(0f, (verticalValue * 2), 0f);
    }

    public void SetDiagonalDirection(){
        this.transform.GetChild(first + 3).gameObject.SetActive(true);
        this.transform.GetChild(first + 4).gameObject.SetActive(true);
        this.transform.GetChild(first + 5).gameObject.SetActive(true);
        this.transform.GetChild(first + 6).gameObject.SetActive(true);
        this.transform.GetChild(first + 7).gameObject.SetActive(true);
        this.transform.GetChild(first + 8).gameObject.SetActive(true);

        this.transform.GetChild(first + 1).transform.position = new Vector3(-horizontalValue, 0f, 0f);
        this.transform.GetChild(first + 2).transform.position = new Vector3((-horizontalValue * 2), 0f, 0f);
        this.transform.GetChild(first + 3).transform.position = new Vector3(0f, verticalValue, 0f);
        this.transform.GetChild(first + 4).transform.position = new Vector3(-horizontalValue, verticalValue, 0f);   
        this.transform.GetChild(first + 5).transform.position = new Vector3((-horizontalValue * 2), verticalValue, 0f); 
        this.transform.GetChild(first + 6).transform.position = new Vector3(0f, (verticalValue * 2), 0f);
        this.transform.GetChild(first + 7).transform.position = new Vector3(-horizontalValue, (verticalValue * 2), 0f);   
        this.transform.GetChild(first + 8).transform.position = new Vector3((-horizontalValue * 2), (verticalValue * 2), 0f);  
    }
    public void MoveHorizontally(){
        if(this.transform.GetChild(first).transform.position.x >= horizontalValue){
            this.transform.GetChild(first).transform.position = new Vector3((-horizontalValue * 2), 0f, 0f);
            ShiftFirst();
        }
        this.transform.Translate(new Vector3(1,0,0) * scrollSpeed);
    }

    public void MoveVertically(){
        if(this.transform.GetChild(first).transform.position.y <= -verticalValue){
            Debug.Break();
            this.transform.GetChild(first).transform.position = new Vector3(0f, (verticalValue * 2), 0f);
            ShiftFirst();
        }
        this.transform.Translate(new Vector3(0,-1,0) * scrollSpeed);
    }

    public void MoveDiagonally(){
        if(this.transform.GetChild(first).transform.position.y <= -verticalValue){
        this.transform.GetChild(first).transform.position = new Vector3(0f, (verticalValue * 2), 0f);
        this.transform.GetChild(second).transform.position = new Vector3(-horizontalValue, (verticalValue * 2), 0f);   
        this.transform.GetChild(third).transform.position = new Vector3((-horizontalValue * 2), (verticalValue * 2), 0f);  
            ShiftFirst(true);
        }
        this.transform.Translate(new Vector3(1,-1,0) * scrollSpeed);
    }

    public void ShiftFirst(bool diagonalShift = false){
        if(diagonalShift){
            if(first == 6){
                first = 0;
            }else{
                first += 3;
            }
            if(second == 7){
                second = 1;
            }else{
                second += 3;
            }
            if(third == 8){
                third = 2;
            }else{
                third += 3;
            }
        }else{
            if(first == 2){
                first = 0;
            }else{
                first += 1;
            }
        }
    }
}
