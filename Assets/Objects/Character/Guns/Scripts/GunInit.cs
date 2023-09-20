using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.Rendering.Universal;

public class GunInit : IEcsInitSystem
{
    private SceneData sceneData;
    private GunArray gunArray;
    private UI ui;

    private EcsWorld _world;

    public void Init()
    {
        EcsEntity gunEntity = sceneData.playerEntity;

        ref GunComponents components = ref gunEntity.Get<GunComponents>();

        components.gun = sceneData.playerPosition.transform.Find("Gun");
        components.gunData = gunArray.guns[0];
        components.light = components.gun.Find("Light").GetComponent<Light2D>();
        components.bulletSpawn = components.gun.Find("Spawn Bullet");
        components.reload = components.gun.GetComponent<GunReload>();
        components.flipGun = components.gun.GetComponent<SpriteRenderer>();

        ui.gameScreen.entity = gunEntity;

        components.ammo = components.gunData.ammo;
        components.maxAmmo = components.gunData.maxAmmo;
        components.store = components.gunData.store;
        components.maxStore = components.gunData.maxStore;

        ui.gameScreen.textMeshPro.text = components.ammo + "/" + components.store;
    }
}
