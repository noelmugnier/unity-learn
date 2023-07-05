using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private KeyCode changeViewKey = KeyCode.C;
    private Camera[] _cameras;
    private int _currentCameraIndex = 0;
    private bool _canChangeCamera = true;

    void Start()
    {
        _cameras = GetComponentsInChildren<Camera>(includeInactive:true);
    }

    void Update()
    {
        if (Input.GetKey(changeViewKey) && _canChangeCamera)
            SwitchToNextCamera();
    }

    private void SwitchToNextCamera()
    {
        if (_canChangeCamera)
            _canChangeCamera = false;
        
        _cameras[_currentCameraIndex].enabled = false;
        
        if (_cameras.Length <= _currentCameraIndex + 1)
            _currentCameraIndex = 0;
        else
            _currentCameraIndex++;

        _cameras[_currentCameraIndex].enabled = true;
        
        Invoke(nameof(CanChangeCamera), 0.1f);
    }

    private void CanChangeCamera()
    {
        _canChangeCamera = true;
    }
}
