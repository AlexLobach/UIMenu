using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public abstract class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image targetGraphic;

    protected Action onClick;

    private Vector2 startScale;
    public float animationModificator = 1.1f;

    void OnEnable()
    {
        targetGraphic = GetComponent<Image>();
        startScale = transform.localScale;
    }

    public void AddListener(Action onClick)
    {
        this.onClick = onClick;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //todo add Animation here

        transform.localScale *= animationModificator;

        onClick?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = startScale;
    }
}
