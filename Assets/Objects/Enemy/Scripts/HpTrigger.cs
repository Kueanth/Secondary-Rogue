using UnityEngine;
using Leopotam.Ecs;

public class HpTrigger : MonoBehaviour
{
    public UI ui;
    public SceneData scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            components.hpTransform = this.transform;
            components.nearHp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            components.hpTransform = this.transform;
            components.nearHp = false;
        }
    }

    public void GetHp(ref EcsEntity entity, ref UI ui)
    {
        ref Player components = ref entity.Get<Player>();

        if (components.hp != 3)
            components.hp += 1;

        ui.gameScreen.EditHpBar(components.hp, ui.imageHp[components.hp]);

        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
