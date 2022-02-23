using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueezeEffect : MonoBehaviour
{

    Vector3 posInScreen;
    float pressMax = 1000.0f;
    // Start is called before the first frame update
    void Update(){
        if (Input.GetMouseButton(0)){
            Vector3 _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
            Vector3 _initialPosition = transform.position;
            float distance = Vector3.Distance(_currentPosition, _initialPosition);
            distance = Mathf.Min(pressMax, distance)/2000;
            transform.localScale -= new Vector3(0,distance,0);
        }
    }
     public Vector3? GetCurrentMousePosition()
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
