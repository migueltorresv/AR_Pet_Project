using UnityEngine;
using UnityEngine.InputSystem;

public class TouchVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject _visualizerImage;
    
    public void ShowVisualizerScreen(InputAction.CallbackContext ctx)
    {
        if (ctx.control.device is Pointer device && ctx.started)
        {
            _visualizerImage.SetActive(true);
            _visualizerImage.transform.position = device.position.ReadValue();
        }
    }
}
