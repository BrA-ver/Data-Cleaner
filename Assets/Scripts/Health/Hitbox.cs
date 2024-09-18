using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public HitboxType hitbox;

    public enum BoxType { Player, Enemy}
    public BoxType hitboxType;
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
        Hazard hazard = other.GetComponent<Hazard>();
        if (!hazard)
        {
            Debug.Log("No Hazard");
            return;
        }

        if (hazard.instaKill)
        {
            health.Kill();
        }
        else
        {
            Debug.Log(hazard.damage);
            health.TakeDamage(hazard.damage);
        }


            //if (!health) { return; }

            //if (other.GetComponent<Hazard>())
            //{
            //    Hazard hazard = other.GetComponent<Hazard>();
            //    if (hazard == null) { return; }
            //    if (hazard.hitbox.type == hitbox.type)
            //    {
            //        Debug.Log("Target");
            //    }

            //    if (hazard.instaKill)
            //    {
            //        health.InstaKill();
            //    }
            //    else
            //    {
            //        health.TakeDamage(hazard.damage);
            //    }
            //}
    }
}
