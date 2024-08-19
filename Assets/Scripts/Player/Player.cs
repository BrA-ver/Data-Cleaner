using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    PlayerInput input;
    [SerializeField] float speed = 10f;

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
        Vector2 direction = input.GetMoveInput();
        SetCamRelativeMovement(direction);
        Vector3 velocity = cameraRelativeDirection * speed;
        MoveController(velocity);

        RotatePlayer(new Vector2(cameraRelativeDirection.x, cameraRelativeDirection.z));
        PlayAnim();
    }

    void MoveController(Vector3 velocity)
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
        anim.SetBool("moving", cameraRelativeDirection != Vector3.zero);
    }
}
