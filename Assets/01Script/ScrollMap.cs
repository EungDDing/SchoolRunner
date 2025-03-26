using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10.0f;
    private float resetZ = 20.0f;
    private Vector3 resetPosition = new Vector3(0.0f, 0.0f, 20.0f);

    private void Update()
    {
        transform.position += -transform.forward * (scrollSpeed * Time.deltaTime);
        Debug.Log(Time.time);
    }
}
