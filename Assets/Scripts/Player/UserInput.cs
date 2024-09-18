using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    // Input class using the input system

    [SerializeField] PlayerInput playerInput;

    public Vector2 GetMoveInput()
    {
        Vector2 moveInput = playerInput.actions.FindAction("Move").ReadValue<Vector2>();
        return moveInput;
    }

    public bool AttackInput()
    {
        return playerInput.actions["Attack"].WasPerformedThisFrame();
    }

    public bool JumpInput()
    {
        return playerInput.actions["Jump"].WasPerformedThisFrame();
    }

    public bool CloseGame()
    {
        return playerInput.actions["Close"].WasPerformedThisFrame();
    }
}
