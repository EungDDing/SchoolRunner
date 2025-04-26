using UnityEngine;

public class BookDrop : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 5f;

    public void Drop()
    {
        rb.isKinematic = false;

        // �̲������� ����
        Vector3 forceDir = transform.forward * forwardForce + Vector3.down * 1f;
        rb.AddForce(forceDir, ForceMode.Impulse);

        // ȸ�� ���� (����)
        rb.AddTorque(new Vector3(10f, 0f, 5f), ForceMode.Impulse);
    }
}