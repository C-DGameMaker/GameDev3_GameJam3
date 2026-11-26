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

        offset = Quaternion.Inverse(playerCharacter.rotation) * (transform.position - playerCharacter.position);

    }

    private void LateUpdate()
    {
        Vector3 cameraOffset = playerCharacter.rotation * offset;
        transform.position = playerCharacter.position + cameraOffset;

        transform.LookAt(playerCharacter.position);
    }
}
