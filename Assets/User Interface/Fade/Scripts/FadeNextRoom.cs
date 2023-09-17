using UnityEngine;
using Leopotam.Ecs;

public class FadeNextRoom : MonoBehaviour
{
    public EcsEntity room;

    public void InitRoom()
    {
        room.Get<RoomCreate>();
    }
}
