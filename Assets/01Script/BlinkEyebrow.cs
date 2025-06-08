using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEyebrow : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMesh;
    private int blinkBlendShapeIndex = 0;
    private float blinkDuration = 0.5f;

    [SerializeField] private Animator animator;
    private string layerName = "Base Layer";
    private string animationName = "Idle";

    private void Start()
    {
        StartCoroutine(BlinkCycle());
    }
    private IEnumerator BlinkCycle()
    {
        while (true)
        {
            yield return StartCoroutine(BlinkRoutine());
            yield return StartCoroutine(BlinkRoutine());

            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex(layerName));
            float clipLength = stateInfo.length;
            float progress = stateInfo.normalizedTime % 1f;
            float remaining = clipLength * (1f - progress);

            yield return new WaitForSeconds(remaining);
        }
    }
    private IEnumerator BlinkRoutine()
    {

        yield return new WaitForSeconds(1.0f);

        float t = 0f;
        while (t < blinkDuration)
        {
            float weight = Mathf.Lerp(0f, 100f, t / blinkDuration);
            skinnedMesh.SetBlendShapeWeight(blinkBlendShapeIndex, weight);
            t += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.7f);

        t = 0f;
        while (t < blinkDuration)
        {
            float weight = Mathf.Lerp(100f, 0f, t / blinkDuration);
            skinnedMesh.SetBlendShapeWeight(blinkBlendShapeIndex, weight);
            t += Time.deltaTime;
            yield return null;
        }

        skinnedMesh.SetBlendShapeWeight(blinkBlendShapeIndex, 0f);
    }

}
