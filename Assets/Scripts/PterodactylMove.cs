using UnityEngine;
using System.Collections;

public class PterodactylMove : MonoBehaviour
{
    public float speed;
    public GameObject weapon;
    public float attackDelay;
    public int scoreValue;
    public GameObject postKillItem;

    GameManager gameManager;
    bool death;
    float attackTime;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        attackTime = attackDelay + Random.Range(-1, 1);
    }

    void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
        if (death)
        {
            gameManager.ScoreIncrease(scoreValue);
            GameObject.Instantiate(postKillItem, transform.position, new Quaternion(0, 0, 0, 0));
            GameObject.Destroy(transform.gameObject);

        }
        if (transform.position.x > 3.8 || transform.position.x < -3.8)
        {

            GameObject.Destroy(transform.gameObject);
        }
        if (Time.time > attackTime)
        {
            GameObject.Instantiate(weapon, new Vector3(transform.position.x,transform.position.y-1,0), transform.rotation);
            attackTime = Time.time + attackDelay + Random.Range(-1f, 1f);

        }
    }

    void OnCollisionEnter2D()
    {

        // speed = 0;
        death = true;
    }
}
