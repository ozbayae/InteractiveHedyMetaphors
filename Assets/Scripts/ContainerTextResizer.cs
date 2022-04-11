using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class ContainerTextResizer : MonoBehaviour
{
    [SerializeField] private string text;
    private void OnValidate()
    {
        var textSize = gameObject.GetComponent<TMP_Text>().GetPreferredValues(text);
        gameObject.GetComponent<TMP_Text>().text = text;
        gameObject.GetComponent<RectTransform>().sizeDelta = textSize;
    }
}