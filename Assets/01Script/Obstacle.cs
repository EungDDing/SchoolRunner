using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed;
    private PlayerController playerController;
    private int damage = 1;
    private void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
        scrollSpeed = 10.0f;
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
        }
    }
}
