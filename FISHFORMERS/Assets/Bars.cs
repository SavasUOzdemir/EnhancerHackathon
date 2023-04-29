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
    }
    private void OnDisable()
    {
        stats.hitPointsChange-= UpdateHitPointBar;
    }

    void UpdateHitPointBar()
    {
        hitPointsSlider.value = 100* stats.HitPoints / stats.MaxHitPoints;
        Debug.Log(hitPointsSlider.value);
    }
}
