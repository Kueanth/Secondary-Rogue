using UnityEngine;

public class PetInMenu : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    public void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position, speed);
    }
}
