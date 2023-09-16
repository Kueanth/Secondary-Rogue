using UnityEngine;
using Leopotam.Ecs;

public class HatchTrigger : MonoBehaviour
{
    public EcsEntity entity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ref Hatch hatchComponents = ref entity.Get<Hatch>();

        Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;

        if (collision.tag == "Player" && !hatchComponents.open)
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            material.color = new Color32(128, 128, 128, 255);
            material.SetVector("_Right", new Vector2(0.8f, 0f));
            material.SetVector("_Left", new Vector2(-0.8f, 0f));
            material.SetVector("_Up", new Vector2(0f, 0.8f));
            material.SetVector("_Down", new Vector2(0f, -0.8f));

            components.chest = this.transform;
            components.nearChest = false;
        }
        else if (collision.tag == "Player" && hatchComponents.open)
        {
            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            material.color = new Color32(255, 230, 0, 255);
            material.SetVector("_Right", new Vector2(0.8f, 0f));
            material.SetVector("_Left", new Vector2(-0.8f, 0f));
            material.SetVector("_Up", new Vector2(0f, 0.8f));
            material.SetVector("_Down", new Vector2(0f, -0.8f));

            components.chest = this.transform;
            components.nearChest = true;
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
        }
    }

    public void OpenChest()
    {
        ref Hatch hatchComponents = ref entity.Get<Hatch>();

        if (hatchComponents.open) return;

        ref Hatch components = ref entity.Get<Hatch>();

        components.animator.SetTrigger("Open");

        hatchComponents.open = true;

        Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;

        material.color = new Color32(0, 0, 0, 0);
        material.SetVector("_Right", new Vector2(0f, 0f));
        material.SetVector("_Left", new Vector2(0f, 0f));
        material.SetVector("_Up", new Vector2(0f, 0f));
        material.SetVector("_Down", new Vector2(0f, 0f));
    }
}
