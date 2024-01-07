using UnityEngine;
using Leopotam.Ecs;

public class FadeNextRoom : MonoBehaviour
{
    public EcsEntity room;
    public Animator animator;

    public void InitRoom()
    {
        animator.Play("New State");
        room.Get<RoomCreate>();
    }

    public void Enter()
    {
        Progress.Instance.openPausedBar = true;
    }

    public void Exit()
    {
        Progress.Instance.openPausedBar = false;
    }
}
