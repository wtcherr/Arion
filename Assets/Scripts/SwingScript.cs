using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    public Transform player;
    public Transform swingPosition;
    public KeyCode swingBtn=KeyCode.E;
    private bool swinging=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(swinging){
            player.transform.position=swingPosition.position;
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(Input.GetKeyDown(swingBtn)){
            if(swinging){
                player.gameObject.AddComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeRotation;
                swinging=false;
            }else{
                Destroy(player.GetComponent<Rigidbody2D>());
                swinging=true;
            }
        }
    }
}
