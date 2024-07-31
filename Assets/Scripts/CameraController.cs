using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(-20, 20, -20);

    private void Start()
    {
        transform.rotation = Quaternion.Euler(35.26f, 45f, 0);
    }

    void LateUpdate()
    {
        Vector3 target = new Vector3(player.position.x, 0, player.position.z) + offset;
        transform.position = target;
    }
}
