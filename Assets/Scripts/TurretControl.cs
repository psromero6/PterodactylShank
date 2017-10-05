using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour {
    Vector2 turretCenter = new Vector2(290,11);
    public GameObject missile;
    public float timeBetweenShots;
    
    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(8, 8,true);
        Physics2D.IgnoreLayerCollision(0, 0, true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            float angle = Mathf.Atan2(Input.mousePosition.y - turretCenter.y, Input.mousePosition.x - turretCenter.x);
            transform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);

            
                Shoot();
            
        }
        
    }


    void OnMouseDown() {
        
            float angle = Mathf.Atan2(Input.mousePosition.y - turretCenter.y, Input.mousePosition.x - turretCenter.x);
        transform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);
        Shoot();
    }

    void Shoot() {
        GameObject.Instantiate(missile, transform.position, transform.rotation);

    }

}
