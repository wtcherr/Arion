using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitchToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active;
    public Transform player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform==player.transform)
            active=true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.transform==player.transform)
            active=false;
    }
}
