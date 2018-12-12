using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Bola : MonoBehaviour
    {
        Rigidbody rb;
        public float BulletSpeed;
        void Start()
        {
            //fuenteAudio = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();
            rb.AddRelativeForce(0, 0, BulletSpeed, ForceMode.Impulse);

        }

        void OnCollisionEnter(Collision collision)
        {
            //fuenteAudio = GetComponent<AudioSource>();
            GameObject hit = collision.gameObject;
            Vida_dragon health = hit.GetComponent<Vida_dragon>(); 
            if(health != null)
            {
                Debug.Log("ENTRII VIDA");
                //fuenteAudio.clip = gunSound;
                //fuenteAudio.Play();
                health.TakeDamage(3);  
            }
            Destroy(gameObject);
        }
    }
}