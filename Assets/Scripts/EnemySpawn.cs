using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public float spawnDelay;
    public GameObject enemy;
    float spawnTime;
    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate(){
        if (Time.time > spawnTime) {
            float y = transform.position.y+Random.Range(-1f, 1f);
            GameObject.Instantiate(enemy,new Vector3(transform.position.x,y,0),transform.rotation);
            spawnTime = Time.time + (spawnDelay+ Random.Range(-1f, 1f))/gameManager.timeScale;
        }
	
	}
}
