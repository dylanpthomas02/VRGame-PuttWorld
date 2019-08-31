using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextHole : MonoBehaviour
{
    public GameObject explosionPrefab;
    AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            source.PlayOneShot(source.clip);
            GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(clone, 1f);
        }
    }
}
