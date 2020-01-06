using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Rigidbody rb;
    Vector3 shotOrigin;
    public float distanceBeforeDestroy;
    public float timeBeforeDestroy;
    float aliveTimer;
    public string shooter;
    public string skin;
    public float speed = 35f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
        shotOrigin = transform.position;
        shooter = gameObject.name;
    }
    void Update()
    {
        aliveTimer += Time.deltaTime;
        DestroyProjectile();
    }

    void DestroyProjectile(){
        if((Vector3.Distance(shotOrigin,transform.position)  > distanceBeforeDestroy) || (aliveTimer > timeBeforeDestroy)){
            SoundManager.instance.PlaySound("Deceived_" + skin + "_Shot_End");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Character") && collider.gameObject.name != shooter){
            collider.GetComponent<Controls>().Kill(int.Parse(shooter.Replace("Player", string.Empty)));
        }

       
    }

}
