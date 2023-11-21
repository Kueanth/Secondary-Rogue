using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Leopotam.Ecs;

public class GameScreen : MonoBehaviour
{
    public Image aim;
    public Image fade;
    public Image hp;
    public Image gun;
    public Image kristal;
    public Image bar;
    public Image infoBar;
    public GameObject gameScreen;

    [SerializeField]
    [Range(0, 100)] private float speed;

    [SerializeField] private GameObject authPlayer;
    [SerializeField] private TextMeshProUGUI namePlayer;
    [SerializeField] private RawImage icon;

    public TextMeshProUGUI money;

    public Vector2 startPosition;

    public TextMeshProUGUI textMeshPro;

    public EcsEntity entity;

    private void Awake()
    {
        if (Progress.Instance.PlayerInfoForGame.auth && Progress.Instance.PlayerInfoForGame.name != "")
        {
            authPlayer.SetActive(true);
            namePlayer.text = Progress.Instance.PlayerInfoForGame.name;
            icon.texture = Progress.Instance.PlayerInfoForGame.icon;
        }
        else
        {
            authPlayer.SetActive(false);
        }
    }

    public void ShootUpdate(ref int ammo, ref int store)
    {
        --ammo;
        textMeshPro.text = ammo + "/" + store;
    }

    public void GetGun(int ammo, int store)
    {
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

    public void EditHpBar(int hp, Sprite sprite)
    {
        this.hp.sprite = sprite;
    }

    public void EditGun(Sprite sprite)
    {
        this.gun.sprite = sprite;
    }

    public void StartReloadBar(float speed)
    {
        kristal.enabled = true;
        bar.enabled = true;
        kristal.GetComponent<Animator>().SetFloat("New Float", 1f / speed);
        kristal.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void EndReloadBar()
    {
        kristal.enabled = false;
        bar.enabled = false;
    }

    public void EditInfoBar(string text)
    {
        infoBar.GetComponentInChildren<TextMeshProUGUI>().text = text;

        infoBar.GetComponent<Animator>().SetTrigger("SetBar");
    }

    public void InitMoney(int value)
    {
        money.text = value.ToString();
    }
}
