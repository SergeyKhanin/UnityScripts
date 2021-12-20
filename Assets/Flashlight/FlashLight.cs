using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [Header("Light Settings")]
    [SerializeField] private Light _light;
    [SerializeField] private AnimationCurve _intensity;
    private bool _lightControl;
    private bool _lightDelay;
    private float _currentTime;

    [Header("Switcher Settings")]
    [SerializeField] private GameObject _switcher;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _moveStep;
    [SerializeField] private AudioSource _audioSource;

    [Header("Glass Settings")]
    [SerializeField] private GameObject _glass;
    [SerializeField] private Material _lightOn;
    [SerializeField] private Material _lightOff;

    [Header("Control Settings")]
    [SerializeField] private KeyCode _key;
    [SerializeField] private float _delayTime;

    void Start()
    {
        //_source.enabled = false;
        _lightControl = false;
        _lightDelay = false;
        _light.intensity = 0.0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            if (_lightControl == false && _lightDelay == false)
            {
                _lightControl = true;
                _lightDelay = true;
                FlashlightOn();
                PlaySound();
                StartCoroutine(Delay());
            }
            if (_lightControl == true && _lightDelay == false)
            {
                _lightControl = false;
                _lightDelay = true;
                FlashlightOff();
                PlaySound();
                StartCoroutine(Delay());
            }
        }
        if (_lightControl == true)
        {
            _light.intensity = _intensity.Evaluate(_currentTime);
            _currentTime = _currentTime + Time.deltaTime;
        }
    }
    void FlashlightOn()
    {
        //_source.enabled = true;
        _switcher.transform.Translate(_moveDirection * _moveStep);
        _glass.GetComponent<MeshRenderer>().material = _lightOn;
    }
    void FlashlightOff()
    {
        //_source.enabled = false;
        _light.intensity = 0.0f;
        _switcher.transform.Translate(_moveDirection * -_moveStep);
        _glass.GetComponent<MeshRenderer>().material = _lightOff;
    }
    void PlaySound()
    {
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.Play();
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delayTime);
        _lightDelay = false;
    }
}
