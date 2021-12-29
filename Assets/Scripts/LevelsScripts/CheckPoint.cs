using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public FrameManager frameManager;
    void Start() {
        frameManager=GetComponentInParent<FrameManager>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        frameManager.setActiveCheckPoint(this);
    }
}
