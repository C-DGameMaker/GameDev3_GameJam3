using Unity.VisualScripting;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
