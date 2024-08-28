using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    // Start is called before the first frame update

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(Vector3 direction, float force)
    {
        body.isKinematic = false;
        body.AddForce(direction * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
