using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectLauncher : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Rigidbody _objectPrefab;
    [SerializeField] private float _initialVelocitySpeed = 10.0f;
    private bool canLaunch;
    private GameObject prefabInstantiated = null;
    public bool CanLaunch
    {
        get => canLaunch;
        set => canLaunch = value;
    }

    public void LaunchObject(InputAction.CallbackContext ctx)
    {
        if (ctx.control.device is Pointer device && ctx.started)
        {
            if (_objectPrefab == null) return;
            if (!CanLaunch) return;
            var ray = _mainCamera.ScreenPointToRay(device.position.ReadValue());
            if (prefabInstantiated == null)
            {
                prefabInstantiated = Instantiate(_objectPrefab, ray.origin, quaternion.identity).gameObject;
                CanLaunch = false;
            }
            else
            {
                prefabInstantiated.SetActive(true);
                prefabInstantiated.transform.position = ray.origin;
                prefabInstantiated.transform.rotation = quaternion.identity;
                CanLaunch = false;
            }
            
            var rb = prefabInstantiated.GetComponent<Rigidbody>();
            rb.velocity = ray.direction * _initialVelocitySpeed;
        }
    }

}
