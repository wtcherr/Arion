using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HealthStates{
    alive,
    revived,
    dead
}
public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float health;
    public int lives;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float damage){
        health-=damage;
        checkHealthStates();
    }
    public HealthStates checkHealthStates(){
        if(health<=0){
            lives--;
            health=maxHealth;
            if(lives<=0)return HealthStates.dead;
            return HealthStates.revived;
        }else return HealthStates.alive;
    }
}
