using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {
    public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < -4) {
            GameObject.Destroy(transform.gameObject);
        }
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Ground ground;
        if (ground=coll.gameObject.GetComponent<Ground>()) {
            ground.TakeDamage(damage);

        }
        GameObject.Destroy(transform.gameObject);

    }
}
