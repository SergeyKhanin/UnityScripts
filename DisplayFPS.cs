using UnityEngine;
using TMPro;

public class DisplayFPS : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _FPSText;
    private float _pollingTime = 1.0f;
    private float _time;
    private float _frameCount;
    
    void Update()
    {
        _time = _time + Time.deltaTime;
        _frameCount++;
        if (_time >= _pollingTime)
        {
            int frameRate = Mathf.RoundToInt(_frameCount / _time);
            _FPSText.text = frameRate.ToString();
            _time = _time - _pollingTime;
            _frameCount = 0.0f;
        }
    }
}