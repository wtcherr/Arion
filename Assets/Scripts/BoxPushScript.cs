using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float pushForce;
    public Vector2 pushDirection=new Vector2(1,0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.transform==player)
            GetComponent<Rigidbody2D>().AddForce(pushDirection*pushForce);
    }
}
