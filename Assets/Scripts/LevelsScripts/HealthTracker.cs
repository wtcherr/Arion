using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public Transform player;
    private HealthScript myHealth;
    public GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        myHealth=player.GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float maxHealth=myHealth.maxHealth;
        for(int i=0;i<(int)maxHealth;i++){
            if(i<myHealth.health){
                hearts[i].SetActive(true);
            }else hearts[i].SetActive(false);
        }
    }
}
