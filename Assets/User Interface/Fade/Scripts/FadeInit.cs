using UnityEngine;
using Leopotam.Ecs;

public class FadeInit : IEcsInitSystem
{
    private SceneData sceneData;
    private UI ui;

    public void Init()
    {
        ui.gameScreen.fade.GetComponent<FadeNextRoom>().room = sceneData.roomEntity;
        ui.gameScreen.fade.GetComponent<Animator>().SetTrigger("Start");
    }
}
