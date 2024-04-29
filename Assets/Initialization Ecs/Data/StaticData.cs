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
    public GameObject Hp;
    public GameObject Bull;

    public Joystick joystick;

    public Texture2D Cursor;

    public GameObject[] Pets;

    public Sprite[] _boards;
    public Sprite[] _playerAuthBoards;
}
