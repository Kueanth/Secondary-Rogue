using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Static Data", menuName = "Data/StaticData")]
public class StaticData : ScriptableObject
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Camera;
    public GameObject Bullet;
    public GameObject particleBullet;
    public GameObject Chest;
    public GameObject Hatch;
    public Texture2D Cursor;
}
