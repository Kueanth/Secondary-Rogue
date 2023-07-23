using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public ParticleSystem particle;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        particle.Play();

        if (particle.isPlaying) Debug.Log("viebvaetsa");

        if (collider.gameObject.tag == "Walls and Decoration")
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
