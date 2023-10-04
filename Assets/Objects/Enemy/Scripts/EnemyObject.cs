using UnityEngine;

[CreateAssetMenu(menuName = "EnemyObject/Enemy", fileName = "EnemyObject")]
public class EnemyObject : ScriptableObject
{
    public GameObject enemyObject;
    public string enemyName;
    public int hp;
}
