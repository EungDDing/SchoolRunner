using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPosition : MonoBehaviour
{
    public delegate void EnterStopPosition();
    public static EnterStopPosition OnEnterStopPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnterStopPosition?.Invoke();
            GetComponent<Collider>().enabled = false;
        }
    }
}
