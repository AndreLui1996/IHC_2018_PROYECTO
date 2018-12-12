using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnEnemy : NetworkBehaviour {

    public GameObject enemyPrefap;
    // Use this for initialization
    public override void OnStartServer()
    {
        Vector3 spawnPosition = new Vector3(-2.589f, 1.77f, 15.5f);
        Quaternion spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        GameObject enemy = (GameObject)Instantiate(enemyPrefap,spawnPosition,spawnRotation);
        NetworkServer.Spawn(enemy);
    }
    
	
	// Update is called once per frame
	
}
