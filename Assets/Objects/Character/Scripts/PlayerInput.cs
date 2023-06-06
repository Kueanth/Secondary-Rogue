using UnityEngine;
using Leopotam.Ecs;

public class PlayerInput : IEcsRunSystem
{
    private EcsFilter<Player> _filter;

    public SceneData sceneData;

    public float speed = 4f;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 gow = new Vector2(horizontal, vertical);
            gow.Normalize();

            components.rigidbody2D.velocity = gow * speed;

            Vector3 meow = components.transform.position;

            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if(positionMouse.y > 0)
            {

            }

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
            
            if(vertical >= 0.2f || vertical <= -0.2f)
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

            if (components.flipping)
            {
                components.gun.position =
                    new Vector3(meow.x + 0.2f + GunAnim.animX, meow.y + -0.2f + GunAnim.animY, 0f);
            }
            else
            {
                components.gun.position =
                    new Vector3(meow.x + -0.2f + GunAnim.animX, meow.y + -0.2f + GunAnim.animY, 0f);
            }
        }
    }
}
