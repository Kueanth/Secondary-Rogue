using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Joystick joystick;

    public GameScreen gameScreen;
    public DeadScreen deadScreen;
    public PausedScreen pausedScreen;

    public Sprite[] imageHp;
    public Sprite[] imageGun;
}
