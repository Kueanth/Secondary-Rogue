using UnityEngine;
using Leopotam.Ecs;

public class BodyTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public SceneData sceneData;
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
                ui.gameScreen.gameScreen.SetActive(false);
                ui.deadScreen.deadScreen.SetActive(true);
                ui.deadScreen.editText(sceneData.countLevel, sceneData.countKillEnemy, 0);
                sceneData.paused = true;
                components.playerObject.SetActive(false);
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
