using UnityEngine;

public class Enter : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Point") return;

        Material material = new Material(Shader.Find("Shader Graphs/Outlines"));

        material.SetVector("_Right", new Vector2(0.8f, 0f));
        material.SetVector("_Left", new Vector2(-0.8f, 0f));
        material.SetVector("_Up", new Vector2(0f, 0.8f));
        material.SetVector("_Down", new Vector2(0f, -0.8f));

        material.color = new Color32(255, 230, 0, 255);

        gameObject.GetComponent<SpriteRenderer>().material = material;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Point") return;

        Material material = new Material(Shader.Find("Shader Graphs/Outlines"));

        material.SetVector("_Right", new Vector2(0f, 0f));
        material.SetVector("_Left", new Vector2(0f, 0f));
        material.SetVector("_Up", new Vector2(0f, 0f));
        material.SetVector("_Down", new Vector2(0f, 0f));

        material.color = new Color32(0, 0, 0, 0);

        gameObject.GetComponent<SpriteRenderer>().material = material;
    }
}
