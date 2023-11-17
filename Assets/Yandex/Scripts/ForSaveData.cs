using UnityEngine;

public class ForSaveData : MonoBehaviour
{
    public void savePlayerData()
    {
#if UNITY_WEBGL
        if(Progress.Instance.PlayerInfoForGame.auth)
        Progress.Instance.Save();
#endif
    }
}
