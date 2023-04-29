using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    int maxHitPoints = 100;
    TransformationHandler handler;
    Coroutine transformationCoroutine;

    int transformationTimer = 60;
    int defaultTransformationTimer = 60;

    public delegate void HitPointsChangeDelegate();
    public event HitPointsChangeDelegate hitPointsChange;
    public delegate void TimerChangeDelegate();
    public event TimerChangeDelegate timerChange;

    //we can make this 0.5f for turtle
    float damageReduction = 0f;
    bool inTransformation = false;
    public bool InTransformation
    {
        get => inTransformation;
        private set
        {
            inTransformation = value;
            if (!value)
                transformationTimer = defaultTransformationTimer;
        }
    }
    //change when hit checkpoint
    [SerializeField] Vector2 respawnCoordinates;

    private void Awake()
    {
        handler = GetComponent<TransformationHandler>();
    }

    public Vector2 RespawnCoordinates { get => respawnCoordinates; set => respawnCoordinates = value; }
    public int HitPoints
    {
        get => hitPoints;
        set
        {
            hitPoints = value;
            if (hitPoints > maxHitPoints)
                hitPoints = maxHitPoints;
            if (hitPointsChange != null)
                hitPointsChange();
            if (hitPoints <= 0)
                Death();
        }
    }
    public int TransformationTimer { get=>transformationTimer;}
    public int MaxTransformationTimer { get => defaultTransformationTimer; }
    void OnTransformationStarted()
    {
        if (transformationCoroutine != null)
        { 
            StopCoroutine(transformationCoroutine); 
            InTransformation = false;
        }
        inTransformation = true;
        transformationCoroutine = StartCoroutine(TransformationCountDown());
    }
    IEnumerator TransformationCountDown()
    {
        while (inTransformation)
        {
            yield return new WaitForSeconds(1);
            yield return transformationTimer--;
            timerChange();
            if (transformationTimer <= 0)
            {
                handler.gameObject.SendMessage("TransformCharacter",Int32.Parse("0"));
                InTransformation = false;
                yield break;
            }
        }
    }
    public int MaxHitPoints { get => maxHitPoints; set => maxHitPoints = value; }
    // Start is called before the first frame update
    void Start()
    {
        hitPointsChange();
        RespawnCoordinates = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        transform.position = new Vector2(respawnCoordinates.x, respawnCoordinates.y);
        HitPoints = maxHitPoints;
    }
    private void OnEnable()
    {
        handler.TransformationStarted += OnTransformationStarted;
    }
    private void OnDisable()
    {
        handler.TransformationStarted -= OnTransformationStarted;
    }
}
