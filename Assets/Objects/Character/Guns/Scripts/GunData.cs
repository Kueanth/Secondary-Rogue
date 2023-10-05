using UnityEngine;

[CreateAssetMenu(fileName = "DataGun", menuName = "Data Guns/DataGun")]
public class GunData : ScriptableObject
{
    public Sprite spriteForHand;
    public GameObject prefabForChest;

    public string nameGun;

    public int damage;
    public int ammo;
    public int maxAmmo;
    public int store;
    public int maxStore;

    public Vector2 spawnPointShoot;

    [Range(0f,10f)] public float timeShoot;
}
