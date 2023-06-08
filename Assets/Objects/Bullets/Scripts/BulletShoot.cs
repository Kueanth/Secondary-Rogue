using UnityEngine;
using Leopotam.Ecs;

public class BulletShoot : IEcsRunSystem
{
    private EcsFilter<Player, Shoot> _filter;

    private StaticData configuration;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);

            GameObject bulletObject = null;

            if (!components.flipping)
            {
                bulletObject =
                    GameObject.Instantiate(configuration.Bullet, components.bulletSpawn.position, components.gun.rotation);
            }

            if (components.flipping)
            {
                Debug.Log("df");
                Vector2 temp = new Vector2(components.bulletSpawn.position.x, components.bulletSpawn.position.y + 0.32f);

                 bulletObject =
                    GameObject.Instantiate(configuration.Bullet, temp, components.gun.rotation);
            }

            Rigidbody2D bpl = bulletObject.GetComponent<Rigidbody2D>();

            bpl.velocity = bulletObject.transform.up * 20f;
            entity.Del<Shoot>();
        }
    }
}
