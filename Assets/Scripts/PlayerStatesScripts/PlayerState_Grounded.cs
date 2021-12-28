using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState_Grounded : PlayerStateData
{
    private Transform groundCheck;
    public float groundDistance;
    public LayerMask groundLayer;
    public override void checkState(PlayerStateManager stateManager, Animator animator){
        groundCheck=stateManager.groundCheck;
        active=Physics2D.OverlapCircle(groundCheck.position,groundDistance,groundLayer);
    }
}
