using UnityEngine;
using System.Collections;

public class LLAPIPlayerController : MonoBehaviour
{
    private float m_v, m_h;
    private bool m_fire;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
	}

    void GetInput ()
    {
        m_v = Input.GetAxis("Vertical");
        m_h = Input.GetAxis("Horizontal");
        m_fire = Input.GetButton("Jump"); //change this later!!!
    }
}
