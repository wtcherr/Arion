using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float damage;
    public float lifeDuration;
    private float lifeTimer;
    private bool shooting=false;
    private Vector3 direction;
    void Start()
    {
        this.transform.parent=null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shooting){
            transform.position+=direction*speed*Time.deltaTime;
            if(lifeTimer<lifeDuration){
                lifeTimer+=Time.deltaTime;
            }else{
                Destroy(this.gameObject);
            }
        }
    }
    public void shoot(Vector3 dir, Transform target){
        this.direction=dir;
        shooting=true;
        float rotationAngle=(dir.x!=0?Mathf.Atan2(dir.y,dir.x):dir.y)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0,0,rotationAngle);
    }
    void OnTriggerEnter2D(Collider2D other) {
        HealthScript hs=other.GetComponent<HealthScript>();
        if(hs!=null){
            hs.takeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
