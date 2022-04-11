using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCircle : Interactable, IInteractable
{

    public static Action OnClickCircleSummonsBanana;
    
    public void OnClickAction()
    {
        OnClickCircleSummonsBanana?.Invoke();
    }
}
