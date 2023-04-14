using UnityEngine;
using UnityEngine.InputSystem;

public class TextDebug : MonoBehaviour
{
    [SerializeField] private float _gameSpeed = 1.0f;
    public void ShowText(string text)
    {
        Debug.LogWarning(text);
    }

    public void ShowPostion(InputAction.CallbackContext context)
    {
        if (context.control.device is Pointer device && context.started)
        {
            Debug.LogWarning($"position: {device.position.ReadValue()}");
        }
    }
    
#if UNITY_EDITOR
    private void Update()
    {
        Time.timeScale = _gameSpeed;
    }
#endif
}
