using Leopotam.Ecs;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerInput : IEcsRunSystem
{
    private EcsFilter<Player> _filter;

    public SceneData sceneData;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

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
            }

            if (Input.GetKeyDown(KeyCode.F) && components.nearHatch)
            {
                components.hatch.GetComponent<HatchTrigger>().OpenHatch();

                components.nearHatch = false;
                components.nearChest = false;
            }
            
            if(Input.GetKeyDown(KeyCode.F) && components.nearGun)
            {
                components.gunInChest.GetComponent<GunTrigger>().GetGun(components);
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

                    if (components.light.transform.localPosition.y != -0.3f)
                        components.light.transform.localPosition =
                            new Vector2(components.light.transform.localPosition.x, -0.3f);
                }
            }
            else
            {
                components.flipping = false;

                components.flip = false;

                if (components.light.transform.localPosition.y != 0.3f)
                    components.light.transform.localPosition =
                        new Vector2(components.light.transform.localPosition.x, 0.3f);
            }

            if (vertical >= 0.2f || vertical <= -0.2f)
            {
                components.running = true;
            }

            if (horizontal >= 0.2f)
            {
                components.running = true;
            }
            else if (horizontal <= -0.2f)
            {
                components.running = true;
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

                components.gun.position =
                    new Vector3(positionPlayer.x + 0.2f + GunAnim.animX, positionPlayer.y + -0.2f + GunAnim.animY, 0f);
            }
            else
            {
                components.gun.position =
                    new Vector3(positionPlayer.x + -0.2f + GunAnim.animX, positionPlayer.y + -0.2f + GunAnim.animY, 0f);
            }

            // For shots
            if (Input.GetMouseButtonDown(0) && !components.pit)
            {
                entity.Get<Shoot>();
            }
        }
    }
}
