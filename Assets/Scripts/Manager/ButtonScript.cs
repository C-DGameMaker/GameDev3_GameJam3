using UnityEngine;

public class ButtonScript : MonoBehaviour
{
   public void SaveButton()
    {
        GameManager.Instance.saveDataManager.SaveData();
    }

    public void LoadButton()
    {
        GameManager.Instance.saveDataManager.LoadData();
    }
}
