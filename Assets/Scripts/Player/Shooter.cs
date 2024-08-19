using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Shooter class using object pool

    [SerializeField] UserInput input;
    [SerializeField] Bullet bullet;
    [SerializeField] float shootForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.AttackInput())
        {
            GameObject newBullet = ObjectPool.instance.SpawnFromPool("Bullet", transform.position, Quaternion.identity);

            // Launch the bullet's rigidbody after spawning it
            newBullet.GetComponent<Bullet>().FireBullet(transform.forward, shootForce);

        }
    }
}
