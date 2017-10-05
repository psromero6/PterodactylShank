using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    public int height;
    public float speed;
    Vector3 translationVec;
    float startingHeight;
    // Use this for initialization
    void Start()
    {
        translationVec = new Vector3(0, speed * Time.fixedDeltaTime, 0);
        startingHeight = this.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > startingHeight + height) translationVec = new Vector3(0, -speed * Time.fixedDeltaTime, 0);
        else if (this.transform.position.y < startingHeight - height) translationVec = new Vector3(0, speed * Time.fixedDeltaTime, 0);

        this.transform.Translate(translationVec);
    }
}
