using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] protected BulletHolder bulletHolder;
    // Shooter class using object pool

    // Start is called before the first frame update
    void Start()
    {
        UIManager.insance.SetBulletSlider(bulletHolder.maxNum, bulletHolder.maxNum);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void ShootBullet(string key)
    {
        if (bulletHolder.num <= 0) {
            bulletHolder.Reload();
        }
        GameObject newBullet = ObjectPool.instance.SpawnFromPool(key, transform.position, Quaternion.identity);

        // Launch the bullet's rigidbody after spawning it
        newBullet.GetComponent<Bullet>().FireBullet(transform.forward, bulletHolder.shootForce);
        bulletHolder.num--;
    }
}
