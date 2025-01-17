using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.position.x / 10, target.position.y / 10, -10);
    }
}
