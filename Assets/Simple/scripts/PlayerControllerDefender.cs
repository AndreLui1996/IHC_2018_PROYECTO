using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerControllerDefender : NetworkBehaviour
{
    public AudioClip gunSound;
    // Use this for initialization
    AudioSource fuenteAudio;
    /// <summary>
    /// 
    public void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        Debug.Log("START");
    }
    /// </summary>

    public GameObject BolaPrefap;
    public Transform BolaSpawn;
    // Update is called once per frame
    public void Update()
    {


        if (!isLocalPlayer)
        {
            return;

        }
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire_t();

        }
        //void Update()

        Debug.Log("UPDATE");
        //Frame frame = Controller.Frame();
        //GestureList gestures = frame.Gestures();

        
        ////


    }

    public void Fire_t()
    {
        fuenteAudio.clip = gunSound;
        fuenteAudio.Play();
        GameObject Bola = (GameObject)Instantiate(BolaPrefap, BolaSpawn.position, BolaSpawn.rotation);
        //Bola.GetComponent<Rigidbody>().velocity = Bola.transform.forward;
        //NetworkServer.Spawn(Bola);

        
            // toggle visibility:
        Bola.SetActive(true);
            
        NetworkServer.Spawn(Bola);

        Destroy(Bola, 4);


    }


}
