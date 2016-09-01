using UnityEngine;
using System.Collections;

[System.Serializable]
public class UserCommand
{
    public int m_commandFrame;

    // Client side interpolation time
    public float m_clientInterpTime;

    // Current player orientation
    public Quaternion m_clientRotation;

    // User movement input
    public float m_v, m_h;

    // Buttons
    public bool m_fire;
}

/*
public class UserCommand : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/
