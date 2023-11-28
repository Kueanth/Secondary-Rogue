using UnityEngine;

public class ForSaveData : MonoBehaviour
{
    public void savePlayerData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            Progress.Instance.Save();
#endif
    }
}
