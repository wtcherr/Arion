using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyAttackNames{
    throwProjectile,
    rush,
    melee
}
public class EnemyState_AttackStateManager : EnemyStateData
{
    public List<EnemyStateData> cycleAttacks=new List<EnemyStateData>();
    public List<EnemyStateData> triggerAttacks=new List<EnemyStateData>();
    public float attackRange;
    private EnemyStateData currentAttack;
    private EnemyStateManager stateManager;
    private Animator animator;
    private int index=0;
    // Start is called before the first frame update
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
        this.stateManager=stateManager;
        this.animator=animator;
        
	}
	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
        return true;
	}
    void UpdateCycleAttacks(){
        if(index<cycleAttacks.Count){
            setAttack(cycleAttacks[index]);
            currentAttack.UpdateState(stateManager,animator);
            if(!currentAttack.isActive()){
                index++;
                index%=cycleAttacks.Count;
                currentAttack.reset();
            }
        }
    }
    void UpdateTriggerAttacks(){
        foreach(EnemyStateData enemyState in triggerAttacks){
            enemyState.UpdateState(stateManager,animator);
        }
    }
    public void setAttack(EnemyStateData newAttack){
        currentAttack=newAttack;
    }

}
