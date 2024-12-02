using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action Detected;
    public event Action UnDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out Crook crook))
            Detected?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out Crook crook))
            UnDetected?.Invoke();
    }
}
