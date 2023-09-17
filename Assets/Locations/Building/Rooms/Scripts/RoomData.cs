using UnityEngine;

[CreateAssetMenu(menuName = "For Rooms/Data Room", fileName = "Room")]
public class RoomData : ScriptableObject
{
    public Room[] Rooms;
}