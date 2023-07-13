using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PetAnimations : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private UnityEvent OnLiftObjectTakeAnimEvent;
    [SerializeField] private UnityEvent OnLiftAnimFinishedEvent;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetTrueBoolParam(string nameParam)
    {
        _animator.SetBool(nameParam, true);
    }
    
    public void SetFalseBoolParam(string nameParam)
    {
        _animator.SetBool(nameParam, false);
    }

    public void AnimationLiftObjectTook()
    {
        OnLiftObjectTakeAnimEvent?.Invoke();
    }

    public void AnimationLiftFinished()
    {
        OnLiftAnimFinishedEvent?.Invoke();
    }

    public void SetTriggerParam(string nameParam)
    {
        _animator.SetTrigger(nameParam);
    }
}
