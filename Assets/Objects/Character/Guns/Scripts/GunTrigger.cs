using UnityEngine;
using Leopotam.Ecs;

public class GunTrigger : MonoBehaviour
{
    public DataGun gun;

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

    public void GetGun(Player components)
    {
        components.gun.GetComponent<SpriteRenderer>().sprite = gun.spriteForHand;
        Destroy(gameObject);
    }
}
