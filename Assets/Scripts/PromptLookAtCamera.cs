using UnityEngine;

public class PromptLookAtCamera : MonoBehaviour
{
    public Camera inGameCamera;

    private void Update()
    {
        transform.LookAt(transform.position + inGameCamera.transform.rotation * Vector3.forward, inGameCamera.transform.rotation * Vector3.up);
    }
}
