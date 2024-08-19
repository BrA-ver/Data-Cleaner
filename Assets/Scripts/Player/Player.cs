using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    PlayerInput input;
    [SerializeField] float speed = 10f;
    private Vector3 velocity;

    Vector3 cameraRelativeDirection;

    [SerializeField] float rotationSpeed = 2.5f;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.AttackInput())
        {
            PlatAttack();
        }

        Vector2 direction = input.GetMoveInput();
        SetCamRelativeMovement(direction);
        velocity = cameraRelativeDirection * speed;
        MoveController();

        RotatePlayer(new Vector2(cameraRelativeDirection.x, cameraRelativeDirection.z));
        PlayAnim();
    }

    void MoveController()
    {
        controller.Move(velocity * Time.deltaTime);
    }

	private void SetCamRelativeMovement(Vector2 direction)
	{
		Vector3 forward = Camera.main.transform.forward;
		Vector3 right = Camera.main.transform.right;

		forward.y = 0f;
		right.y = 0f;


		forward.Normalize();
		right.Normalize();


		Vector3 relativeForward = direction.y * forward;
		Vector3 relativeRight = direction.x * right;

		cameraRelativeDirection = relativeForward + relativeRight;
	}

    private void RotatePlayer(Vector2 direction)
    {
        Vector3 directionToLook = new Vector3(direction.x, 0.0f, direction.y);

        if (directionToLook.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToLook);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void PlayAnim()
    {
        anim.SetBool("moving", velocity != Vector3.zero);
    }

    void PlatAttack()
    {
        anim.SetTrigger("attack");
    }
}
