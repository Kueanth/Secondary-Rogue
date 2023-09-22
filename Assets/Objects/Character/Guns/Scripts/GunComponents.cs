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

    public bool canShoot;

    public bool reolading;

    public Transform gun;

    public Light2D light;

    public Transform bulletSpawn;

    public SpriteRenderer flipGun;

    public GunReload reload;
}
