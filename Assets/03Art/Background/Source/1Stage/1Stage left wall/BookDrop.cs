using UnityEngine;

public class BookDrop : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 5f;

    public void Drop()
    {
        rb.isKinematic = false;

        // 미끄러지며 낙하
        Vector3 forceDir = transform.forward * forwardForce + Vector3.down * 1f;
        rb.AddForce(forceDir, ForceMode.Impulse);

        // 회전 연출 (선택)
        rb.AddTorque(new Vector3(10f, 0f, 5f), ForceMode.Impulse);
    }
}