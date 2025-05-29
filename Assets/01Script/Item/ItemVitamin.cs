using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVitamin : ItemBase
{
    [SerializeField] private ParticleSystem effect;
    public override void Start()
    {
        base.Start();
        SetType(ObjectType.Vitamin);
    }
    protected override void OnEnable()
    {
        base.OnEnable();

        if (effect != null)
        {
            // 파티클 렌더러 강제 활성화
            ParticleSystemRenderer renderer = effect.GetComponent<ParticleSystemRenderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
            }

            // 파티클 클리어 후 재생
            effect.Clear();
            effect.Play();
        }
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        effect.Stop();
    }
    public override void ItemGet()
    {
        SoundManager.instance.PlaySFX(SFX_Type.SFX_Item);
        PlayerController.SetInvincible();
    }
}
