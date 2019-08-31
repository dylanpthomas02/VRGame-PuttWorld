using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnLocation;
    public GameObject gameStartUIText;

    AudioSource source;
    bool gameStarted = false;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gameStarted && other.gameObject.GetComponent<VRGrab>().holdingPutter)
        {
            other.transform.parent.SetPositionAndRotation(new Vector3(ballSpawnLocation.position.x - 0.5f, other.transform.parent.position.y, ballSpawnLocation.position.z), ballSpawnLocation.rotation);
            GameObject ballClone = Instantiate(ballPrefab, ballSpawnLocation);
            ballClone.transform.SetParent(null);
            gameStarted = true;
            source.PlayOneShot(source.clip);
            gameStartUIText.SetActive(false);
        }
    }
}