using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapPlace : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _arRaycastManager;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private ARPlaneManager _arPlaneManager;
    [SerializeField] private UnityEvent OnObjectPlacedEvent;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private bool hasInstantiate;
    
    public void PlaceObject(InputAction.CallbackContext ctx)
    {
        if (ctx.control.device is Pointer device && ctx.started)
        {
            if (hasInstantiate) return; 
            if (_arRaycastManager.Raycast(device.position.ReadValue(), _hits, 
                TrackableType.PlaneWithinPolygon))
            {
                var pose = _hits[0].pose;
                Instantiate(_prefab, pose.position, pose.rotation);;
                hasInstantiate = true;
                OnObjectPlacedEvent?.Invoke();
            }
        }
    }
}
