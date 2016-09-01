using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TestEnemySpawner : NetworkBehaviour
{
    public GameObject m_enemyPrefab;
    public int m_numEnemies;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public override void OnStartServer()
    {
        for (int i = 0; i < m_numEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-8.0f, 8.0f),
                0.0f,
                Random.Range(-8.0f, 8.0f));

            Quaternion spawnRotation = Quaternion.Euler(
                0.0f,
                Random.Range(0, 180),
                0.0f);

            GameObject enemy = (GameObject)Instantiate(m_enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }
}
