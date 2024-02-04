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
    public GameObject bullObject;
    public bool isDead;
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
                if (isDead) return;

                isDead = true;

                sceneData.enemyCount -= 1;
                sceneData.countKillEnemy += 1;
                money.money += components.money;


                if (sceneData.enemyCount == 0)
                {
                    sceneData.levelComplete = true;

                    foreach (var hatch in sceneData.hatchs)
                    {
                        hatch.GetComponent<Animator>().SetTrigger("Open");
                        hatch.GetComponentInChildren<HatchTrigger>().levelComplete();
                    }

                    if (Progress.Instance.PlayerInfoForSave.lan == 2)
                        ui.gameScreen.EditInfoBar("THE FLOOR IS PASSED");
                    else
                        ui.gameScreen.EditInfoBar("щрюф опнидем");

                }

                GameObject effect = Instantiate(particle, gameObject.transform);
                effect.transform.parent = null;
                gameObject.GetComponent<Animator>().SetTrigger("Get Attack");

                int tempRange = Random.Range(0, 4);

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
                else if(tempRange == 1)
                {
                    GameObject bullMainObject = GameObject.Instantiate(bullObject, gameObject.transform.position, Quaternion.identity);

                    Material bullMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));

                    bullMaterial.SetVector("_Right", new Vector2(0.8f, 0f));
                    bullMaterial.SetVector("_Left", new Vector2(-0.8f, 0f));
                    bullMaterial.SetVector("_Up", new Vector2(0f, 0.8f));
                    bullMaterial.SetVector("_Down", new Vector2(0f, -0.8f));

                    bullMaterial.color = new Color32(255, 230, 0, 255);

                    bullMainObject.GetComponent<SpriteRenderer>().material = bullMaterial;
                    Destroy(bullMainObject, 5);
                }

                tempBool = true;
                Destroy(gameObject);
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

    private void OnDestroy()
    {
        entity.Destroy();
    }
}
