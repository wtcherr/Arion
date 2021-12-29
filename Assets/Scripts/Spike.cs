using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damage = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        HealthScript hs = other.GetComponent<HealthScript>();
        if (hs != null)
        {
            hs.takeDamage(damage);
        }
    }
}
