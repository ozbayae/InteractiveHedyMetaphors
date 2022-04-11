using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(TryToInvokeInteractableEnabledAction());
    }
    
    IEnumerator TryToInvokeInteractableEnabledAction()
    {
        while (Actions.InteractableEnabled == null)
        {
            yield return new WaitForSeconds(.1f);
        }
        Actions.InteractableEnabled.Invoke(transform);
    }

    private void OnDisable()
    {
        Actions.InteractableDisabled?.Invoke(transform);
    }
}
