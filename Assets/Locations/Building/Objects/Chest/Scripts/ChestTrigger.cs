using UnityEngine;
using Leopotam.Ecs;

public class ChestTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public GunData[] guns;
    public GameObject gun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ref ChestData chestComponents = ref entity.Get<ChestData>();

        Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;

        if (collision.tag == "Player" && chestComponents.open)
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
        else if (collision.tag == "Player" && !chestComponents.open)
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
        if(collision.tag == "Player")
        {
            Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;

            EcsEntity meow = collision.GetComponentInChildren<BodyTrigger>().entity;
            ref Player components = ref meow.Get<Player>();

            material.color = new Color32(0, 0, 0, 0);
            material.SetVector("_Right", new Vector2(0f, 0f));
            material.SetVector("_Left", new Vector2(0f, 0f));
            material.SetVector("_Up", new Vector2(0f, 0f));
            material.SetVector("_Down", new Vector2(0f, 0f));

            components.chest = this.transform;
            components.nearChest = false;
        }
    }

    public void OpenChest()
    {
        ref ChestData chestComponents = ref entity.Get<ChestData>();

        if (chestComponents.open) return;

        chestComponents.animator.SetTrigger("Open");

        chestComponents.open = true;

        Material material = gameObject.GetComponentInParent<SpriteRenderer>().material;

        material.color = new Color32(0, 0, 0, 0);
        material.SetVector("_Right", new Vector2(0f, 0f));
        material.SetVector("_Left", new Vector2(0f, 0f));
        material.SetVector("_Up", new Vector2(0f, 0f));
        material.SetVector("_Down", new Vector2(0f, 0f));

        GameObject Gun = GameObject.Instantiate(chestComponents.prefabGun, chestComponents.transformForGun, Quaternion.identity);

        Gun.GetComponent<GunTrigger>().gun = chestComponents.gunData;

        gun = Gun;

        Material gunMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));

        gunMaterial.SetVector("_Right", new Vector2(0.8f, 0f));
        gunMaterial.SetVector("_Left", new Vector2(-0.8f, 0f));
        gunMaterial.SetVector("_Up", new Vector2(0f, 0.8f));
        gunMaterial.SetVector("_Down", new Vector2(0f, -0.8f));

        gunMaterial.color = new Color32(255, 230, 0, 255);

        Gun.GetComponent<SpriteRenderer>().material = gunMaterial;
    }

    public void OnDestroy()
    {
        Destroy(gun);
    }
}
