using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlayStart : Interactable, IInteractable
{
    public static Action OnClickPlayStartsGame;
    public void OnClickAction()
    {
        OnClickPlayStartsGame?.Invoke();
    }
}