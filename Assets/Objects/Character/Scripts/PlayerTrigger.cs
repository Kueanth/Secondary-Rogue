using UnityEngine;
using Leopotam.Ecs;
using System.Collections;
using System.Threading;

public class PlayerTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public float x, y;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();  

        if (collider.gameObject.tag == "Pit" && !components.pit)
        {
            if (components.hp != 0)
            {
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
                        Debug.Log("asd");
                        temp = true;
                    }
                }

                foreach (var h in hitDown)
                {
                    if (h.collider.tag == "Pit")
                    {
                        Debug.Log("qwe");
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
                yield return new WaitForSeconds(2f);
                EndAnimation();
                yield break;
            }

            components.playerObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            components.gun.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

            components.playerObject.GetComponentInChildren<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.2f);
            components.gun.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.2f);

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

        components.playerObject.transform.localScale = new Vector3(1f, 1f, 1f);
        components.gun.transform.localScale = new Vector3(0.633f, 0.633f, 1f);

        components.playerObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        components.gun.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

        return;
    }
}
