using UnityEngine;
using Leopotam.Ecs;

public class GunTrigger : MonoBehaviour
{
    public GunData gun;
    public UI ui;
    public SceneData scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            components.gunInChest = this.transform;
            components.nearGun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            components.gunInChest = null;
            components.nearGun = false;
        }
    }

    public void GetGun(ref EcsEntity entity, ref UI ui)
    {
        ref GunComponents components = ref entity.Get<GunComponents>();

        components.gunData = gun;
        components.damage = gun.damage;
        components.gun.GetComponent<SpriteRenderer>().sprite = gun.spriteForHand;
        components.ammo = gun.ammo;
        components.maxAmmo = gun.maxAmmo;
        components.store = gun.store;
        components.maxStore = gun.maxStore;
        components.timeShoot = gun.timeShoot;
        components.spawnPointBulltet = gun.spawnPointShoot;
        components.reloading = gun.reloading;

        if (components.gunData.nameGun == "Awm" || components.gunData.nameGun == "Awm_2" || components.gunData.nameGun == "Awm_3")
        {
            ui.gameScreen.aim.enabled = false;
            components.rayLazer = true;
            scene.lazerWork = true;
        }
        else
        {
            ui.gameScreen.aim.enabled = true;
            components.rayLazer = false;
            scene.lazerWork = false;
        }

        components.gun.Find("Spawn Bullet").localPosition = components.spawnPointBulltet;

        ui.gameScreen.GetGun(components.ammo, components.store);

        if (components.reolading)
        {
            components.reolading = false;
            ui.GetComponent<GameScreen>().EndReloadBar(true);
        }

        switch (components.gunData.nameGun)
        {
            case "Pistol":
                ui.gameScreen.EditGun(ui.imageGun[0]);
                break;

            case "Drobovik":
                ui.gameScreen.EditGun(ui.imageGun[1]);
                break;

            case "Awm":
                ui.gameScreen.EditGun(ui.imageGun[2]);
                break;

            case "Automat":
                ui.gameScreen.EditGun(ui.imageGun[3]);
                break;

            case "Pistol_2":
                ui.gameScreen.EditGun(ui.imageGun[4]);
                break;

            case "Drobovik_2":
                ui.gameScreen.EditGun(ui.imageGun[5]);
                break;

            case "Awm_2":
                ui.gameScreen.EditGun(ui.imageGun[6]);
                break;

            case "Automat_2":
                ui.gameScreen.EditGun(ui.imageGun[7]);
                break;

            case "Pistol_3":
                ui.gameScreen.EditGun(ui.imageGun[8]);
                break;

            case "Drobovik_3":
                ui.gameScreen.EditGun(ui.imageGun[9]);
                break;

            case "Awm_3":
                ui.gameScreen.EditGun(ui.imageGun[10]);
                break;

            case "Automat_3":
                ui.gameScreen.EditGun(ui.imageGun[11]);
                break;
        }

        Destroy(gameObject);
    }
}
