using System.Collections;
using UnityEngine;
public class SetActiveByTime : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    [SerializeField] private GameObject _setActive;
    private void Awake()
    {
        StartCoroutine(Appearance());
    }
    IEnumerator Appearance()
    {
        yield return new WaitForSeconds(_delayTime);
        _setActive.SetActive(!_setActive.activeSelf);
    }
}