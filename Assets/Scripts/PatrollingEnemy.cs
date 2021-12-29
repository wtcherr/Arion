using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PatrollingEnemy : BaseEnemyScript
{
    // Start is called before the first frame update
    public float movementSpeed;
    public float minTargetDistance;
    public float followRange;
    public float attackRange;
    public float attackDuration;
    private float attackTimer;
    public GameObject projectile;
    public Transform firePoint;
    public Transform point1;
    public Transform point2;
    public Transform target;
    private Transform followTarget;
    private Vector3 followDirection;
    void Start()
    {
        setState(EnemyStates.Patrol);
    }

    // Update is called once per frame
    void Update()
    {
        checkFlip();
        if(state==EnemyStates.Patrol){
            patrol();
        }else if(state==EnemyStates.Follow){
            follow();
        }else if(state==EnemyStates.Attack){
            attack();
        }else if(state==EnemyStates.Dead){
            die();
        }
    }
    protected override void patrol(){
        if(followTarget==null)followTarget=point1;
        if(horizontalDistance(followTarget.position,transform.position)<minTargetDistance){
            if(followTarget==point1)followTarget=point2;
            else followTarget=point1;
        }
        followDirection=followTarget.position-transform.position;
        followDirection.y=0;
        followDirection.z=0;
        followDirection.Normalize();
        transform.position+=followDirection*movementSpeed*Time.deltaTime;
        if(horizontalDistance(target.position,transform.position)<=followRange){
            setState(EnemyStates.Follow);
        }
    }
    protected override void follow(){
        followDirection=target.position-transform.position;
        followDirection.y=0;
        followDirection.z=0;
        followDirection.Normalize();
        transform.position+=followDirection*movementSpeed*Time.deltaTime;
        if(horizontalDistance(target.position,transform.position)<=attackRange){
            setState(EnemyStates.Attack);
        }
        if(horizontalDistance(target.position,transform.position)>followRange){
            setState(EnemyStates.Patrol);
        }
    }
    protected override void attack(){
        Vector3 fireDirection=target.position-firePoint.position;
        Debug.DrawRay(firePoint.position,fireDirection,Color.blue);
        fireDirection.Normalize();
        if(horizontalDistance(target.position,transform.position)>attackRange){
            setState(EnemyStates.Follow);
            return;
        }
        if(attackTimer<attackDuration){
            attackTimer+=Time.deltaTime;
        }else{
            fire(fireDirection);
            attackTimer=0;
        }
    }
    private void fire(Vector3 direction){
        GameObject go=Instantiate(projectile);
        go.transform.position=firePoint.position;
        go.GetComponent<ProjectileController>().shoot(direction,target);
    }
    private void checkFlip(){
        Vector3 scale=transform.localScale;
        if((followDirection.x>0)==(scale.x>0)){
            scale.x*=-1;
            transform.localScale=scale;
        }
    }
    private float horizontalDistance(Vector3 p1,Vector3 p2){
        return Mathf.Abs(p1.x-p2.x);
    }
}
