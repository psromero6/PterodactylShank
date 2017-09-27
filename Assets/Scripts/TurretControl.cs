using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour {
    Vector2 turretCenter = new Vector2(290,11);
    float aimWindow = 250;
    public GameObject missile;
    public float timeBetweenShots;
    int health;
    
    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(8, 8,true);
        Physics2D.IgnoreLayerCollision(0, 0, true);
        health = 100;
        
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
        /*
                if (Input.touches.Length > 0)
                {
                    Touch touch = Input.GetTouch(0);


                        float angle = Mathf.Atan2(touch.position.y - turretCenter.y, touch.position.x - turretCenter.x);
                        transform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);

                    if (touch.phase ==TouchPhase.Began)
                    {
                        Shoot();
                    }
                }
                */
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
