using UnityEngine;
using Leopotam.Ecs;

public class PlayerInput : IEcsRunSystem
{
    private EcsFilter<Player> _filter;

    public SceneData sceneData;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);       
            
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Movement
            Vector2 movement = new Vector2(horizontal, vertical);
            movement.Normalize();
            components.rigidbody2D.velocity = movement * sceneData.playerSpeed;

            // Get position
            Vector3 positionPlayer = components.transform.position;
            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // A great code for the correct rotation of the character
            if (positionMouse.x < 0)
            {
                components.flipping = true;
                components.flipGun.flipX = true;
            }
            else
            {
                components.flipping = false;
                components.flipGun.flipX = false;
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

            // A great code for the correct rotation of the hand
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
            if (Input.GetMouseButtonDown(0))
            {
                entity.Get<Shoot>();
            }
        }
    }
}
