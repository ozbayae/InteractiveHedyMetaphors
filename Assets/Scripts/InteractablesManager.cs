using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField] private List<Transform> interactables;

    public List<Transform> Interactables
    {
        get => interactables;
    }

    private Camera _mainCamera;

    private void AddToListOfInteractables(Transform transformToAddToList)
    {
        interactables.Add(transformToAddToList);
    }

    private void RemoveFromListOfInteractables(Transform transformToRemoveFromList)
    {
        interactables.Remove(transformToRemoveFromList);
    }

    private void Awake()
    {
        Actions.InteractableEnabled += AddToListOfInteractables;
        Actions.InteractableDisabled += RemoveFromListOfInteractables;
    }
    void Start()
    {
        // _mainCamera = Camera.main;
        //
        // AllChildrenWorldToScreenPoint();
    }

    // //Translate world position so it corresponds to position on screen
    // private void AllChildrenWorldToScreenPoint()
    // {
    //     for (int i = 0; i < this.transform.childCount; i++)
    //     {
    //         transform.GetChild(i).position =
    //             _mainCamera.WorldToScreenPoint(transform.GetChild(i).position);
    //
    //         transform.GetChild(i).localScale = Vector3.one * 100;
    //     }
    // }

}
