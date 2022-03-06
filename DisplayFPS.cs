using System.Collections;
using TMPro;
using UnityEngine;

public class DisplayFPS : MonoBehaviour
{
    [Header("FPS range")]
    [SerializeField] private float _goodFPSThreshold = 60;
    [SerializeField] private float _badFPSThreshold = 30;
    
    [Header("FPS polling time")]
    [SerializeField] private float _updateInterval = 1.0f;
    
    [Header("FPS color settings")]
    [SerializeField] private Color _goodFPSColor = Color.green;
    [SerializeField] private Color _badFPSColor = Color.red;
    [SerializeField] private Color _neutralFPSColor = Color.yellow;
    
    private TextMeshProUGUI _textOutput;
    private float _deltaTime = 0.0f;
    private int _framesPerSecond = 0;

    private void Awake()
    {
        _textOutput = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        StartCoroutine(ShowFPS());
    }
    private void Update()
    {
        CalculateFPS();
    }
    private void CalculateFPS()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
        _framesPerSecond = (int)(1.0f / _deltaTime);
    }
    private IEnumerator ShowFPS()
    {
        while (true)
        {
            if (_framesPerSecond >= _goodFPSThreshold)
            {
                _textOutput.color = _goodFPSColor;
            }
            else if (_framesPerSecond >= _badFPSThreshold)
            {
                _textOutput.color = _neutralFPSColor;
            }
            else
            {
                _textOutput.color = _badFPSColor;
            }
            _textOutput.text = "FPS:" + _framesPerSecond;
            yield return new WaitForSeconds(_updateInterval);
        }
    }
}