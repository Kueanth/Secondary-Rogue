using UnityEngine;

public struct ChestData
{
    public string gun;
    public bool open;

    public GunData gunData;
    public GameObject prefabGun;

    public Vector3 transformForGun;

    public Animator animator;
}
