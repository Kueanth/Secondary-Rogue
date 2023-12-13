using UnityEngine;
using Leopotam.Ecs;

public class BullTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;

            ref Player components = ref meow.Get<Player>();

            components.bullTransform = this.transform;
            components.nearBull = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            components.bullTransform = this.transform;
            components.nearBull = false;
        }
    }

    public void GetBull(ref EcsEntity entity, ref UI ui)
    {
        ref GunComponents gunComponents = ref entity.Get<GunComponents>();

        gunComponents.store = gunComponents.maxStore;

        if(!gunComponents.reolading)
        ui.gameScreen.GetGun(gunComponents.ammo, gunComponents.store);

        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
