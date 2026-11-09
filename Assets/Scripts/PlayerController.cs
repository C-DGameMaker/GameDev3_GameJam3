using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Variables")]

    [SerializeField] Rigidbody playerRB;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Vector2 movementInput;

    [Header("Player Interaction Variables")]
    public bool canMove;

    PlayerData playerData;
    void Start()
    {
       if(playerRB == null)
       {
            playerRB = GetComponent<Rigidbody>();
       }

        canMove = true;
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
        if (canMove == false) return;
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y) * playerSpeed * Time.deltaTime;
        playerRB.MovePosition(playerRB.position + move);
    }

    public void Jump()
    {
        if (Mathf.Abs(playerRB.linearVelocity.y) < 0.01f) playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
