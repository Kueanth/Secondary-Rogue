using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public GameObject particle;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Walls and Decoration")
        {
            GameObject effect = Instantiate(particle, gameObject.transform);
            effect.transform.parent = null;
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(particle, gameObject.transform);
            effect.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
