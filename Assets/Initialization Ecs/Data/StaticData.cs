using UnityEngine;

[CreateAssetMenu(fileName = "Static Data", menuName = "Data/StaticData")]
public class StaticData : ScriptableObject
{
    public GameObject Player;
    public GameObject Camera;
    public GameObject Bullet;
}
