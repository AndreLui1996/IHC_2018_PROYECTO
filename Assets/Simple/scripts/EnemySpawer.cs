using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class EnemySpawer : NetworkBehaviour {
    public GameObject enemyPrefap;
    public int numberOfEnemies;
    // Use this for initialization
    public override void OnStartServer()
    {
        Vector3 spawPos = new Vector3(-4.0f, 0.0f, 4.0f);
        Quaternion spawnRot = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        GameObject enemy = (GameObject)Instantiate(enemyPrefap, spawPos,spawnRot);
        NetworkServer.Spawn(enemy);
    }
    
}
