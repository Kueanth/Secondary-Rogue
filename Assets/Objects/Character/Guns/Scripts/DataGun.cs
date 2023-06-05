using UnityEngine;

[CreateAssetMenu(fileName = "DataGun", menuName = "Data Guns/DataGun")]
public class DataGun : ScriptableObject
{
    public Sprite sprite;
    public string nameGun;
    public string ammo;
}
