using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Controller")]
    public Transform playerCharacter;
    public Vector3 offset;

    private void Start()
    {
        if(playerCharacter == null)
        {
            Debug.Log("Player is null");
        }

        offset = transform.localPosition;
        
    }

    private void LateUpdate()
    {
        Vector3 cameraOffset = playerCharacter.rotation * offset;

        transform.position = playerCharacter.position + cameraOffset;
    }
}
