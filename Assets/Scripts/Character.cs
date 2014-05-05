using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    float lastX;
    bool isMoving = false;
    public GameObject explosion;



	// Use this for initialization
	void Start () 
    {
        animation.Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float halfW = Screen.width / 2;
        Vector3 trans = transform.position;
        transform.position = new Vector3((Input.mousePosition.x) / 20, trans.y, trans.z);
        if (lastX != transform.position.x)
        {
            if (!isMoving)
            {
                isMoving = true;
                if (!animation.IsPlaying("catch"))
                {
                    animation.Play("step");
                }
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                if (!animation.IsPlaying("catch"))
                {
                    animation.Play("idle");
                }
            }
        }
        lastX = transform.position.x;
	}

    void OnCollisionEnter(Collision other)
    {
        Vector3 trans = other.gameObject.transform.position;
        if (other.gameObject.tag == "bomb")
        {
            Instantiate(explosion, trans, Quaternion.identity);
        }
        else if (other.gameObject.tag == "stein")
        {
            animation.Play("catch");
        }
        
        other.gameObject.transform.position = new Vector3(Random.Range(0, 60), 50, trans.z);
    }
}
