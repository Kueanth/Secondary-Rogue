using UnityEngine;
using Leopotam.Ecs;
using System.Collections;

public class GunInput : IEcsRunSystem
{
    private UI ui;
    private SceneData sceneData;

    private bool temp;

    private EcsFilter<Player, GunComponents> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            EcsEntity entity = _filter.GetEntity(i);

            ref Player playerComponents = ref _filter.Get1(i);
            ref GunComponents gunComponents = ref _filter.Get2(i);

            if (gunComponents.rayLazer && gunComponents.canShoot)
            {
                gunComponents.lazer.gameObject.SetActive(true);
            }
            else
            {
                gunComponents.lazer.gameObject.SetActive(false);
            }

            if (Input.GetMouseButton(0) && !playerComponents.pit && !gunComponents.reolading && gunComponents.canShoot)
            {
                if (gunComponents.ammo != 0)
                {
                    gunComponents.canShoot = false;
                    gunComponents.reload.ShootGun(ref entity);
                    ui.gameScreen.ShootUpdate(ref gunComponents.ammo, ref gunComponents.store);
                    entity.Get<Shoot>();
                }
            }

            if (gunComponents.ammo != gunComponents.maxAmmo && Input.GetKeyDown(KeyCode.R) && !gunComponents.reolading && gunComponents.store != 0 || gunComponents.ammo == 0 && !gunComponents.reolading && gunComponents.store != 0)
            {
                gunComponents.reolading = true;
                gunComponents.reload.ReloadGun(ref gunComponents, ref ui);
                ui.gameScreen.textMeshPro.text = "Перезарядка";
            }
        }
    }
}

