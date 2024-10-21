using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] float lifeTime = 10f;
    float lifeTimeCounter = 0f;
    [SerializeField] GameObject exp;

    private void Start()
    {
        AudioManager.Instance.PlaySFX("Shoot");
    }

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
        AudioManager.Instance.PlaySFX("Impact");
        Instantiate(exp, transform.position, Quaternion.identity);
        ResetBullet();
    }
}
