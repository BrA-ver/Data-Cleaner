using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    public void Attack()
    {
        ShootBullet("Player Bullet");
    }
}
