using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour {
    Rigidbody rb;
    public AudioClip gunSound;
    public AudioClip rifleSound;
    AudioSource fuenteAudio;
    public float BulletSpeed;
    // Use this for initialization
    //fuenteAudio = GetComponent<AudioSource>();
	void Start () {
        fuenteAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, BulletSpeed, ForceMode.Impulse);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Vida health = hit.GetComponent<Vida>();
        if (collision.relativeVelocity.magnitude > 5) {
            Debug.Log("sonidoooooooo");
            fuenteAudio.clip = gunSound;
            fuenteAudio.Play();
        }

        if (health != null)
        {   //fuenteAudio.clip = gunSound;
            health.TakeDamage(10);
        }
        //fuenteAudio.clip = gunSound;
        //fuenteAudio.Play();
        Destroy(gameObject);
        
    }

}