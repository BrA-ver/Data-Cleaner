using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public HitboxType hitbox;

    public enum TargetType { Player, Enemy}
    public TargetType targetType;

    public float damage = 2f;
    public bool instaKill = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class HitboxType
{
    public enum BoxType { Player, Enemy}
    public BoxType type;
}