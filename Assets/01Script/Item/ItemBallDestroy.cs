using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBallDestroy : MonoBehaviour
{
    [SerializeField] private ParticleSystem shootEffect;
    [SerializeField] private ParticleSystem collisiontEffect;

    private void Awake()
    {
        shootEffect.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            StartCoroutine(DestroyBall());
        }
    }
    private IEnumerator DestroyBall()
    {
        if (shootEffect != null)
        {
            shootEffect.Stop();
        }

        ParticleSystem newEffect = Instantiate(collisiontEffect, transform.position, Quaternion.identity);
        newEffect.Play();

        Destroy(newEffect.gameObject, newEffect.main.duration + newEffect.main.startLifetime.constant);

        yield return null;
        Destroy(gameObject);
    }
}
