using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform eventTargetPos;
    [SerializeField] private AnimationCurve curve;
    private float duration = 2.0f;

    private Vector3 targetPos;
    private bool isStart = false;

    private void Awake()
    {
        Camera.main.fieldOfView = 55.0f;
    }
    private void Update()
    {
        if (isStart)
        {
            targetPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, 1.0f);
        }
    }
    public void StartCameraMove()
    {
        StartCoroutine(EventCameraMove());
    }
    private IEnumerator EventCameraMove()
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        Vector3 endPos = eventTargetPos.position;
        Quaternion endRot = eventTargetPos.rotation;

        float startFOV = Camera.main.fieldOfView;
        float endFOV = 65.0f;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.position = Vector3.Lerp(startPos, endPos, curve.Evaluate(t));
            transform.rotation = Quaternion.Lerp(startRot, endRot, curve.Evaluate(t));

            Camera.main.fieldOfView = Mathf.Lerp(startFOV, endFOV, curve.Evaluate(t));

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        transform.rotation = endRot;
        Camera.main.fieldOfView = endFOV;

        isStart = true;
    }
}
