using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] PlayerInput input;
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
            Bullet newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            newBullet.FireBullet(transform.forward, shootForce);
        }
    }
}
