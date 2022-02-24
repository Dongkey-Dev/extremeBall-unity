using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMoudle{
    public class pm : MonoBehaviour
    {
        public static Vector3? GetCurrentMousePosition()
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
        public static float AngleInRad(Vector3 vec1, Vector3 vec2) {
            return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
        }
        public static float AngleInDeg(Vector3 vec1, Vector3 vec2) {
            return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
        }    
    }
}