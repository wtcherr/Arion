using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class PlayerStateData : MonoBehaviour
{
    protected bool active;
    public PlayerStatesNames stateName;
    public List<PlayerStatesNames>requiredActiveStates;
    public List<PlayerStatesNames>requiredInActiveStates;
    public string animationVariableName;
    public bool animationVariableValue;
    public void UpdateState(PlayerStateManager stateManager,Animator animator){
        if(checkRequiredActiveStates(stateManager.stateDatas) && checkRequiredInActiveStates(stateManager.stateDatas)){
            active=false;
            checkState(stateManager,animator);
        }else active=false;
        if(animationVariableName!=""){
            if(active)setAnimator(animator,animationVariableName,animationVariableValue);
            else setAnimator(animator,animationVariableName,!animationVariableValue);
        }
    }
    public abstract void checkState(PlayerStateManager stateManager,Animator animator);
    public bool isActive(){
        return active;
    }
    public bool checkRequiredActiveStates(List<PlayerStateData> playerStateDatas){
        bool ok=true;
        foreach(PlayerStateData st in playerStateDatas){
            if(requiredActiveStates.Contains(st.stateName)){
                ok&=st.isActive();
            }
        }
        return ok;
    }
    public bool checkRequiredInActiveStates(List<PlayerStateData> playerStateDatas){
        bool ok=true;
        foreach(PlayerStateData st in playerStateDatas){
            if(requiredInActiveStates.Contains(st.stateName)){
                ok&=(!st.isActive());
            }
        }
        return ok;
    }
    public void setAnimator(Animator animator,string animationVariableName,bool animationVariableValue){
        animator.SetBool(animationVariableName,animationVariableValue);
    }
}
