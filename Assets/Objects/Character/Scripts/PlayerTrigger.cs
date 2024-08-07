using UnityEngine;
using Leopotam.Ecs;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class PlayerTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public SceneData sceneData;
    public UI ui;
    public float x, y;

    public void resurrectionPlayer()
    {
        ref Player components = ref entity.Get<Player>();
        ref GunComponents gunComponents = ref entity.Get<GunComponents>();

        ui.gameScreen.gameScreen.SetActive(true);
        ui.deadScreen.deadScreen.SetActive(false);
        ui.pausedScreen.pausedScreen.SetActive(true);

        if (!sceneData.levelComplete) ui.gameScreen.infoBar.GetComponent<Animator>().Play("New State");

        components.hp = 3;
        sceneData.paused = false;

        components.animator.SetTrigger("End");
        ui.gameScreen.aim.enabled = true;
        sceneData.paused = false;

        ui.gameScreen.EditHpBar(components.hp, ui.imageHp[components.hp]);

        if (components.deadforpit)
        {
            components.transform.position = components.positionForPit;
            components.deadforpit = false;
        }
    }

    [System.Obsolete]
    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();  
        ref GunComponents gunComponents = ref entity.Get<GunComponents>();

        if (collider.gameObject.tag == "Pit" && !components.pit)
        {
            AudioObject.Instance.Health();

            components.hp -= 1;

            if (components.hp > 0)
            {
                components.vignetteEffect.SetTrigger("Effect");

                components.positionForPit = new Vector2(components.transform.position.x, components.transform.position.y) - (components.rigidbody2D.velocity).normalized;

                x = collider.bounds.center.x;
                y = collider.bounds.center.y;

                RaycastHit2D[] hitRight = Physics2D.RaycastAll(new Vector2(components.transform.position.x - 1f, components.transform.position.y - 0.4f), Vector2.right, 2f);
                RaycastHit2D[] hitDown = Physics2D.RaycastAll(new Vector2(components.transform.position.x, components.transform.position.y + 3f), Vector2.down, 5f);

                bool temp = false;

                foreach(var h in hitRight)
                {
                    if (h.collider.tag == "Pit")
                    {
                        temp = true;
                    }
                }

                foreach (var h in hitDown)
                {
                    if (h.collider.tag == "Pit")
                    {
                        temp = true;
                    }
                }

                if (components.transform.position.y > y)
                {
                    components.rigidbody2D.velocity -= Vector2.up * 5f + new Vector2(x, y).normalized;

                    if (components.transform.position.x < x && !temp)
                    {
                        components.rigidbody2D.velocity += Vector2.right * 3f;
                    }
                    else if (!temp)
                    {
                        components.rigidbody2D.velocity += Vector2.left * 3f;
                    }
                }
                else if(components.transform.position.y < y)
                {
                    components.rigidbody2D.velocity -= Vector2.up * 2f + new Vector2(x, y).normalized;

                    if (components.transform.position.x < x && !temp)
                    {
                        components.rigidbody2D.velocity += Vector2.right * 3f;
                    }
                    else if (!temp)
                    {
                        components.rigidbody2D.velocity += Vector2.left * 3f;
                    }
                }

                components.pit = true;
                components.playerObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
                components.animator.SetTrigger("Refuse");
                StartCoroutine(Animation(components, gunComponents));
                ui.gameScreen.EditHpBar(components.hp, ui.imageHp[components.hp]);
                sceneData.Pet.GetComponent<PetInMenu>().active = false;
                sceneData.Pet.GetComponent<Animator>().SetBool("Speed", false);
            }
            else
            {
                components.positionForPit = new Vector2(components.transform.position.x, components.transform.position.y) - (components.rigidbody2D.velocity).normalized;
                GameObject temp = components.playerObject;
                components.animator.SetTrigger("Refuse");
                components.rigidbody2D.velocity = Vector2.zero;
                ui.gameScreen.EditHpBar(components.hp, ui.imageHp[0]);
                ui.gameScreen.gameScreen.SetActive(false);
                ui.deadScreen.deadScreen.SetActive(true);
                ui.pausedScreen.pausedScreen.SetActive(false);

                if(sceneData.record > PlayerPrefs.GetInt("record"))
                {
                    PlayerPrefs.SetInt("record", sceneData.record);
                }
                ui.deadScreen.editText(sceneData.countLevel, PlayerPrefs.GetInt("record"));
                sceneData.paused = true;
                components.deadforpit = true;
            }
        }
    }

    private IEnumerator Animation(Player components, GunComponents gunComponents)
    {
        for (float x = 1f; x >= 0f; x -= 0.1f)
        { 
            if(x == 0.09999993f)
            {
                yield return new WaitForSeconds(2f);
                EndAnimation();
                yield break;
            }

            yield return new WaitForSeconds(.06f);
        }
    }

    public void EndAnimation()
    {
        ref Player components = ref entity.Get<Player>();
        ref GunComponents gunComponents = ref entity.Get<GunComponents>();

        components.transform.position = components.positionForPit;
        components.pit = false;
        components.rigidbody2D.velocity = Vector2.zero;

        components.playerObject.GetComponentInChildren<BoxCollider2D>().enabled = true;

        sceneData.Pet.GetComponent<PetInMenu>().active = true;
        sceneData.Pet.GetComponent<Animator>().SetBool("Speed", true);

        components.animator.SetTrigger("End");

        return;
    }
}
