using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject gow;
    public DataGun pow;
    public SpriteRenderer meow;

    public void Awake()
    {
        meow = gow.GetComponent<SpriteRenderer>();
        meow.sprite = pow.sprite;
    }

    public void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gow.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - gow.transform.position);
    }
}