using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Putter"))
        {
            source.PlayOneShot(source.clip);
        }
    }
}
