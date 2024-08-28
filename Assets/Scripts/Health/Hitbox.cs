using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] Health health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        if (!health) { return; }

        if (other.GetComponent<Hazard>())
        {
            Hazard hazard = other.GetComponent<Hazard>();
            if (hazard == null) { return; }

            if (hazard.instaKill)
            {
                health.InstaKill();
            }
            else
            {
                health.TakeDamage(hazard.damage);
            }
        }
    }
}
