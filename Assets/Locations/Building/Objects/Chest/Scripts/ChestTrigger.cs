using UnityEngine;
using Leopotam.Ecs;

public class ChestTrigger : MonoBehaviour
{
    public EcsEntity entity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ref ChestData chestComponents = ref entity.Get<ChestData>();

        if(collision.tag == "Player" && chestComponents.open)
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material.color = new Color32(128, 128, 128, 255);
        }
        else if (collision.tag == "Player" && !chestComponents.open)
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material.color = new Color32(255, 230, 0, 255);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
        }
    }

    public void OpenChest()
    {
        ref ChestData chestComponents = ref entity.Get<ChestData>();

        if (chestComponents.open) return;

        gameObject.GetComponent<Animator>().SetTrigger("Open");
        chestComponents.open = true;
    }
}
