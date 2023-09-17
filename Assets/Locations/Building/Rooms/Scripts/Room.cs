using UnityEngine;

[CreateAssetMenu(fileName = "Room",menuName = "For Rooms/Room")]
public class Room : ScriptableObject
{
    public GameObject RoomPrefab;
    public Vector2 spawnPositionPlayer;
}
