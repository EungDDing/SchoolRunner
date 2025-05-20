using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObstacle : MonoBehaviour
{
    private float flyForce;
    private PlayerController playerController;
    private Rigidbody rig;
    private Vector3 flyDir = new Vector3(-1.0f, 1.0f, 0.0f);
    private int damage = 1;

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);

        gameObject.TryGetComponent<Rigidbody>(out rig);
        flyForce = 14.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            playerController.TakeDamage(damage);
            rig.AddForce(flyDir * flyForce, ForceMode.Impulse);
            StartCoroutine(DestroyObstacle());
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            rig.AddForce(flyDir * flyForce, ForceMode.Impulse);
            StartCoroutine(DestroyObstacle());
        }
    }
    public IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
