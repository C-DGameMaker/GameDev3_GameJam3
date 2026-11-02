using UnityEngine;

public class ServiceHubManager : MonoBehaviour
{
    public static ServiceHubManager Instance { get; private set; }

    public SaveNLoadManager saveNLoadManager;
    public GameStateManager gameStateManager;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
