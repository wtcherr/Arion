using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_MeleeAttack : PlayerStateData
{
    public float damage;
    public KeyCode meleeBtn;
    public GameObject weapon;
    public float cooldownDuration=1;
    private float cooldownTimer=0;
    public float activeDuration=1;
    private float activeTimer=0;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
        if(Input.GetKey(meleeBtn)){
            if(cooldownTimer>=cooldownDuration){
                if(activeTimer<=activeDuration){
                    active=true;
                    checkHit();
                    activeTimer+=Time.deltaTime;
                }else {
                    cooldownTimer=0;
                }
            }else{
                cooldownTimer+=Time.deltaTime;
                activeTimer=0;
            }
        }
        weapon.SetActive(active);
	}
    private bool checkHit(){
        ContactFilter2D filter2D=new ContactFilter2D();
        Collider2D[] hits=new Collider2D[10];
        weapon.GetComponent<Collider2D>().OverlapCollider(filter2D.NoFilter(),hits);
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
