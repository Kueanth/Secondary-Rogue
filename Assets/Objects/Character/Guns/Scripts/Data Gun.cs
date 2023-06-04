using UnityEngine;

[CreateAssetMenu(fileName = "Data Gun", menuName = "Data Guns / Gun")]
public class DataGun : ScriptableObject
{
    public Sprite sprite;
    public string nameGun;
    public string ammo;
}
