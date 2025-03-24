using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 targetPos;
    private void Update()
    {
        targetPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 1.0f);
    }
}
