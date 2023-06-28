using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ForwardMover))]
public class AfterFinishSpeedChanger : MonoBehaviour
{
    [SerializeField] private SliderValueChanger _slider;
    [SerializeField] private GameStatesControler _gameControler;

    private ForwardMover _mover;

    private void OnEnable()
    {
        _gameControler.SpeedFinded += OnSpeedFinded;
    }

    private void Start()
    {
        _mover = GetComponent<ForwardMover>();
    }

    private void OnDisable()
    {
        _gameControler.SpeedFinded -= OnSpeedFinded;
    }

    private void OnSpeedFinded()
    {
        float sliderValue = _slider.GetValue();

        float timesSpeed;

        if (sliderValue < 0) sliderValue = - sliderValue;

        timesSpeed = 1.5f - sliderValue;

        _mover.UpSpeed(timesSpeed);
    }
}
