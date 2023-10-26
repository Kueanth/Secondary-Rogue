using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.one;
    }
}
