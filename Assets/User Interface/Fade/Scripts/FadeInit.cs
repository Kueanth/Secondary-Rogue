using UnityEngine;
using Leopotam.Ecs;

public class FadeInit : IEcsInitSystem
{
    private SceneData sceneData;
    private Money money;
    private UI ui;

    public void Init()
    {
        ui.gameScreen.fade.GetComponent<FadeNextRoom>().room = sceneData.roomEntity;
        ui.deadScreen.fade.GetComponent<FadeNextRoom>().room = sceneData.roomEntity;
        ui.gameScreen.fade.GetComponent<Animator>().SetTrigger("Start");
        ui.gameScreen.bar.enabled = false;
        ui.gameScreen.kristal.enabled = false;

        ui.gameScreen.InitMoney(money.money);
    }
}
