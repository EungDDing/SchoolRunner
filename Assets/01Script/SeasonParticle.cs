using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particles;

    private PlayerController playerController;
    private GameObject obj;
    private int index;
    private void Awake()
    {
        obj = GameObject.FindWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);

        playerController.OnChangeCharacter += ChangeParticle;
    }
    private void Start()
    {
        particles[0].Play();
    }
    private void OnDisable()
    {
        playerController.OnChangeCharacter -= ChangeParticle;
    }
    private void ChangeParticle()
    {
        particles[index].Stop();
        index++;
        particles[index].Play();
    }
}
