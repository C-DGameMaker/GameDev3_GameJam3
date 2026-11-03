using UnityEngine;

public class ButtonScript : MonoBehaviour
{
   public void SaveButton()
    {
        ServiceHubManager.Instance.saveDataManager.SaveData();
    }

    public void LoadButton()
    {
        ServiceHubManager.Instance.saveDataManager.LoadData();
    }
}
