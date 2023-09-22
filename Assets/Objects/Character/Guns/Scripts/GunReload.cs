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
        yield return new WaitForSeconds(3);

        Reload(ref components, ref ui);

        yield break;
    }

    private void Reload(ref GunComponents components, ref UI ui)
    {
        ui.gameScreen.AmmoUpdate();
    }

    private void Shoot(ref EcsEntity entity)
    {
        ref GunComponents gunComponents = ref entity.Get<GunComponents>();
        gunComponents.canShoot = true;
    }
}
