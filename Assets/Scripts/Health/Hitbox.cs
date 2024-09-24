using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public HitboxType hitbox;

    public enum BoxType { Player, Enemy}
    public BoxType hitboxType;
    [SerializeField] Health health;

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
    }
}
