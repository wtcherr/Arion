using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState_Slide : PlayerStateData
{
    public KeyCode slideBtn;
    public float distance;
    public float speed;
    public float cooldownDuration;
    public float minDistance;
    public float damage;
    public Transform effectBox;
    private float cooldownTimer;
    private float horizontalDirection;
    private Vector3 target;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
        horizontalDirection=Input.GetAxis("Horizontal");
        if(Input.GetKey(slideBtn)){
            if(cooldownTimer>=cooldownDuration){
                if(target==Vector3.zero){
                    target=new Vector3(horizontalDirection*distance,0,0)+stateManager.transform.position;
                }
                Debug.DrawRay(stateManager.transform.position,target-stateManager.transform.position,Color.blue);
                if(horizontalDistance(stateManager.transform.position,target)<=minDistance){
                    target=Vector3.zero;
                    active=false;
                    cooldownTimer=0;
                }else 
                    active=true;
            }
        }else if(active){
            target=Vector3.zero;
            active=false;
            cooldownTimer=0;
        }
        if(cooldownTimer<cooldownDuration)cooldownTimer+=Time.deltaTime;
        if(active){
            stateManager.horizontalMove(target,speed);
            checkHit();
        }
	}
    private float horizontalDistance(Vector3 p1,Vector3 p2){
        return Mathf.Abs(p1.x-p2.x);
    }
    private bool checkHit(){
        ContactFilter2D filter2D=new ContactFilter2D();
        Collider2D[] hits=new Collider2D[10];
        effectBox.GetComponent<Collider2D>().OverlapCollider(filter2D.NoFilter(),hits);
        foreach(Collider2D other in hits){
            if(other==null)continue;
            HealthScript hs=other.gameObject.GetComponent<HealthScript>();
            if(hs!=null){
                hs.takeDamage(damage);
                return true;
            }
        }
        return false;
    }
}
