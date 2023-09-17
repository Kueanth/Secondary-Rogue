using UnityEngine;
using Leopotam.Ecs;

public class HatchTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public SceneData sceneData;
    public EcsEntity player;
    public UI ui;

    private bool nearPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ref Hatch hatchComponents = ref entity.Get<Hatch>();

        Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;

        if (collision.tag == "Player" && !sceneData.levelComplete)
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            player = meow;
            ref Player components = ref meow.Get<Player>();
            

            material.color = new Color32(128, 128, 128, 255);
            material.SetVector("_Right", new Vector2(0.8f, 0f));
            material.SetVector("_Left", new Vector2(-0.8f, 0f));
            material.SetVector("_Up", new Vector2(0f, 0.8f));
            material.SetVector("_Down", new Vector2(0f, -0.8f));

            components.hatch = this.transform;
            components.nearHatch = false;
            nearPlayer = true;
        }
        else if (collision.tag == "Player" && sceneData.levelComplete)
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            material.color = new Color32(255, 230, 0, 255);
            material.SetVector("_Right", new Vector2(0.8f, 0f));
            material.SetVector("_Left", new Vector2(-0.8f, 0f));
            material.SetVector("_Up", new Vector2(0f, 0.8f));
            material.SetVector("_Down", new Vector2(0f, -0.8f));

            components.hatch = this.transform;
            components.nearHatch = true;
            nearPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;

            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            material.color = new Color32(0, 0, 0, 0);
            material.SetVector("_Right", new Vector2(0f, 0f));
            material.SetVector("_Left", new Vector2(0f, 0f));
            material.SetVector("_Up", new Vector2(0f, 0f));
            material.SetVector("_Down", new Vector2(0f, 0f));

            components.hatch = this.transform;
            components.nearHatch = false;
            nearPlayer = false;
        }
    }

    public void OpenHatch()
    {
        ref Hatch hatchComponents = ref entity.Get<Hatch>();

        hatchComponents.open = false;

        ui.gameScreen.fade.GetComponent<Animator>().SetTrigger("Meow");
    }

    public void levelComplete()
    {
        if (nearPlayer)
        {
            ref Player gow = ref player.Get<Player>();

            gow.nearHatch = true;

            Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;
            ref Hatch hatchComponents = ref entity.Get<Hatch>();

            material.color = new Color32(255, 230, 0, 255);
            material.SetVector("_Right", new Vector2(0.8f, 0f));
            material.SetVector("_Left", new Vector2(-0.8f, 0f));
            material.SetVector("_Up", new Vector2(0f, 0.8f));
            material.SetVector("_Down", new Vector2(0f, -0.8f));
        }
    }
}
