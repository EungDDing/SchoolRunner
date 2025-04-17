using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed = 0.0f;
    [SerializeField] private float flyForce;

    private PlayerController playerController;
    private Vector3 flyDir = new Vector3(-1.0f, 1.0f, 0.0f);
    private Rigidbody rig;

    private int damage = 1;
    private bool isScroll = false;
    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);

        gameObject.TryGetComponent<Rigidbody>(out rig);
        flyForce = 7.0f;
    }
    private void OnEnable()
    {
        SetEnableScroll(true);
        SetScrollSpeed(20.0f);
    }
    private void Update()
    {
        if (isScroll)
        {
            Scroll();
        }
    }
    // interface
    public void Scroll()
    {
        transform.position += Vector3.back * (scrollSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.TakeDamage(damage);
            rig.AddForce(flyDir * flyForce, ForceMode.Impulse);
        }
    }

    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }

    public void SetEnableScroll(bool isEnable)
    {
        isScroll = isEnable;
    }
}
