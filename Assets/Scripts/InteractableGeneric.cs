using System;

public class InteractableGeneric : Interactable, IInteractable
{

    public static Action OnClick;
    
    public void OnClickAction()
    {
        OnClick?.Invoke();
    }
}