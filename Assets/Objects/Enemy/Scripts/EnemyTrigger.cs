using UnityEngine;
using Leopotam.Ecs;

public class EnemyTrigger : MonoBehaviour
{
    public EcsEntity entity;
    public SceneData sceneData;
    public UI ui;
    public EcsEntity gunEntity;
    public Money money;
    public GameObject hpObject;

    public GameObject particle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls and Decoration" || collision.gameObject.tag == "Table")
        {
            entity.Get<EnemyNewFollow>();
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ref EnemyData components = ref entity.Get<EnemyData>();
        ref GunComponents componentsGun = ref sceneData.gunEntity.Get<GunComponents>();

        bool tempBool = false;

        if (collision.gameObject.tag == "Bullet")
        {
            components.hp -= componentsGun.damage;

            if (components.hp > 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Get Attack");
                components.rigidbody2D.AddForce(new Vector2(-(collision.transform.position.x - transform.position.x), -(collision.transform.position.y - transform.position.y)).normalized * 2f, ForceMode2D.Impulse);
            }   
            else
            {
                sceneData.enemyCount -= 1;
                sceneData.countKillEnemy += 1;
                ++Progress.Instance.PlayerInfoForSave.enemys;
                money.money += components.money;
                Progress.Instance.PlayerInfoForSave.money += components.money;
                ui.gameScreen.InitMoney(money.money);

                if (sceneData.enemyCount == 0)
                {
                    sceneData.levelComplete = true;

                    foreach (var hatch in sceneData.hatchs)
                    {
                        hatch.GetComponent<Animator>().SetTrigger("Open");
                        hatch.GetComponentInChildren<HatchTrigger>().levelComplete();
                    }

                    ui.gameScreen.EditInfoBar("щрюф опнидем");

                }

                GameObject effect = Instantiate(particle, gameObject.transform);
                effect.transform.parent = null;
                gameObject.GetComponent<Animator>().SetTrigger("Get Attack");

                int tempRange = Random.Range(0, 3);

                if(tempRange == 0)
                {
                    GameObject hpMainObject = GameObject.Instantiate(hpObject, gameObject.transform.position, Quaternion.identity);

                    Material hpMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));

                    hpMaterial.SetVector("_Right", new Vector2(0.8f, 0f));
                    hpMaterial.SetVector("_Left", new Vector2(-0.8f, 0f));
                    hpMaterial.SetVector("_Up", new Vector2(0f, 0.8f));
                    hpMaterial.SetVector("_Down", new Vector2(0f, -0.8f));

                    hpMaterial.color = new Color32(255, 230, 0, 255);

                    hpMainObject.GetComponent<SpriteRenderer>().material = hpMaterial;
                    Destroy(hpMainObject, 5);

                }

                entity.Destroy();
                Destroy(gameObject);
                tempBool = true;
            }
        }

        int temp = 0;

        if (!tempBool)
        {
            foreach (var i in components.targets)
            {
                if (i.gameObject.transform == collision.transform) ++temp;
            }
        }

        if (collision.gameObject.tag == "Check" && temp == 1)
        {
            entity.Get<EnemyNewFollow>();
        }
    }
}
