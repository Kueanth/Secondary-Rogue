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
                if(gunComponents.gunData.nameGun == "Drobovik")
                {
                    for(int x = 0; x <= 5; x++)
                    {
                        int randomRotation = Random.Range(-10, 10);

                        Quaternion tempRotation = Quaternion.Euler(0f, 0f, rotateZ + randomRotation - 90f);

                        int randomVelocity = Random.Range(15, 30);

                        bulletObject =
                            GameObject.Instantiate(configuration.Bullet, gunComponents.bulletSpawn.position, tempRotation);

                        bulletObject.GetComponent<BulletTrigger>().particle = configuration.particleBullet;
                        
                        bulletObject.GetComponent<Rigidbody2D>().velocity =
                            bulletObject.transform.up * randomVelocity;

                        GameObject.Destroy(bulletObject, 0.4f);
                    }
                }
                else
                {
                    bulletObject =
                    GameObject.Instantiate(configuration.Bullet, gunComponents.bulletSpawn.position, rotation);

                    bulletObject.GetComponent<BulletTrigger>().particle = configuration.particleBullet;

                    bulletObject.GetComponent<Rigidbody2D>().velocity = gunComponents.bulletSpawn.right * 20f;
                }
            }
            else if (components.flipping)
            {
                if (gunComponents.gunData.nameGun == "Drobovik")
                {
                    for (int x = 0; x <= 5; x++)
                    {
                        int randomRotation = Random.Range(-10, 10);

                        Quaternion tempRotation = Quaternion.Euler(0f, 0f, rotateZ + randomRotation - 90f);

                        int randomVelocity = Random.Range(15, 30);

                        Vector2 temp = new Vector2(gunComponents.bulletSpawn.position.x, gunComponents.bulletSpawn.position.y + 0.35f);

                        bulletObject =
                           GameObject.Instantiate(configuration.Bullet, temp, tempRotation);

                        bulletObject.GetComponent<BulletTrigger>().particle = configuration.particleBullet;

                        bulletObject.GetComponent<Rigidbody2D>().velocity =
                            bulletObject.transform.up * randomVelocity;

                        GameObject.Destroy(bulletObject, 0.4f);
                    }
                }
                else
                {
                    Vector2 temp = new Vector2(gunComponents.bulletSpawn.position.x, gunComponents.bulletSpawn.position.y + 0.35f);

                    bulletObject =
                       GameObject.Instantiate(configuration.Bullet, temp, rotation);

                    bulletObject.GetComponent<BulletTrigger>().particle = configuration.particleBullet;

                    bulletObject.GetComponent<Rigidbody2D>().velocity = gunComponents.bulletSpawn.right * 20f;
                }
            }
        }
    }
}