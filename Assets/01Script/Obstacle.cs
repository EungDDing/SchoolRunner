using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float flyForce;
    private PlayerController playerController;
    private Vector3 flyDir = new Vector3(-1.0f, 1.0f, 0.0f);
    private Rigidbody rig;

    private int damage = 1;
    private void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);

        gameObject.TryGetComponent<Rigidbody>(out rig);
        scrollSpeed = 10.0f;
        flyForce = 7.0f;
    }
    
    private void Update()
    {
        Scroll();
    }
    // interface
    public void Scroll()
    {
        transform.position += -transform.forward * (scrollSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.TakeDamage(damage);
            rig.AddForce(flyDir * flyForce, ForceMode.Impulse);
        }
    }
}
