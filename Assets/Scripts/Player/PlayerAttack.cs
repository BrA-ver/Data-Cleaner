using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerShooter bulletShooter;
    [SerializeField] UserInput input;
    [SerializeField] Animator anim;
    [SerializeField] GroundDetector ground;
    [SerializeField] TargetHandler targetHandler;
    [SerializeField] float rotationSpeed;

    public bool Attacking { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.AttackInput() && ground.GroundCheck())
        {
            if (Attacking) { return; }
            anim.SetTrigger("attack");
            Attacking = true;
        }

        if (Attacking && targetHandler.HasTarget)
        {
            RotatePlayer(targetHandler.DirectionToClosest);
        }
    }

    public void FinishAttack()
    {
        Attacking = false;
    }

    public void SpawnBullet()
    {
        bulletShooter.Attack();
    }

    private void RotatePlayer(Vector3 direction)
    {
        

        // Turn the player if the direction to look is not zero
        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
