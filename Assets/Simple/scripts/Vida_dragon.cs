using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida_dragon : MonoBehaviour
{

    public AudioClip gunSound;
    public AudioClip rifleSound;
    AudioSource fuenteAudio;
    // Use this for initialization
    public const int maxHealt = 100;
    public int currentHealth = maxHealt;
    public RectTransform healhbar;

    public void TakeDamage(int amount)
    {
        fuenteAudio = GetComponent<AudioSource>();
        fuenteAudio.clip = gunSound;
        fuenteAudio.Play();
        currentHealth -= amount;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead");
            SceneManager.LoadScene("End_winner");
        }
        healhbar.sizeDelta = new Vector2(currentHealth * 2, healhbar.sizeDelta.y);
    }
}
