using System.Collections;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    [SerializeField] private Material material;

    private Color DefaultColor;

    public void Awake()
    {
        DefaultColor = material.color;
    }

    public void StartGame()
    {
        StartCoroutine(EditCoroutine(material));
    }

    IEnumerator EditCoroutine(Material material)
    {
        for(float i = 1f; i >= -1f; i -= 0.1f)
        {

            material.SetColor("_Color", material.color * i);
            yield return new WaitForSeconds(.1f);
        }
    }

    public void OnDestroy()
    {
        material.SetColor("_Color", DefaultColor);
    }
}
