using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public Animator window1;
    public Animator window2;
    public Animator window3;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // �ߺ� ����
        if (!other.CompareTag("Player")) return;

        triggered = true;

        // â������ �������� ������ ����
        if (Random.value > 0.5f)
        {
            window1.SetTrigger("Open");
        }
        if (Random.value > 0.5f)
        {
            window2.SetTrigger("Open");
        }
        if (Random.value > 0.5f)
        {
            window3.SetTrigger("Open");
        }
            Debug.Log("â�� ���� ���� ó�� �Ϸ�!");
    }
}