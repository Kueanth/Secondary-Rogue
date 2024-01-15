using Leopotam.Ecs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerInput : IEcsRunSystem
{
    private EcsFilter<Player, GunComponents> _filter;

    public bool particleRun;

    public static int value = 0;
    
    public SceneData sceneData;
    public UI ui;

    public void Run()
    {
        foreach (var i in _filter)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && !ui.deadScreen.deadScreen.activeSelf && !ui.pausedScreen.Fade.activeSelf)
            {
                if (value == 0 && !Progress.Instance.openPausedBar)
                {
                    ui.pausedScreen.GameObj.Play("Open");
                    ++value;
                }
                else if (value == 1 && Progress.Instance.openPausedBar)
                {
                    ui.pausedScreen.GameObj.Play("Close");
                    --value;
                }
            }

            if (sceneData.paused) return;

            ref Player components = ref _filter.Get1(i);
            ref GunComponents gunComponents = ref _filter.Get2(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

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

            if (Input.GetKeyDown(KeyCode.F) && components.nearChest)
            {
                components.chest.GetComponent<ChestTrigger>().OpenChest();

                components.nearChest = false;
                components.chest = null;
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearHatch)
            {
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

            if(Input.GetKeyDown(KeyCode.F) && components.nearHp)
            {
                components.hpTransform.GetComponent<HpTrigger>().GetHp(ref entity, ref ui);

                components.nearHp = false;
                components.hpTransform = null;
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearBull)
            {
                components.bullTransform.GetComponent<BullTrigger>().GetBull(ref entity, ref ui);

                components.nearBull = false;
                components.bullTransform = null;
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearGun)
            {
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
                sceneData.Pet.GetComponent<Animator>().SetBool("Speed", true);
            }

            if (horizontal >= 0.2f)
            {
                components.running = true;
                sceneData.Pet.GetComponent<Animator>().SetBool("Speed", true);
                sceneData.Pet.GetComponent<SpriteRenderer>().flipX = false;
                sceneData.pointForPet.position =
                    new Vector2(components.transform.position.x, components.transform.position.y) + new Vector2(-0.8f, -0.5f);
            }
            else if (horizontal <= -0.2f)
            {
                components.running = true;
                sceneData.Pet.GetComponent<Animator>().SetBool("Speed", true);
                sceneData.Pet.GetComponent<SpriteRenderer>().flipX = true;

                sceneData.pointForPet.position =
                    new Vector2(components.transform.position.x, components.transform.position.y) + new Vector2(0.8f, -0.5f);
            }
            else
            {
                if (vertical >= 0.2f || vertical <= -0.2f)
                {
                    components.running = true;
                    sceneData.Pet.GetComponent<Animator>().SetBool("Speed", true);
                }
                else
                {
                    components.running = false;
                    sceneData.Pet.GetComponent<Animator>().SetBool("Speed", false);
                }
            }

            // A great code for the correct rotation of the hand and light
            if (components.flipping)
            {
                gunComponents.gun.position =
                    new Vector3(positionPlayer.x + 0.2f + GunAnim.animX, positionPlayer.y + -0.2f + GunAnim.animY, 0f);
                sceneData.Pet.GetComponent<SpriteRenderer>().flipX = true;
                sceneData.pointForPet.position =
                    new Vector2(components.transform.position.x, components.transform.position.y) + new Vector2(0.8f, -0.5f);
            }
            else
            {
                gunComponents.gun.position =
                    new Vector3(positionPlayer.x + -0.2f + GunAnim.animX, positionPlayer.y + -0.2f + GunAnim.animY, 0f);
            }
        }
    }
}
