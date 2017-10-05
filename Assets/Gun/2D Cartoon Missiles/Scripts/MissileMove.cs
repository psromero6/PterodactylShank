using UnityEngine;
using System.Collections;

public class MissileMove : MonoBehaviour
{
    public float speed;
    bool death;
    float killTime, vanishTime, lifeSpan;
    void Start()
    {
        transform.GetChild(0).GetComponent<ParticleEmitter>().emit = true;
        vanishTime = Time.time + lifeSpan;

    }

    void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
        if (death && Time.time > killTime)
        {
            GameObject.Destroy(transform.gameObject);
        }
        if (transform.position.magnitude > 8)
        {
            GameObject.Destroy(transform.gameObject);
        }
    }

    void OnCollisionEnter2D()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        speed = 0;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        killTime = Time.time + 0.45f;
        death = true;
    }
}
