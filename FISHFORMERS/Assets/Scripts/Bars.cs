using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    PlayerStats stats;
    [SerializeField] Slider hitPointsSlider;
    [SerializeField] Slider transformationSlider;

    private void Awake()
    {
        stats = FindObjectOfType<PlayerStats>();
    }
    private void OnEnable()
    {
        stats.hitPointsChange += UpdateHitPointBar;
        stats.timerChange += UpdateTimer;
    }
    private void OnDisable()
    {
        stats.hitPointsChange -= UpdateHitPointBar;
        stats.timerChange -= UpdateTimer;
    }

    void UpdateHitPointBar()
    {
        hitPointsSlider.value = 100 * stats.HitPoints / stats.MaxHitPoints;
    }
    void UpdateTimer()
    {
        transformationSlider.value = 100 * stats.TransformationTimer / stats.MaxTransformationTimer;
    }
}
