using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public Animator window1;
    public Animator window2;
    public Animator window3;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // 중복 방지
        if (!other.CompareTag("Player")) return;

        triggered = true;

        // 창문마다 랜덤으로 열릴지 결정
        if (Random.value > 0.5f)
        {
            window1.SetTrigger("open");
        }
        if (Random.value > 0.5f)
        {
            window2.SetTrigger("open");
        }
        if (Random.value > 0.5f)
        {
            window3.SetTrigger("open");
        }
            Debug.Log("창문 랜덤 열림 처리 완료!");
    }
}