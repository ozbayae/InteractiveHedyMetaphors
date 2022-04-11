using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WalkToMouseClick : MonoBehaviour
{

    [SerializeField] private GameObject circle;
    private const float Speed = 6;
    private bool _moving = false;
    private void Update()
    {
        //if the left button of is clicked
        if (Input.GetMouseButtonUp(0))
        {
            if (_moving)
                return;
            _moving = true;
            
            Vector3 mousePos = Input.mousePosition;

            mousePos.z = Camera.main.nearClipPlane;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            
            Debug.Log(worldPosition);

            // circle.transform.LeanMove(mousePos, 1);

            var currentPosition = circle.transform.position;

            var distance = Vector2.Distance(worldPosition, currentPosition);

            LeanTween.move(circle, worldPosition, distance / Speed).setOnComplete(x => _moving = false);
        }
    }
}
