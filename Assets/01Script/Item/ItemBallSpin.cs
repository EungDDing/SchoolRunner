using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBallSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed = 360.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
