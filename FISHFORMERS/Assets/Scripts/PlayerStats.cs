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
    PlayerController controller;

    int transformationTimer = 10;
    int defaultTransformationTimer = 10;

    public delegate void HitPointsChangeDelegate();
    public event HitPointsChangeDelegate hitPointsChange;
    public delegate void TimerChangeDelegate();
    public event TimerChangeDelegate timerChange;

    int damageReduction = 1;
    float speed = 10f;
    bool inTransformation = false;
    public int DamageReduction { get=>damageReduction; set=>damageReduction=value; }
    public float Speed { get => speed; 
        set 
        { 
            speed = value;
            controller.moveSpeed = Speed;
        }
    }
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
        controller = GetComponent<PlayerController>();
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
        if (GetComponent<Rigidbody2D>().mass != 2)
            StopAllCoroutines();
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
                StopCoroutine(transformationCoroutine);
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
        controller.moveSpeed = Speed;

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
