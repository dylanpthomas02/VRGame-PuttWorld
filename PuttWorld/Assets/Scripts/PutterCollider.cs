using UnityEngine;

public class PutterCollider : MonoBehaviour
{
    [SerializeField]
    private PutterColliderFollower _putterFollowerPrefab;

    private void SpawnPutterColliderFollowers()
    {
        var follower = Instantiate(_putterFollowerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }

    private void Start()
    {
        SpawnPutterColliderFollowers();
    }
}