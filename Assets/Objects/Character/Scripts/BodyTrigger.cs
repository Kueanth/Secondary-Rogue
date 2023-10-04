using UnityEngine;
using Leopotam.Ecs;

public class BodyTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public UI ui;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();

        if (collider.tag == "Chest")
        {
            components.nearChest = true;
            components.chest = collider.transform;
        }

        if (collider.gameObject.tag == "EnemyBullet")
        {
            components.hp -= 1;

            if (components.hp != 0)
            {
                components.vignetteEffect.SetTrigger("Effect");
                ui.gameScreen.EditHpBar(components.hp, ui.imageHp[components.hp]);
            }
            else
            {
                ui.gameScreen.EditHpBar(components.hp, ui.imageHp[0]);
                GameObject temp = components.playerObject;
                Destroy(temp);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ref Player components = ref entity.Get<Player>();

        if (collision.tag == "Chest")
        {
            components.nearChest = false;
        }
    }
}
