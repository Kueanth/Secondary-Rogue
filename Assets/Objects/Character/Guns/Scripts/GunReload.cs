using UnityEngine;
using System.Collections;
using Leopotam.Ecs;

public class GunReload : MonoBehaviour
{
    public void ReloadGun(ref GunComponents components, ref UI ui)
    {
        StartCoroutine(CoroutineReload(components, ui));
    }

    public void ShootGun(ref EcsEntity entity)
    {
        StartCoroutine(CoroutineShoot(entity));
    }

    private IEnumerator CoroutineShoot(EcsEntity entity)
    {
        GunComponents gunComponents = entity.Get<GunComponents>();
        
        yield return new WaitForSeconds(gunComponents.timeShoot);

        Shoot(ref entity);

        yield break;
    }

    private IEnumerator CoroutineReload(GunComponents components, UI ui)
    {
        StartReloadBar(ref components, ref ui);

        yield return new WaitForSeconds(2f);

        EndReloadBar(ref components, ref ui);

        Reload(ref components, ref ui);

        yield break;
    }

    private void Reload(ref GunComponents components, ref UI ui)
    {
        ui.gameScreen.AmmoUpdate();
    }

    private void StartReloadBar(ref GunComponents components, ref UI ui)
    {
        ui.gameScreen.StartReloadBar();
    }

    private void EndReloadBar(ref GunComponents components, ref UI ui)
    {
        ui.gameScreen.textMeshPro.text = $"{components.ammo}/{components.store}";
        ui.gameScreen.EndReloadBar();
    }



    private void Shoot(ref EcsEntity entity)
    {
        ref GunComponents gunComponents = ref entity.Get<GunComponents>();
        gunComponents.canShoot = true;
    }
}
