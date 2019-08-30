using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnLocation;

    bool gameStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gameStarted && other.gameObject.GetComponent<VRGrab>().holdingPutter)
        {
            other.transform.parent.SetPositionAndRotation(new Vector3(ballSpawnLocation.position.x, other.transform.parent.position.y, ballSpawnLocation.position.z - 1f), ballSpawnLocation.rotation);
            Instantiate(ballPrefab, ballSpawnLocation);
            gameStarted = true;
        }
    }
}