using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject gow;

    public void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gow.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - gow.transform.position);
    }
}