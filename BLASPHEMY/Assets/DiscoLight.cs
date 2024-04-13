using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLight : MonoBehaviour
{
    private Light _lightComponent; // Renamed from _discoLight
    [SerializeField] private float changeInterval = 0.5f;

    private void Start()
    {
        _lightComponent = GetComponent<Light>(); // Assign the Light component to _lightComponent
        InvokeRepeating(nameof(ChangeLightColor), 0f, changeInterval);
    }

    private void ChangeLightColor()
    {
        if (_lightComponent != null)
        {
            var randomColor = new Color(Random.value, Random.value, Random.value);
            _lightComponent.color = randomColor;
        }
        else
        {
            Debug.LogError("Light component not found!");
        }
    }
}