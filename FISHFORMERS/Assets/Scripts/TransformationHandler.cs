using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationHandler : MonoBehaviour
{
    bool canTransformNow = false;
    public bool CanTransformNow { get => canTransformNow; set => canTransformNow = value; }

    bool transformOneEnabled = false;
    bool transformTwoEnabled = false;
    bool transformThreeEnabled = false;
    [SerializeField] GameObject smallCollider;
    [SerializeField] GameObject largeCollider;
    [SerializeField] GameObject midCollider;
    [SerializeField] GameObject defaultCollider;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;
    [SerializeField] int[] rbMasses = new int[4];
    public bool TransformOneEnabled { get => transformOneEnabled; set => transformOneEnabled = value; }
    public bool TransformTwoEnabled { get => transformTwoEnabled; set => transformTwoEnabled = value; }
    public bool TransformThreeEnabled { get => transformThreeEnabled; set => transformThreeEnabled = value; }
    Rigidbody2D rb2D;
    public delegate void TransformationStartedDelegate();
    public event TransformationStartedDelegate TransformationStarted;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void TransformCharacter(int transformNumber)
    {
        if (transformNumber == 0)
        {
            Debug.Log("buradayým");
            capsuleCollider.size = defaultCollider.GetComponent<CapsuleCollider2D>().size;
        }
        else if (transformNumber == 1)
        {
            capsuleCollider.size = smallCollider.GetComponent<CapsuleCollider2D>().size;
            TransformationStarted();
        }
        else if (transformNumber == 2)
        {
            capsuleCollider.size = midCollider.GetComponent<CapsuleCollider2D>().size;
            TransformationStarted();
        }
        else if (transformNumber == 3)
        {
            capsuleCollider.size = largeCollider.GetComponent<CapsuleCollider2D>().size;
            TransformationStarted();
        }
        else
        {
            Debug.Log("invalid transformation value passed by transformer");
        }
        spriteRenderer.sprite = spriteRenderer.gameObject.GetComponent<CharacterSprites>().sprites[transformNumber];
        rb2D.mass = rbMasses[transformNumber];
    }
}
