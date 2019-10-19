using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingIcons : MonoBehaviour
{

    public enum Directions{
        Horizontal,
        Vertical,
        Diagonal
    }

    public Directions scrollingDirection;
    public float scrollSpeed;

    [Space]
    [SerializeField] private float horizontalValue;
    [SerializeField] private float verticalValue;

    public GameObject canvas;

    private int first = 0;
    private int second = 1;
    private int third = 2;


    // Start is called before the first frame update
    void Start()
    {

        switch(scrollingDirection){
            case Directions.Horizontal :
                SetHorizontalDirection();
            break;
            case Directions.Vertical : 
                SetVerticalDirection();
            break;
            case Directions.Diagonal :
                SetDiagonalDirection();
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(scrollingDirection){
            case Directions.Horizontal :
                MoveHorizontally();
            break;
            case Directions.Vertical : 
                MoveVertically();
            break;
            case Directions.Diagonal :
                MoveDiagonally();
            break;
        }
    }

    public void SetHorizontalDirection(){
        this.transform.GetChild(first + 1).transform.position = new Vector3(-(horizontalValue - canvas.transform.position.x), 0f + canvas.transform.position.y, 0f);
        this.transform.GetChild(first + 2).transform.position = new Vector3(-(2 * horizontalValue - canvas.transform.position.x), 0f + canvas.transform.position.y, 0f);
    }

    public void SetVerticalDirection(){
        this.transform.GetChild(first + 1).transform.position = new Vector3(0f + canvas.transform.position.x, (verticalValue + canvas.transform.position.y), 0f);
        this.transform.GetChild(first + 2).transform.position = new Vector3(0f + canvas.transform.position.x, (2 * verticalValue + canvas.transform.position.y), 0f);
    }

    public void SetDiagonalDirection(){
        this.transform.GetChild(first + 3).gameObject.SetActive(true);
        this.transform.GetChild(first + 4).gameObject.SetActive(true);
        this.transform.GetChild(first + 5).gameObject.SetActive(true);
        this.transform.GetChild(first + 6).gameObject.SetActive(true);
        this.transform.GetChild(first + 7).gameObject.SetActive(true);
        this.transform.GetChild(first + 8).gameObject.SetActive(true);

        this.transform.GetChild(first + 1).transform.position = new Vector3(-(horizontalValue - canvas.transform.position.x), 0f + canvas.transform.position.y, 0f);
        this.transform.GetChild(first + 2).transform.position = new Vector3(-(2 * horizontalValue - canvas.transform.position.x), 0f + canvas.transform.position.y, 0f);
        this.transform.GetChild(first + 3).transform.position = new Vector3(0f + canvas.transform.position.x, (verticalValue + canvas.transform.position.y), 0f);
        this.transform.GetChild(first + 4).transform.position = new Vector3(-(horizontalValue - canvas.transform.position.x), (verticalValue + canvas.transform.position.y), 0f);
        this.transform.GetChild(first + 5).transform.position = new Vector3(-(2 * horizontalValue - canvas.transform.position.x), (verticalValue + canvas.transform.position.y), 0f);  
        this.transform.GetChild(first + 6).transform.position = new Vector3(0f + canvas.transform.position.x, (2 * verticalValue + canvas.transform.position.y), 0f);
        this.transform.GetChild(first + 7).transform.position = new Vector3(-(horizontalValue - canvas.transform.position.x), (2 * verticalValue + canvas.transform.position.y), 0f);
        this.transform.GetChild(first + 8).transform.position = new Vector3(-(2 * horizontalValue - canvas.transform.position.x), (2 * verticalValue + canvas.transform.position.y), 0f);
    }
    public void MoveHorizontally(){
        if(this.transform.GetChild(first).transform.position.x >= horizontalValue + canvas.transform.position.x){
            this.transform.GetChild(first).transform.position = new Vector3(-(2*horizontalValue - canvas.transform.position.x), 0f + canvas.transform.position.y, 0f);
            ShiftFirst();
        }
        this.transform.Translate(new Vector3(1,0,0) * scrollSpeed);
    }

    public void MoveVertically(){
        if(this.transform.GetChild(first).transform.position.y <= -verticalValue + canvas.transform.position.y){
            this.transform.GetChild(first).transform.position = new Vector3(0f + canvas.transform.position.x, (2 * verticalValue + canvas.transform.position.y), 0f);
            ShiftFirst();
        }
        this.transform.Translate(new Vector3(0,-1,0) * scrollSpeed);
    }

    public void MoveDiagonally(){
        if(this.transform.GetChild(first).transform.position.y <= -verticalValue + canvas.transform.position.y){
            this.transform.GetChild(first).transform.position = new Vector3(0f + canvas.transform.position.x, (2 * verticalValue + canvas.transform.position.y), 0f);
            this.transform.GetChild(second).transform.position = new Vector3(-(horizontalValue - canvas.transform.position.x), (2 * verticalValue + canvas.transform.position.y), 0f); 
            this.transform.GetChild(third).transform.position = new Vector3(-(2 * horizontalValue - canvas.transform.position.x), (2 * verticalValue + canvas.transform.position.y), 0f); 
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
