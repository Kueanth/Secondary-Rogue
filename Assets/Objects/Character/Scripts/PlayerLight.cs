using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light2D lighting;



    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(EffectLight(lighting));
        }
    }

    IEnumerator EffectLight(Light2D light)
    {
        for (float x = 3f; x >= 0; x -= 0.3f)
        {
            light.intensity = x;

            yield return new WaitForSeconds(.01f);
        }
    }
}
