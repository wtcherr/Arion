using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public bool active;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform==player.transform){
            active=true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.transform==player.transform){
            active=false;
        }
    }
}
