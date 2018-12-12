using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_fire : MonoBehaviour {

    public AudioClip gunSound;
    public AudioClip rifleSound;
    // Use this for initialization
    AudioSource fuenteAudio;

    void Start () {
        fuenteAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
