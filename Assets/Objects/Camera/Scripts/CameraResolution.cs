using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private float _startAspect = 1080f / 1920f;

    private float _defaultHeight;
    private float _defaultWidth;

    private void Start()
    {
        _defaultHeight = Camera.main.orthographicSize;
        _defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    private void Awake()
    {
        _defaultHeight = Camera.main.orthographicSize;
        _defaultWidth = Camera.main.orthographicSize * _startAspect;

        Camera.main.orthographicSize = _defaultWidth / Camera.main.aspect;
    }

    private void Update()
    {
        Camera.main.orthographicSize = _defaultWidth / Camera.main.aspect;
    }
}