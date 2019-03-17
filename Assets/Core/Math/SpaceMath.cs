using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMath
{
    public class Math
    {
        public static Vector3 PositionRelativeToRadius(Vector3 OriginalPosition, Vector3 CameraPosition, float RadiusFromCamera)
        {
            Vector3 p = OriginalPosition - CameraPosition;
            float pLenght = Mathf.Sqrt(p.x * p.x + p.y * p.y + p.z * p.z);
            Vector3 q = (RadiusFromCamera / Mathf.Abs(pLenght)) * p;
            Vector3 pointOnSphere = q + CameraPosition;
            return pointOnSphere;
        }
        public static Vector3 PositionRelativeToRadius(Vector3 OriginalPosition, Vector3 CameraPosition, float RadiusFromCamera, float fieldOfView, Vector3 OriginalSize, out Vector3 localScale)
        {
            Vector3 p = OriginalPosition - CameraPosition;
            float pLenght = Mathf.Sqrt(p.x * p.x + p.y * p.y + p.z * p.z);
            Vector3 q = (RadiusFromCamera / Mathf.Abs(pLenght)) * p;
            Vector3 pointOnSphere = q + CameraPosition;
            localScale = OriginalSize * fieldOfView / Vector3.Distance(OriginalPosition, CameraPosition);
            return pointOnSphere;
        }
    }
}
