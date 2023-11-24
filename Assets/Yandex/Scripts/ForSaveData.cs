using UnityEngine;

public class ForSaveData : MonoBehaviour
{
    public void savePlayerData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (Progress.Instance.PlayerInfoForGame.auth) ;
            Progress.Instance.Save();
#endif
    }
}
