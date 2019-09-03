using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleStart : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnLocation;
    public GameObject gameStartUIText;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<VRGrab>().holdingPutter)
        {
            if (!GameManager.instance.gameStarted)
            {
                GameManager.instance.StartGame();
                gameStartUIText.SetActive(false);
            }
            other.transform.parent.SetPositionAndRotation(new Vector3(ballSpawnLocation.position.x - 0.5f, other.transform.parent.position.y, ballSpawnLocation.position.z), transform.rotation);
            GameObject ballClone = Instantiate(ballPrefab, ballSpawnLocation);
            ballClone.transform.SetParent(null);
            source.PlayOneShot(source.clip);
        }
    }
}