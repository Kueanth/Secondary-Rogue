using UnityEngine;
using System.Collections;

public class GunReload : MonoBehaviour
{
    public void ReloadGun(ref GunComponents components, ref UI ui)
    {
        StartCoroutine(CoroutineReload(components, ui));
    }

    private IEnumerator CoroutineReload(GunComponents components, UI ui)
    {
        yield return new WaitForSeconds(3);

        Reload(ref components, ref ui);

        yield break;
    }

    private void Reload(ref GunComponents components, ref UI ui)
    {
        ui.gameScreen.AmmoUpdate();
    }
}
