using UnityEngine;
using Leopotam.Ecs;
using System.Runtime.InteropServices;

public class BodyTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public SceneData sceneData;
    public UI ui;

    [System.Obsolete]
    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();

        if (collider.gameObject.tag == "EnemyBullet" && !sceneData.paused)
        {
            components.hp -= 1;

            if (components.hp > 0)
            {
                components.vignetteEffect.SetTrigger("Effect");
                ui.gameScreen.EditHpBar(components.hp, ui.imageHp[components.hp]);
            }
            else
            {
                ui.gameScreen.EditHpBar(components.hp, ui.imageHp[0]);
                ui.gameScreen.gameScreen.SetActive(false);
                ui.deadScreen.deadScreen.SetActive(true);
                ui.pausedScreen.pausedScreen.SetActive(false);
                ui.deadScreen.editText(sceneData.countLevel, sceneData.countKillEnemy, 0);
                sceneData.paused = true;
                components.animator.SetTrigger("Refuse");
                components.rigidbody2D.velocity = Vector2.zero;
            }
        }
    }
}
