using UnityEngine;

[CreateAssetMenu(fileName = "DataGun", menuName = "Data Guns/DataGun")]
public class DataGun : ScriptableObject
{
    public Sprite spriteForHand;
    public GameObject prefabForChest;
    public string nameGun;
    public string ammo;
}
