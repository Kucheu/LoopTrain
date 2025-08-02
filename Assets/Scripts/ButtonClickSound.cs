using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField]
    private AudioSource buttonClickSource;
    [SerializeField]
    private AudioSource buttonHoverSource;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonHoverSource.Play();
    }

    public void OnPointerEnter(PointerEventData ped)
    {
        buttonClickSource.Play();
    }
}
