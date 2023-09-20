using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Leopotam.Ecs;

public class GameScreen : MonoBehaviour
{
    public Image aim;
    public Image fade;

    public TextMeshProUGUI textMeshPro;

    public EcsEntity entity;

    public void ShootUpdate(ref int ammo, ref int store)
    {
        --ammo;
        textMeshPro.text = ammo + "/" + store;
    }

    public void AmmoUpdate()
    {
        ref GunComponents gunComponents = ref entity.Get<GunComponents>();

        if(gunComponents.store - (gunComponents.maxAmmo - gunComponents.ammo) < 0)
        {
            gunComponents.ammo = gunComponents.store;
            gunComponents.store = 0;
        }
        else if(gunComponents.store <= 0)
        {
            return;
        }
        else
        {
            gunComponents.store -= gunComponents.maxAmmo - gunComponents.ammo;
            gunComponents.ammo = gunComponents.maxAmmo;
        }

        textMeshPro.text = gunComponents.ammo + "/" + gunComponents.store;
        gunComponents.reolading = false;
    }
}
