using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _speedChangeVolume;

    private Coroutine _volumeCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
        {
            if (_volumeCoroutine != null)
                StopCoroutine(_volumeCoroutine);

            _alarm.Play();
            _volumeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
        {
            if (_volumeCoroutine != null)
                StopCoroutine(_volumeCoroutine);

            _volumeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (Mathf.Approximately(_alarm.volume, targetVolume) == false)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _speedChangeVolume * Time.deltaTime);
            yield return null;
        }

        if (Mathf.Approximately(_alarm.volume, _minVolume))
            _alarm.Stop();

        _volumeCoroutine = null;
    }
}
