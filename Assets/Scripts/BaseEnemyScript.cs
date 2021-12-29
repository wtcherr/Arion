using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyStates{
    Idle,
    Patrol,
    Follow,
    Attack,
    Dead
};
public class BaseEnemyScript: MonoBehaviour
{
    // Start is called before the first frame update
    protected EnemyStates state;
    protected EnemyStates lastState;
    public float deathDuration;
    public float deathFlickerDuration;
    [Range(0.1f,1)]
    public float deathFlickerSpeed;
    private float deathTimer;
    private float flickerTimer;
    private SpriteRenderer spriteRenderer;
    void Start() {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    void FixedUpdate() {
        HealthScript hs=GetComponent<HealthScript>();
        if(hs!=null){
            HealthStates healthState=hs.checkHealthStates();
            if(healthState==HealthStates.dead)setState(EnemyStates.Dead);
        }
    }
    protected void die(){
        if(deathTimer<deathDuration){
            deathTimer+=Time.deltaTime;
        }else {
            Destroy(this.gameObject);
        }
        if(deathDuration>=deathTimer){
            if(flickerTimer<deathFlickerSpeed){
                flickerTimer+=Time.deltaTime;
            }else{
                if(spriteRenderer!=null){
                    spriteRenderer.enabled=!spriteRenderer.enabled;
                }
                flickerTimer=0;
            }
        }
    }
    protected virtual void attack(){

    }
    protected virtual void idle(){

    }
    protected virtual void follow(){

    }
    protected virtual void patrol(){

    }
    protected void setState(EnemyStates newState){
        if(state!=EnemyStates.Dead){
            lastState=state;
            state=newState;
        }
    }
}
