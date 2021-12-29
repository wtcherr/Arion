using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HealthStates{
    alive,
    dead
}
public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float health;
    public int lives;
    public float immunityDuration=2;
    private float immunityTimer=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(immunityTimer<immunityDuration){
            immunityTimer+=Time.deltaTime;
        }
    }
    public void takeDamage(float damage){
        if(immunityTimer>=immunityDuration){
            health-=damage;
            if(health<=0){
                lives--;
                health=maxHealth;
            }
            immunityTimer=0;
        }
    }
    public HealthStates checkHealthStates(){
        if(lives>0)return HealthStates.alive;
        else return HealthStates.dead;
    }
}
