using UnityEngine;

public class GunAnim : MonoBehaviour
{
    private Transform gunTransform;
    private SpriteRenderer playerRenderer;

    public static GunAnim animObj;

    public static float animX;
    public static float animY;

    private void Awake()
    {
        gunTransform = gameObject.transform.Find("Gun");
        playerRenderer = gameObject.GetComponent<SpriteRenderer>();

        animX = 0f;
        animY = 0f;
    }

    public void DownGun()
    {
        animY = -0.05f;
    }

    public void UpGun()
    {
        animY = 0.05f;
    }

    public void RightGun()
    {
        if (!playerRenderer.flipX)

            animX = 0.05f;
        else
            animX = -0.05f;
    }

    public void LeftGun()
    {
        if (!playerRenderer.flipX)

            animX = -0.05f;
        else
            animX = 0.05f;
    }

    public void DefaultGun()
    {
        animX = 0f;
        animY = 0f;
    }
}
