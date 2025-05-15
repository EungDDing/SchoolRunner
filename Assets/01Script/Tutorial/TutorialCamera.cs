using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 targetPos;
    private bool isStart = true;

    private void Update()
    {
        if (isStart)
        {
            targetPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, 1.0f);
        }
    }
}
