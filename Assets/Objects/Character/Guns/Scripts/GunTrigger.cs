using UnityEngine;
using Leopotam.Ecs;

public class GunTrigger : MonoBehaviour
{
    public GunData gun;
    public UI ui;

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
        components.gun.GetComponent<SpriteRenderer>().sprite = gun.spriteForHand;
        components.ammo = gun.ammo;
        components.maxAmmo = gun.maxAmmo;
        components.store = gun.store;
        components.maxStore = gun.maxStore;
        components.timeShoot = gun.timeShoot;
        components.spawnPointBulltet = gun.spawnPointShoot;
        
        if(components.gunData.nameGun == "Awm")
        {
            ui.gameScreen.aim.enabled = false;
            components.rayLazer = true;
        }
        else
        {
            ui.gameScreen.aim.enabled = true;
            components.rayLazer = false;
        }

        components.gun.Find("Spawn Bullet").localPosition = components.spawnPointBulltet;

        ui.gameScreen.GetGun(components.ammo, components.store);

        Destroy(gameObject);
    }
}
