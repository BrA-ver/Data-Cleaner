using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    // Ground Movement
    CharacterController controller;
    UserInput input;
    [SerializeField] float speed = 10f;
    private Vector3 velocity;

    // Rotation and movement correction
    Vector3 cameraRelativeDirection;

    [SerializeField] float rotationSpeed = 2.5f;

    // Animation
    [SerializeField] Animator anim;

    // Vertical movement
    [SerializeField] GroundDetector ground;
    float yVelocity;

    [SerializeField] float jumpHeight = 2.5f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<UserInput>();
        SpawnManager.instance.SetCheckpoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (input.AttackInput())
        {
            PlatAttack();
        }

        // Get player's movement input from the input class
        Vector2 direction = input.GetMoveInput();
        SetCamRelativeMovement(direction);

        // Make the character's velocity
        velocity = cameraRelativeDirection * speed;
        Gravity();

        // Apply vertical velocity
        velocity.y = yVelocity;

        // Move character controller
        MoveController();

        // Rotate player to the movement direction
        RotatePlayer(new Vector2(cameraRelativeDirection.x, cameraRelativeDirection.z));

        // Animate player
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

        // Turn the player if the direction to look is not zero
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
        anim.SetBool("grounded", ground.GroundCheck());
        anim.SetFloat("yVelocity", Mathf.Sign( yVelocity));
    }

    void PlatAttack()
    {
        anim.SetTrigger("attack");
    }

    void Gravity()
    {
        print(ground.GroundCheck());
        if (ground.GroundCheck())
        {
            yVelocity = -0.5f;

            if (input.JumpInput())
            {
                yVelocity = Mathf.Sqrt(-2f * jumpHeight * Physics.gravity.y);
            }
        }
        yVelocity += Physics.gravity.y * 2 * Time.deltaTime;
    }
}
