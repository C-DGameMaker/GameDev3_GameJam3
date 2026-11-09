using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Controller")]
    public Transform playerCharacter;
    public Vector3 offset = new Vector3(0, 3, -7);
    public float distanceFromPlayer;

    private void Start()
    {
        if(playerCharacter == null)
        {
            Debug.Log("Player is null");
        }

    }

    private void Update()
    {
        Vector3 cameraOffset = Quaternion.Euler(0f, 0f, 0f) * offset * distanceFromPlayer;

        transform.position = playerCharacter.position + cameraOffset;

        transform.LookAt(playerCharacter);
    }
}
