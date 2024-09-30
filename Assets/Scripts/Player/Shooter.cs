using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] protected BulletHolder bulletHolder;
    // Shooter class using object pool

    protected virtual void ShootBullet(string key)
    {
        if (!ObjectPool.instance)
        {
            Debug.Log("No Object Pool On " + transform.name);
            return;
        }

        
        GameObject newBullet = ObjectPool.instance.SpawnFromPool(key, transform.position, Quaternion.identity);

        // Launch the bullet's rigidbody after spawning it
        newBullet.GetComponent<Bullet>().FireBullet(transform.forward, bulletHolder.shootForce);
    }
}
