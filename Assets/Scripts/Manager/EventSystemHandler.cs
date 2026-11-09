using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Only used by other scripts to set the Event system to select the first button there, so you can access everything. 
/// </summary>
public class EventSystemHandler : MonoBehaviour
{
   public void SetButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}
