using UnityEngine;
using UnityEngine.InputSystem;

public class TouchVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject _visualizerImage;
    [SerializeField] private float _limitBottomScreen = 300;
    
    public void ShowVisualizerScreen(InputAction.CallbackContext ctx)
    {
        if (ctx.control.device is Pointer device && ctx.started)
        {
            if (device.position.ReadValue().y <= _limitBottomScreen) return;
            _visualizerImage.SetActive(true);
            _visualizerImage.transform.position = device.position.ReadValue();
        }
    }
}
