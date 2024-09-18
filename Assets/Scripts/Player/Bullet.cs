using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] float lifeTime = 10f;
    float lifeTimeCounter = 0f;
    [SerializeField] GameObject exp;

    void Update()
    {
        lifeTimeCounter += Time.deltaTime;
        if (lifeTimeCounter >= lifeTime)
        {
            ResetBullet();
        }
    }

    private void ResetBullet()
    {
        body.velocity = Vector3.zero;
        body.isKinematic = true;
        gameObject.SetActive(false);
        lifeTimeCounter = 0f;

    }

    public void FireBullet(Vector3 direction, float force)
    {
        body.isKinematic = false;
        body.AddForce(direction * force, ForceMode.Impulse);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(exp, transform.position, Quaternion.identity);
        ResetBullet();
    }
}
