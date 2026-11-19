using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController movementController;
    [Header("Player Movement Variables")]

    [SerializeField] Rigidbody playerRB;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Vector2 movementInput;
    private float turnInput;
    public float turnSpeed = 150f;

    [Header("Player Interaction Variables")]
    public bool canMove;

    [Header("Player Other")]
    public int gold;

    [SerializeField] IInteractable targetInteractable;
    void Start()
    {
        movementController = this;
       if(playerRB == null)
       {
            playerRB = GetComponent<Rigidbody>();
       }

        canMove = true;
    }

    #region Movement
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<float>();
        Debug.Log("Turn Input: " + turnInput);
    }

    public void FixedUpdate()
    {
        HandlePlayerMovement();
        HandlePlayerTurning();
    }

    public void HandlePlayerTurning()
    {
        if (canMove == false) return;

        float turn = turnInput * turnSpeed * Time.deltaTime;

        playerRB.MoveRotation(playerRB.rotation * Quaternion.Euler(0, turn, 0));
    }

    private void HandlePlayerMovement()
    {
        if (canMove == false) return;
        Vector3 move = (transform.forward * movementInput.y + transform.right * movementInput.x) * playerSpeed * Time.deltaTime;
        playerRB.MovePosition(playerRB.position + move);
    }        

    public void Jump()
    {
        if (Mathf.Abs(playerRB.linearVelocity.y) < 0.01f) playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    #endregion

    #region Interactable

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = foundInteractable;
            targetInteractable.ShowPrompt();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable.HidePrompt();
            targetInteractable = null;
        }
    }

    public void OnInteract(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            if (targetInteractable != null)
            {
                targetInteractable.Interact();
            }
        }

    }
    #endregion

    #region Other stuff
    public void PauseToggle()
    {
        if (GameManager.Instance.gameStateManager.currentState == GameStates.gamePlay)
        {
            if (GameManager.Instance.gameStateManager.currentState == GameStates.paused) return;
            GameManager.Instance.gameStateManager.SetGameStates(GameStates.paused);
        }
        else if (GameManager.Instance.gameStateManager.currentState == GameStates.paused)
        {
            if (GameManager.Instance.gameStateManager.currentState == GameStates.gamePlay) return;
            GameManager.Instance.gameStateManager.SetGameStates(GameStates.gamePlay);
        }
    }
    #endregion
}
