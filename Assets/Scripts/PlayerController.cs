using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 movementInput = Vector2.zero;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    public void OnSabotaje(InputAction.CallbackContext context)
    {

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.y, 0, movementInput.x);
        controller.Move(move * Time.deltaTime * playerSpeed);

        controller.Move(playerVelocity * Time.deltaTime);
    }

}
