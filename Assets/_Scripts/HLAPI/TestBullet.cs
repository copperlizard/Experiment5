using UnityEngine;
using System.Collections;

public class TestBullet : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision other)
    {   
        TestHealth health = other.gameObject.GetComponent<TestHealth>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
