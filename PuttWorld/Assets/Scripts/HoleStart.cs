using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleStart : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<VRGrab>().holdingPutter)
        {
            if (!gameStarted)
            {
                GameManager.instance.StartGame();
                gameStartUIText.SetActive(false);
                gameStarted = true;
            }
            other.transform.parent.SetPositionAndRotation(new Vector3(ballSpawnLocation.position.x - 0.5f, other.transform.parent.position.y, ballSpawnLocation.position.z), ballSpawnLocation.rotation);
            GameObject ballClone = Instantiate(ballPrefab, ballSpawnLocation);
            ballClone.transform.SetParent(null);
            source.PlayOneShot(source.clip);
        }
    }
}