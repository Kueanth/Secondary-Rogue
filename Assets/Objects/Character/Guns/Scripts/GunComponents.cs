using UnityEngine;
using UnityEngine.Rendering.Universal;

public struct GunComponents
{
    public GunData gunData;

    public int ammo;
    public int maxAmmo;
    public int store;
    public int maxStore;
    public float timeShoot;
    public Vector2 spawnPointBulltet;

    public bool canShoot;
    public bool rayLazer;
    public bool reolading;

    public Transform lazer;

    public Transform gun;

    public Light2D light;

    public Transform bulletSpawn;

    public SpriteRenderer flipGun;

    public GunReload reload;
}
