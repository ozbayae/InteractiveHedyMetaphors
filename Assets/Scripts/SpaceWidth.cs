using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class SpaceWidth : MonoBehaviour
{
    private string _space = " ";
    
    private void Reset()
    {
        var textComponent = gameObject.GetComponent<TMP_Text>();
        textComponent.text = _space;
        var spaceSize = textComponent.GetRenderedValues(false);
        gameObject.GetComponent<RectTransform>().sizeDelta = spaceSize;
    }
}
