using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] UserInput input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.AttackInput())
        {
            ShootBullet("Player Bullet");
        }
    }
}
