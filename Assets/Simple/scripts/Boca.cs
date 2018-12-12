using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Boca : NetworkBehaviour { 

    Transform player;
    public Transform DragonBoca;
    public GameObject bullet;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine("Shooting");
        }
    }
    public override void OnStartServer()
    {
        Shooting();

        //   BolaSpawn.GetComponent<Boca>().setTarget(gameObject.transform);
        //Dragon 
        
    }

    IEnumerator Shooting()
    {
        while (true){
            Instantiate(bullet, DragonBoca.position, DragonBoca.rotation);
            yield return new WaitForSeconds(2);
        }
    }



}
