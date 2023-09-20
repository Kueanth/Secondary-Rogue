using UnityEngine;
using Leopotam.Ecs;
using System.Threading;

public class BulletShoot : IEcsRunSystem
{
    private EcsFilter<Player, GunComponents, Shoot> _filter;

    private StaticData configuration;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);
            ref GunComponents gunComponents = ref _filter.Get2(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);

            GameObject bulletObject = null;

            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gunComponents.gun.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotateZ + 90f);

            if (!components.flipping)
            {
                bulletObject =
                    GameObject.Instantiate(configuration.Bullet, gunComponents.bulletSpawn.position, rotation);
            }
            else if (components.flipping)
            {
                Vector2 temp = new Vector2(gunComponents.bulletSpawn.position.x, gunComponents.bulletSpawn.position.y + 0.25f);

                 bulletObject =
                    GameObject.Instantiate(configuration.Bullet, temp, rotation);
            }

            bulletObject.GetComponent<BulletTrigger>().particle = configuration.particleBullet;

            bulletObject.GetComponent<Rigidbody2D>().velocity = gunComponents.bulletSpawn.right * 20f;
        }
    }
}
