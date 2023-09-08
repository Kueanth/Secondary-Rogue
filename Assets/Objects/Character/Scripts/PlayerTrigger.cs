using UnityEngine;
using Leopotam.Ecs;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
    public EcsEntity entity;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();  

        if (collider.gameObject.tag == "Pit" && !components.pit)
        {
            if (components.hp != 0)
            {
                RaycastHit2D hit1 = Physics2D.Raycast(components.transform.position + Vector3.down, Vector3.down, 5f);
                RaycastHit2D hit2 = Physics2D.Raycast(components.transform.position + Vector3.down + new Vector3(2f, 1f, 0f), Vector3.down, 5f);
                RaycastHit2D hit3 = Physics2D.Raycast(components.transform.position + Vector3.down + new Vector3(-2f, 1f, 0f), Vector3.down, 5f);

                components.positionForPit = new Vector2(components.transform.position.x, components.transform.position.y) - (components.rigidbody2D.velocity).normalized;

                if (hit1.transform != null)
                {
                    if (hit1.transform.tag == "Pit")
                        components.rigidbody2D.velocity = (Vector2.down * 4f);
                }
                else if (hit2.transform != null)
                {
                    if (hit2.transform.tag == "Pit")
                        components.rigidbody2D.velocity = (Vector2.down * 3f) + (Vector2.right * 3f);
                }
                else if (hit3.transform != null)
                {
                    if (hit3.transform.tag == "Pit")
                        components.rigidbody2D.velocity = (Vector2.down * 3f) + (Vector2.left * 3f);
                }
                else
                {
                    components.rigidbody2D.velocity = (Vector2.up * 3f);
                }

                components.pit = true;
                components.playerObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
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

    private void OnDrawGizmos()
    {
        ref Player components = ref entity.Get<Player>();
        Gizmos.DrawRay(components.transform.position + Vector3.down + new Vector3(1f, 0f, 0f), Vector3.down);
        Gizmos.DrawRay(components.transform.position + Vector3.down + new Vector3(-1f, 0f, 0f), Vector3.down);
        Gizmos.DrawRay(components.transform.position + Vector3.down, Vector3.down);
    }
}
