using System.Collections;
using UnityEngine;
public class SetActiveByTime : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    [SerializeField] private GameObject[] _setActive;
    private void Awake()
    {
        StartCoroutine(Appearance());
    }
    IEnumerator Appearance()
    {
        yield return new WaitForSeconds(_delayTime);
        for (int i = 0; i < _setActive.Length; i++)
        {
            _setActive[i].SetActive(!_setActive[i].activeSelf); 
        }
    }
}