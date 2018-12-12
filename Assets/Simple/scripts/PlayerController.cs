using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Leap;
//using Leap.Unity;

public class PlayerController : NetworkBehaviour {
    /// las dos manos
    public Vector HandRightPos;
    public Vector HandLeftRot;

    ///sonido
    public AudioClip gunSound;
    public AudioClip gunSound_friend;

    public AudioClip moverse;

    public AudioClip rifleSound;
    // Use this for initialization
    AudioSource fuenteAudio;


    public GameObject Amigo;

    public GameObject BolaPrefap_amigo;

    public GameObject BolaPrefap;
    public GameObject EnemigoPrefap;
    public Transform BolaSpawn;
    ///


    /// <summary>
    public Controller Controller;

    public PlayerControllerDefender other;
    public GameObject SpawnZone;
    /// <summary>
    float HandPalmPith;
    float HandPalmYam;
    float HandPalmRoll;
    float HandPalmRollRight;
    float HandPalmPithRight;
    float HandPalmYamRight;
    float HandWristRot;
    float x;
    /// </summary>


    /// 

    void Start()
    {

        fuenteAudio = GetComponent<AudioSource> ();
        Controller = new Controller();
        Debug.Log("START");
        //Controller.EnableGesture(Gesture.GestureType.TYPECIRCLE, true);
        //Controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP, true);
        //Controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP, true);
        //Controller.EnableGesture(Gesture.GestureType.TYPESWIPE, true);
    }
    /// </summary>
    /// 
    // Update is called once per frame
    void Update()
    {
        float x;
        /*    if (isClient.)
            {
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



            }
          */
        if (!isLocalPlayer)
        {   
            return; 
        }

        x = Input.GetAxis("Horizontal");
        //Debug.Log(x);
        x =x*Time.deltaTime * 4.0f;

        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            float x_1 = 2 * Time.deltaTime * 50.0f;
            float z_1 = 8 * Time.deltaTime * 1.0f;
        //Debug.Log(x);    

        //transform.Translate(x, 0, 0);
        /*
        if (x==0.0)
        {
            fuenteAudio.clip = moverse;
            fuenteAudio.Play();
            Debug.Log(x);
            
        }*/

        transform.Translate(x, 0, 0);
        //x = 0;
            //transform.Rotate(0, x, 0);
            //transform.Translate(0, x|, 0);

            Frame frame = Controller.Frame();

            HandList hands = frame.Hands;
            Hand hands_ = frame.Hands.Frontmost;

            Hand HandLeft = frame.Hands.Leftmost;
            Hand HandRight = frame.Hands.Rightmost;
            //HandLeftRot = HandLeft.Direction;
            //Debug.Log("Left rot: " + HandLeftRot);
            HandRightPos = HandRight.PalmPosition;
            Debug.Log("Right pos: " + HandRightPos);
            Debug.Log(HandRightPos.x);
            if (hands_.IsRight)
            {
                Debug.Log("DEEEEEEREEEVHAAAAA");
                //            transform.Translate(-x, 0, 0);
                //transform.Translate(new Vector3(1 * Time.deltaTime * 10.0f, 0, 0));
                if (HandPalmRoll > -2f && HandPalmRoll < 3.5f)
                {

                    if (HandRightPos.x < 0)
                    {
                        transform.Translate(new Vector3(-1 * Time.deltaTime * 7.0f, 0, 0));
                    //    Debug.Log("DEEEEEEREEEVHAAAAA");
                        fuenteAudio.clip = moverse;
                        fuenteAudio.Play();
                    }
                    if (HandRightPos.x > 0)
                    {
                        transform.Translate(new Vector3(1 * Time.deltaTime * 7.0f, 0, 0));
                    ///  Debug.Log("IZQUIERRRRDAAAAAAAA");
                        fuenteAudio.clip = moverse;
                        fuenteAudio.Play();
                    }



                }
                //if (HandPalmYam < -2.2f)
                //{

                //                Fire();
                //          }

            }

            if (hands_.IsLeft)
            {
                //Debug.Log("DEEEEEEREEEVHAAAAA");
                //            transform.Translate(-x, 0, 0);
                //transform.Translate(new Vector3(1 * Time.deltaTime * 10.0f, 0, 0));
                if (HandPalmYam > -2.2f)
                {
                    CmdFire();
                }

            }


            if (frame.Hands.Count > 0)
            {
                Hand fristHand = hands[0];
            }
            HandPalmPith = hands[0].PalmNormal.Pitch;
            HandPalmRoll = hands[0].PalmNormal.Roll;
            //       HandPalmRollRight = hand.;
            //            hands[0].PalmNormal.Roll;

            HandPalmYam = hands[0].PalmNormal.Yaw;

            HandWristRot = hands[0].WristPosition.Pitch;

            //Debug.Log("Pitch :" + HandPalmPith);
            Debug.Log("Roll :" + HandPalmRoll);
        //Debug.Log("Yum :" + HandPalmYam);

        //if (HandPalmPith > -2f && HandPalmPith < 3.5f)
        //{
        //  Fire();
        //transform.Translate(new Vector3(-1 * Time.deltaTime * 10.0f, 0, 0));
        //transform.Translate(x, 0, 0);
        //}
        //else if (HandPalmPith < -2.2f) {
        //            transform.Translate(-x, 0, 0);
        //  transform.Translate(new Vector3(1 * Time.deltaTime * 10.0f, 0, 0));

        //}
        /*        else if (HandPalmYam < -2.2f)
                {
                    //            transform.Translate(-x, 0, 0);
                    transform.Translate(new Vector3(1 * Time.deltaTime * 10.0f, 0, 0));

                */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //x = 5;
            Debug.Log("entro a espacio");
            CmdFire_friend();
            //CmdFire();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //x = 5;
            Debug.Log("entro a espacio");
            CmdFire();
            //CmdFire();
        }

    }
    /////////////////// CAMBIO ///////////////
    /*
    GestureList gestures = frame.Gestures();
    Gesture gesture = gestures[0];
    //if (Input.GetKeyDown(KeyCode.Space))
    if (gesture.Type == Gesture.GestureType.TYPECIRCLE)
    {
        //transform.Rotate(0, x_1, 0);
        transform.Translate(0, 0, z_1);
    }

    if (gesture.Type == Gesture.GestureType.TYPESWIPE)
    {
        //transform.Rotate(0, x_1, 0);
        transform.Translate(0, 0, -z_1);
    }


    if (Input.GetKeyDown(KeyCode.Space) || gesture.Type == Gesture.GestureType.TYPEKEYTAP)
    {
        Fire();

    }
    //void Update()

        Debug.Log("UPDATE");
        //Frame frame = Controller.Frame();
        //GestureList gestures = frame.Gestures();

        Debug.Log(" gestures: " + gestures.Count.ToString());

        for (int i = 0; i < gestures.Count; i++)
        {
            //Gesture gesture = gestures[0];
            switch (gesture.Type)
            {
                case Gesture.GestureType.TYPECIRCLE:
                    Debug.Log("Circle");
                    break;
                case Gesture.GestureType.TYPEKEYTAP:
                    Debug.Log("keytap");
                    break;
                case Gesture.GestureType.TYPESWIPE:
                    //Fire();
                    Debug.Log("swipe");
                    break;
                case Gesture.GestureType.TYPE_SCREEN_TAP:
                    Debug.Log("screen tap");
                    break;
                default:
                    Debug.Log("Bad gesture type");
                    break;
            }
        }
    //////////////////////////////////////
    */


    //}
    //[Command]
    public void Fire_t()
    {

        GameObject Bola = (GameObject)Instantiate(BolaPrefap, BolaSpawn.position, BolaSpawn.rotation);
        //Bola.GetComponent<Rigidbody>().velocity = Bola.transform.forward;
        //NetworkServer.Spawn(Bola);


        // toggle visibility:
        Bola.SetActive(true);

        NetworkServer.Spawn(Bola);

        Destroy(Bola, 2);


    }
    [Command]
    public void CmdFire_friend()
    {
        fuenteAudio.clip = gunSound_friend;
        fuenteAudio.Play();
        GameObject Bola = (GameObject)Instantiate(BolaPrefap_amigo, BolaSpawn.position, BolaSpawn.rotation);
        //Bola.GetComponent<Rigidbody>().velocity = Bola.transform.forward;
        //NetworkServer.Spawn(Bola);


        // toggle visibility:
        Bola.SetActive(true);

        NetworkServer.Spawn(Bola);

        Destroy(Bola, 1);


    }



    [Command]
    public void CmdFire()
    {
        fuenteAudio.clip = gunSound;
        fuenteAudio.Play();
        GameObject Bola = (GameObject)Instantiate(BolaPrefap, BolaSpawn.position, BolaSpawn.rotation);
        Bola.GetComponent<Rigidbody>().velocity = Bola.transform.forward * 5.0f;
        NetworkServer.Spawn(Bola); 

        Destroy(Bola, 5);
    }

    /*
    public override void OnStartLocalPlayer()   
    {
        PlayerControllerDefender.Instantiate(Amigo);
        other = Amigo.GetComponent<PlayerControllerDefender>();
        //GetComponent<MeshRenderer>().material.color = Color.blue;
        PlayerControllerDefender otherScript = GetComponent<PlayerControllerDefender>();

        other.Start();
        other.Update();

    }
    
    public override void OnStartClient()
    {
        GameObject Bola = (GameObject)Instantiate(BolaPrefap, BolaSpawn.position, BolaSpawn.rotation);
        Bola.GetComponent<Rigidbody>().velocity = Bola.transform.forward * 8.0f;
        NetworkServer.Spawn(Bola);

        Destroy(Bola, 5);

        /*
        other = Amigo.GetComponent<PlayerControllerDefender>();
        GetComponent<MeshRenderer>().material.color = Color.blue;
        PlayerControllerDefender otherScript = GetComponent<PlayerControllerDefender>();
        other.Start();
        other.Update();
   
    }
    */
    public override void OnStartLocalPlayer()
   {
     //   BolaSpawn.GetComponent<Boca>().setTarget(gameObject.transform);
        //Dragon 
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }

}
