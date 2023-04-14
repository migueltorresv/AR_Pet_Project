using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class Pet : MonoBehaviour
{
    [SerializeField] private GameObject _objectToFollow;
    [SerializeField] private float _minDistanceObjectToStop = 0.2f;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private UnityEvent OnBeginTargetToFollowEvent;
    [SerializeField] private UnityEvent OnTargetPositionArrivedEvent;
    
    private bool eventInvoked;
    private ObjectLauncher objectLauncher;
    

    private void Awake()
    {
        objectLauncher = FindObjectOfType<ObjectLauncher>();
    }

    public void TraslateToPoint(GameObject target)
    {
        _objectToFollow = target;
        StartCoroutine(TraslatePositionRoutine());
    }

    private IEnumerator TraslatePositionRoutine()
    {
        OnBeginTargetToFollowEvent?.Invoke();
        var direction = _objectToFollow.transform.position - transform.position;
        while (direction.magnitude > _minDistanceObjectToStop)
        {
            direction = _objectToFollow.transform.position - transform.position;
            transform.position += direction.normalized * _speed * Time.deltaTime;
            transform.LookAt(_objectToFollow.transform.position);
            yield return null;    
        }
        OnTargetPositionArrivedEvent?.Invoke();
    }


    public void DisableTargetObject()
    {
        _objectToFollow.SetActive(false);
    }

    public void EnableLauncher()
    {
        objectLauncher.CanLaunch = true;
    }
}
