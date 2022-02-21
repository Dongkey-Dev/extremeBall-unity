using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineToMouse : MonoBehaviour
{
     private LineRenderer _lineRenderer;
     public Color c1 = Color.white;
     public Color c2 = new Color(1, 1, 1, 0.9f);
     public void Start()
     {
         _lineRenderer = gameObject.AddComponent<LineRenderer>();
         _lineRenderer.startWidth = 0.4f;
         _lineRenderer.endWidth = 0.2f;
         _lineRenderer.material.color = Color.white;
         _lineRenderer.startColor = c1;
         _lineRenderer.endColor = c2;
         _lineRenderer.enabled = false;
     }
 
     private Vector3 _initialPosition;
     private Vector3 _currentPosition;
     private Vector3 posInScreen;
     public void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
            _initialPosition = transform.position;
            _lineRenderer.SetPosition(0, _initialPosition);
            _lineRenderer.positionCount = 1;
            _lineRenderer.enabled = true;
         } 
         else if (Input.GetMouseButton(0))
         {
            _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
            _initialPosition = transform.position;
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, _initialPosition);
            _lineRenderer.SetPosition(1, _currentPosition);
 
         } 
         else if (Input.GetMouseButtonUp(0))
         {
             _lineRenderer.enabled = false;
         }
     }
     private Vector3? GetCurrentMousePosition()
     {
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         var plane = new Plane(Vector3.forward, Vector3.zero);
 
         float rayDistance;
         if (plane.Raycast(ray, out rayDistance))
         {
             return ray.GetPoint(rayDistance);
             
         }
         return null;
     }
 }
