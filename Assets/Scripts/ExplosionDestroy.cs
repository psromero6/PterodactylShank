using UnityEngine;
using System.Collections;

public class ExplosionDestroy : MonoBehaviour {
    new Animation animation;
    // Use this for initialization
    void Start () {
        Animation animation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(animation.isPlaying);
        //if(!animation.isPlaying) GameObject.Destroy(transform);


    }
}
