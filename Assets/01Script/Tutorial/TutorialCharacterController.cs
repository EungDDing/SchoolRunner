using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCharacterController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        if(TryGetComponent<Animator>(out animator))
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        
    }
}
