using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    public void Attack()
    {
        AudioManager.Instance.PlaySFX("Shoot");
        ShootBullet("Player Bullet");
    }
}
