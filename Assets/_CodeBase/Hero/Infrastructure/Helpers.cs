using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _CodeBase.Hero.Infrastructure
{
  public static class Helpers
  {
    public static bool IsPointOverUIObject(Vector2 point) 
    {
      PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
      eventDataCurrentPosition.position = point;
      List<RaycastResult> results = new List<RaycastResult>();
      EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
      return results.Count > 0;
    }
    
    public static Vector3 MultiplyVectors(Vector3 vector1, Vector3 vector2) => 
      new Vector3(vector1.x * vector2.x, vector1.y * vector2.y, vector1.z * vector2.z);
		
    public static Vector3 DivideVectors(Vector3 vector1, Vector3 vector2) => 
      new Vector3(vector1.x / vector2.x, vector1.y / vector2.y, vector1.z / vector2.z);
  }
}