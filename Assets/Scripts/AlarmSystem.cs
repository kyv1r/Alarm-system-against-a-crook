using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _speedChangeVolume;

    private Coroutine _volumeCoroutine;

    public void TurnOff()
    {
        SetVolume(_minVolume, true);
    }

    public void TurnOn()
    {
        SetVolume(_maxVolume, false);
    }

    private void SetVolume(float targetVolume, bool isMinValue)
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        if (isMinValue == false && _alarm.isPlaying == false)
            _alarm.Play();

        _volumeCoroutine = StartCoroutine(ChangeVolume(targetVolume, isMinValue));
    }

    private IEnumerator ChangeVolume(float targetVolume, bool isMinVolume)
    {
        while (Mathf.Approximately(_alarm.volume, targetVolume) == false)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _speedChangeVolume * Time.deltaTime);
            yield return null;
        }

        if (isMinVolume && Mathf.Approximately(_alarm.volume, _minVolume))
            _alarm.Stop();

        _volumeCoroutine = null;
    }
}
