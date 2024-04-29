using Leopotam.Ecs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerInput : IEcsRunSystem
{
    private EcsFilter<Player, GunComponents> _filter;

    public bool particleRun;

    public static Joystick joystick;

    public static int value = 0;
    
    public SceneData sceneData;
    public UI ui;

    public void Run()
    {
        foreach (var i in _filter)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && !ui.deadScreen.deadScreen.activeSelf && !ui.pausedScreen.Fade.activeSelf ||
                Progress.Instance.isTab && !ui.deadScreen.deadScreen.activeSelf && !ui.pausedScreen.Fade.activeSelf)
            {
                Progress.Instance.isTab = false;

                if (value == 0 && !Progress.Instance.openPausedBar)
                {
                    ui.pausedScreen.GameObj.SetActive(true);
                    ui.pausedScreen.GameObj.GetComponent<Animator>().Play("Open");
                    ++value;
                }
                else if (value == 1 && Progress.Instance.openPausedBar)
                {
                    ui.pausedScreen.GameObj.GetComponent<Animator>().Play("Close");
                    --value;
                }
            }

            if (sceneData.paused) return;

            ref Player components = ref _filter.Get1(i);
            ref GunComponents gunComponents = ref _filter.Get2(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);

            float horizontal = 0;
            float vertical = 0;

            if (!components.pit)
            {
                if (!Progress.Instance.mobile)
                {
                    horizontal = Input.GetAxis("Horizontal");
                    vertical = Input.GetAxis("Vertical");
                }
                else
                {
                    if (joystick.Horizontal >= 0.5f || joystick.Horizontal <= -0.5f || joystick.Vertical >= 0.5f || joystick.Vertical <= -0.5f)
                    {
                        horizontal = joystick.Horizontal;
                        vertical = joystick.Vertical;
                    }
                }
            }

            if ((horizontal != 0f || vertical != 0) && components.transform.GetComponent<PlayerParticle>().particleRun && !components.pit)
            {
                components.transform.GetComponent<PlayerParticle>().MethodForReloadParticle();
            }

            // Movement
            Vector2 movement = new Vector2(horizontal, vertical);
            movement.Normalize();

            if (!components.pit)
            {
                components.rigidbody2D.velocity = movement * sceneData.playerSpeed;
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearChest || Progress.Instance.isF && components.nearChest)
            {
                Progress.Instance.isF = false;
                AudioObject.Instance.Click();

                components.chest.GetComponent<ChestTrigger>().OpenChest();

                components.nearChest = false;
                components.chest = null;
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearHatch || Progress.Instance.isF && components.nearHatch)
            {
                Progress.Instance.isF = false;
                AudioObject.Instance.Click();

                components.hatch.GetComponent<HatchTrigger>().OpenHatch();

                components.nearHatch = false;
                components.nearChest = false;
                components.nearGun = false;
                components.nearHp = false;
                components.nearBull = false;

                components.hpTransform = null;
                components.chest = null;
                components.hatch = null;
                components.gunInChest = null;
                components.bullTransform = null;
            }

            if(Input.GetKeyDown(KeyCode.F) && components.nearHp || Progress.Instance.isF && components.nearHp)
            {
                Progress.Instance.isF = false;
                AudioObject.Instance.Click();

                components.hpTransform.GetComponent<HpTrigger>().GetHp(ref entity, ref ui);

                components.nearHp = false;
                components.hpTransform = null;
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearBull || Progress.Instance.isF && components.nearBull)
            {
                Progress.Instance.isF = false;
                AudioObject.Instance.Click();

                components.bullTransform.GetComponent<BullTrigger>().GetBull(ref entity, ref ui);

                components.nearBull = false;
                components.bullTransform = null;
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearGun || Progress.Instance.isF && components.nearGun)
            {
                Progress.Instance.isF = false;
                AudioObject.Instance.Click();

                components.gunInChest.GetComponent<GunTrigger>().GetGun(ref entity, ref ui);

                components.nearGun = false;
                components.gunInChest = null;
            }

            // Get position
            Vector3 positionPlayer = components.transform.position;
            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - components.transform.position;

            // A great code for the correct rotation of the character
            if (positionMouse.x < 0)
            {
                components.flipping = true;

                if (components.flip == false)
                {
                    components.flip = true;

                    if (gunComponents.light.transform.localPosition.y != -0.3f)
                        gunComponents.light.transform.localPosition =
                            new Vector2(gunComponents.light.transform.localPosition.x, -0.3f);

                    if (gunComponents.lazer.transform.localPosition.y != -0.094f)
                        gunComponents.lazer.transform.localPosition =
                            new Vector2(gunComponents.lazer.transform.localPosition.x, -0.094f);
                }
            }
            else
            {
                components.flipping = false;

                components.flip = false;

                if (gunComponents.light.transform.localPosition.y != 0.3f)
                    gunComponents.light.transform.localPosition =
                        new Vector2(gunComponents.light.transform.localPosition.x, 0.3f);

                if (gunComponents.lazer.transform.localPosition.y != 0.094f)
                    gunComponents.lazer.transform.localPosition =
                        new Vector2(gunComponents.lazer.transform.localPosition.x, 0.094f);
            }

            if (vertical >= 0.2f || vertical <= -0.2f)
            {
                components.running = true;
            }

            if (horizontal >= 0.2f)
            {
                components.running = true;
                sceneData.Pet.GetComponent<SpriteRenderer>().flipX = false;
                sceneData.pointForPet.position =
                    new Vector2(components.transform.position.x, components.transform.position.y) + new Vector2(-0.8f, -0.5f);
            }
            else if (horizontal <= -0.2f)
            {
                components.running = true;
                sceneData.Pet.GetComponent<SpriteRenderer>().flipX = true;

                sceneData.pointForPet.position =
                    new Vector2(components.transform.position.x, components.transform.position.y) + new Vector2(0.8f, -0.5f);
            }
            else
            {
                if (vertical >= 0.2f || vertical <= -0.2f)
                {
                    components.running = true;
                }
                else
                {
                    components.running = false;
                }
            }

            // A great code for the correct rotation of the hand and light
            if (components.flipping)
            {
                gunComponents.gun.position =
                    new Vector3(positionPlayer.x + 0.2f + GunAnim.animX, positionPlayer.y + -0.2f + GunAnim.animY, 0f);
            }
            else
            {
                gunComponents.gun.position =
                    new Vector3(positionPlayer.x + -0.2f + GunAnim.animX, positionPlayer.y + -0.2f + GunAnim.animY, 0f);
            }

            Progress.Instance.isF = false;
            Progress.Instance.isR = false;
            Progress.Instance.isTab = false;
        }
    }
}
