using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class TestHealth : NetworkBehaviour
{
    public Slider m_healthDisplay;

    public const int m_maxHealth = 100;

    public bool m_destroyOnDeath = false;

    private NetworkStartPosition[] m_spawnPoints;

    //[SyncVar(hook = "OnChangeHealth")]
    [SyncVar]
    public int m_currentHealth = m_maxHealth;
    
    // Use this for initialization
    void Start ()
    {
        if (isLocalPlayer)
        {
            m_spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_healthDisplay.value = (float)m_currentHealth / (float)m_maxHealth;
    }
    
    public void TakeDamage (int amount)
    {
        if (!isServer)
        {
            return;
        }

        m_currentHealth -= amount;
        if (m_currentHealth <= 0)
        {
            if (m_destroyOnDeath)
            {
                Destroy(gameObject);
                return;
            }            

            m_currentHealth = m_maxHealth;

            // called on the Server, but invoked on the Clients
            RpcRespawn();
        }
    }

    [ClientRpc]
    void RpcRespawn()
    // called on the Server, but invoked on the Clients
    {
        if (isLocalPlayer)
        {
            // Set the spawn point to origin as a default value
            Vector3 spawnPoint = Vector3.zero;

            // If there is a spawn point array and the array is not empty, pick a spawn point at random
            if (m_spawnPoints != null && m_spawnPoints.Length > 0)
            {
                spawnPoint = m_spawnPoints[Random.Range(0, m_spawnPoints.Length)].transform.position;
            }

            // Set the player’s position to the chosen spawn point
            transform.position = spawnPoint;
        }
    }

    /*
    void OnChangeHealth (int health)
    {
        if (isServer)
        {
            Debug.Log("server says hello!");
        }
        else
        {
            Debug.Log("client says hello!");
        }

        m_healthDisplay.value = (float)m_currentHealth / (float)m_maxHealth;
    }
    */
}
