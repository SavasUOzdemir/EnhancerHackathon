using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowItem : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public Transform followTarget;
    [SerializeField] Vector2 offset;
    Camera cam;
    TransformationHandler handler;
    [SerializeField]Button[] buttons;

    private void Awake()
    {
        handler = FindObjectOfType<TransformationHandler>(includeInactive:true);
    }
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            Vector2 pos = cam.WorldToScreenPoint(followTarget.position + new Vector3(offset.x, offset.y, 0));
            if (transform.position != new Vector3(pos.x, pos.y))
                transform.position = pos;
        }
    }
    private void OnEnable()
    {
        if (handler.TransformOneEnabled)
            buttons[0].interactable = true;
        if (handler.TransformTwoEnabled)
            buttons[1].interactable = true;
        if (handler.TransformThreeEnabled)
            buttons[2].interactable = true;
    }

    public void BecomeSmol()
    {
        handler.gameObject.SendMessage("TransformCharacter", 1);
    }
    public void BecomeMid()
    {
        handler.gameObject.SendMessage("TransformCharacter", 2);

    }
    public void BecomeLarc()
    {
        handler.gameObject.SendMessage("TransformCharacter", 3);

    }
}
