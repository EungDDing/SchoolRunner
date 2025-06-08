using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoors());
        }
    }

    private IEnumerator OpenDoors()
    {
        Quaternion leftStart = leftDoor.rotation;
        Quaternion rightStart = rightDoor.rotation;

        float duration = 1.0f;
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            leftDoor.rotation = Quaternion.Lerp(leftStart, Quaternion.Euler(0f, -85f, 0f), t);
            rightDoor.rotation = Quaternion.Lerp(rightStart, Quaternion.Euler(0f, 85f, 0f), t);

            time += Time.deltaTime;
            yield return null;
        }
    }
}
