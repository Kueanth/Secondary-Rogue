using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;

    public Transform target;

    public void StartAttack()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void Shoot()
    {
        Vector3 diference = target.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotateZ - 90f);

        GameObject bulletObject = Instantiate(bullet, transform.position, rotation);

        bulletObject.GetComponent<Rigidbody2D>().velocity = target.position.normalized * 10f;

        Destroy(bulletObject, 10);
    }
}
