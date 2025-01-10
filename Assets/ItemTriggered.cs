using System;
using UnityEngine;

public class ItemTriggered : MonoBehaviour
{
    Animator _animator;
    [SerializeField] private AnimationClip animationClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        float clipLength = animationClip.length;

        float truc = 1;
        if (truc != 0)
        {
            
        }
        if (truc <= Mathf.Epsilon)
        {
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("IsPifPafPoufed");
    }
}
