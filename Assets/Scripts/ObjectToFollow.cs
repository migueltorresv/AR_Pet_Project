using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObjectToFollow : MonoBehaviour
{
    [SerializeField] private float _delayToBeginFollowThis = 5.0f;
    [SerializeField] private float _heightToCollisionFloor = 1.0f;
    [SerializeField] private LayerMask _floorLayerMask = new LayerMask();
    private Pet pet;
    private ObjectLauncher objectLauncher;

    private void Awake()
    {
        pet = FindObjectOfType<Pet>();
    }

    private IEnumerator FollowTargetRoutine()
    {
        yield return new WaitForSeconds(_delayToBeginFollowThis);
        if (!DetectedCollisionFloor())
        {
            pet.DisableTargetObject();
            pet.EnableLauncher();
            yield break;
        }
        pet.TraslateToPoint(gameObject);
    }

    private bool DetectedCollisionFloor()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        bool hasDetected = false;

        if (Physics.Raycast(ray, out hit, _heightToCollisionFloor))
        {
            int floorLayer = 1 << (LayerMask)hit.transform.gameObject.layer;
            if (floorLayer != _floorLayerMask.value) 
                hasDetected = false;
            hasDetected = true;
        }
        return hasDetected;
    }

    private void OnEnable()
    {
        StartCoroutine(FollowTargetRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
