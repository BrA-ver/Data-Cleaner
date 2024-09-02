using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] float lifeTime = 20f;
    float lifeTimeCounter;

    // Start is called before the first frame update
    private void Start()
    {
        lifeTimeCounter = lifeTime;
    }

    void Update()
    {
        lifeTimeCounter -= Time.deltaTime;
        if (lifeTimeCounter <= 0f)
        {
            Destroy(gameObject);
        }
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
