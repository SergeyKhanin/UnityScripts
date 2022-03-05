using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class FlashLight : MonoBehaviour
{
    [Header("Light Settings")]
    [SerializeField] private Light _lightSourse;
    private bool _lightControl;
    private bool _lightDelay;
    private float _currentTime;

    [Header("Switcher Settings")]
    [SerializeField] private GameObject _switcherObject;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _moveStep;
    
    [Header("Audio Settings")]
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    
    [Header("Material Settings")]
    [SerializeField] MeshRenderer _meshLight;
    [SerializeField] private Material _lightMaterialOn;
    private Material _lightMaterialOff;

    [Header("Control Settings")]
    [SerializeField] private KeyCode _key;
    [SerializeField] private float _delayTime;

    void Start()
    {
        _lightControl = false;
        _lightDelay = false;
        _audioSource = GetComponent<AudioSource>();
        _lightMaterialOff = _meshLight.GetComponent<MeshRenderer>().material;
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
    }
    void FlashlightOn()
    {
        _lightSourse.enabled = true;
        _switcherObject.transform.Translate(_moveDirection * _moveStep);
        _meshLight.material = _lightMaterialOn;
    }
    void FlashlightOff()
    {
        _lightSourse.enabled = false;
        _switcherObject.transform.Translate(_moveDirection * -_moveStep);
        _meshLight.material = _lightMaterialOff;
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
    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = _audioClip;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1.0f;
    }
}