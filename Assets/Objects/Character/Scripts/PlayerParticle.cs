using UnityEngine;
using Leopotam.Ecs;
using System.Collections;

public class PlayerParticle : MonoBehaviour
{
    public bool particleRun;

    public EcsEntity entity;
    public SceneData sceneData;

    public void MethodForReloadParticle()
    {
        ref Player components = ref entity.Get<Player>();
        Debug.Log("Work1");

        if (particleRun)
        {
            Debug.Log("Work2");
            particleRun = false;
            GameObject particle = GameObject.Instantiate(sceneData.particleSystemForPlayer, new Vector3(components.transform.position.x, components.transform.position.y - 0.5f), Quaternion.identity);
            particle.transform.parent = null;
            Destroy(particle, 0.8f);
            StartCoroutine(ReloadParticle());
        }
    }

    IEnumerator ReloadParticle()
    {
        yield return new WaitForSeconds(0.3f);

        particleRun = true;

        yield break;
    }
}
