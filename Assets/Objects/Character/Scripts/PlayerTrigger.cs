using UnityEngine;
using Leopotam.Ecs;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
    public EcsEntity entity;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();  

        if (collider.gameObject.tag == "Pit")
        {
            if (components.hp != 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(components.rigidbody2D.velocity, components.rigidbody2D.velocity);
                components.pit = true;
                components.playerObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
                components.positionForPit = new Vector2(components.transform.position.x, components.transform.position.y) - (components.rigidbody2D.velocity).normalized * 1.5f;
                StartCoroutine(Animation(components));
                components.hp -= 1;
            }
            else
            {
                entity.Del<Player>();
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator Animation(Player components)
    {
        for (float x = 1f; x >= 0f; x -= 0.1f)
        { 
            if(x == 0.09999993f)
            {
                EndAnimation();
                yield break;
            }

            components.playerObject.GetComponentInChildren<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.1f);
            components.gun.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.1f);
            yield return new WaitForSeconds(.06f);
        }
    }

    public void EndAnimation()
    {
        ref Player components = ref entity.Get<Player>();
        components.transform.position = components.positionForPit;
        components.pit = false;
        components.rigidbody2D.velocity = Vector2.zero;
        components.playerObject.GetComponentInChildren<BoxCollider2D>().enabled = true;
        components.playerObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        components.gun.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        return;
    }
}
