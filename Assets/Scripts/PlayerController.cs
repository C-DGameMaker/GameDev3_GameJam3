using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Varibles")]

    [SerializeField] Rigidbody playerRB;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] Vector2 movementInput;
    void Start()
    {
       if(playerRB == null)
        {
            playerRB = GetComponent<Rigidbody>();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y) * playerSpeed * Time.deltaTime;
        playerRB.MovePosition(playerRB.position + move);
    }
}
