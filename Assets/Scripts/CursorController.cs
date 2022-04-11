using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private Camera _mainCamera;
    
    private CursorControls _cursorControls;
    
    [SerializeField] private InteractablesManager interactablesManager;

    [SerializeField] private Texture2D interactiveCursorTexture;

    private Cursor _interactiveCursor;

    [SerializeField]
    private Transform newSelectionTransform;
    private Transform _currentSelectionTransform;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;
    private bool _cursorIsInteractive = false;

    public float DistanceThreshold;

    private void Awake()
    {
        _mainCamera = Camera.main;
        
        _cursorControls = new CursorControls();
        _cursorControls.Mouse.Click.started += _ => StartedClick();
        _cursorControls.Mouse.Click.performed += _ => EndedClick();
        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;
    }
    

    private void OnEnable()
    {
        _cursorControls.Enable();
    }

    private void OnDisable()
    {
        _cursorControls.Disable();
    }
    
    void Update()
    {
        FindInteractableWithinDistanceThreshold();
    }

    private void FindInteractableWithinDistanceThreshold()
    {
        newSelectionTransform = null;

        foreach (var interactable in interactablesManager.Interactables)
        {
            Vector3 fromMouseToInteractableOffset =
                _mainCamera.WorldToScreenPoint(interactable.position) - new Vector3(
                    _cursorControls.Mouse.Position.ReadValue<Vector2>().x,
                    _cursorControls.Mouse.Position.ReadValue<Vector2>().y,
                    0f);
            float sqrMag = fromMouseToInteractableOffset.sqrMagnitude;
            if (sqrMag < DistanceThreshold * DistanceThreshold)
            {
                newSelectionTransform = interactable.transform;

                if (_cursorIsInteractive == false)
                {
                    InteractiveCursorTexture();
                }
                break;
            }
        }
        if (_currentSelectionTransform != newSelectionTransform)
        {
            _currentSelectionTransform = newSelectionTransform;
            DefaultCursorTexture();
        }
    }

    private void DefaultCursorTexture()
    {
        _cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }

    private void InteractiveCursorTexture()
    {
        _cursorIsInteractive = true;
        Vector2 hotspot = new Vector2(
            interactiveCursorTexture.width / 2, 0);
        Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto);
    }

    private void StartedClick()
    {
        
    }

    private void EndedClick()
    {
        OnClickInteractable();
    }

    private void OnClickInteractable()
    {
        if (newSelectionTransform != null)
        {
            IInteractable interactable =
                newSelectionTransform.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnClickAction();
            }
            newSelectionTransform = null;
        }
    }
}
