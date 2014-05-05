using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    public GameObject prefab;
    public int speed;
    public AudioClip[] clips;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 trans = transform.position;
        transform.position = new Vector3(trans.x, trans.y - speed * Time.deltaTime, trans.z);
        if (trans.y < 0)
        {
            audio.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            Instantiate(prefab, transform.position, Quaternion.identity);
            transform.position = new Vector3(Random.Range(0, 60), 50, -16);
        }
	}
}
