using UnityEngine;

public class ForSaveData : MonoBehaviour
{
    public void savePlayerData()
    {
#if UNITY_WEBGL
        Progress.Instance.Save();
#endif
    }
}
