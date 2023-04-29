using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    int maxHitPoints = 100;

    float transformationTimer = 60f;
    float defaultTransformationTimer = 60f;

    public delegate void HitPointsChangeDelegate();
    public event HitPointsChangeDelegate hitPointsChange;

    //we can make this 0.5f for turtle
    float damageReduction = 0f;

    //change when hit checkpoint
    Vector2 respawnCoordinates;
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
    
    
    public int MaxHitPoints { get => maxHitPoints; set => maxHitPoints = value; }
    // Start is called before the first frame update
    void Start()
    {
        hitPointsChange();
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
}
