using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServedStar : MonoBehaviour
{
    public float lifetime;
    float startTime;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0.01f, 0));
        //Check for time lived. Destroy if alive as long as lifetime;
        if (Time.time - startTime > lifetime)
        {
            GameObject.Destroy(this.gameObject);
        }



    }
}
