using UnityEngine;
using Leopotam.Ecs;

public class FadeInit : IEcsInitSystem
{
    private UI ui;

    public void Init()
    {
        ui.gameScreen.fade.GetComponent<Animator>().SetTrigger("Start");
    }
}
