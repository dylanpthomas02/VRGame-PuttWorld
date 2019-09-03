using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Putter"))
        {
            source.PlayOneShot(source.clip);
            ScoreManager.instance.IncrementStrokes();
            new WaitForSeconds(1f);
        }
    }
}
