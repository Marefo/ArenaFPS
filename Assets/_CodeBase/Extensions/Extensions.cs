using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SystemRandom = System.Random;

namespace _CodeBase.Extensions
{
  public static class Extensions
  {
    private static readonly SystemRandom rng = new SystemRandom(); 
    
    public static float MoveToZero(this float startValue, float value)
    {
      float sign = Mathf.Sign(startValue);
      return startValue + (sign == 1 ? -1 : 1) * value;
    }

    public static T GetRandomValue<T>(this List<T> list) => list[Random.Range(0, list.Count)];
		
    public static List<T> Shuffle<T>(this List<T> list)
    {
      List<T> result = new List<T>(list);
      int n = result.Count;  
      while (n > 1) {  
        n--;  
        int k = rng.Next(n + 1);
        (result[k], result[n]) = (result[n], result[k]);
      }
      return result;
    }
		
    public static bool AddIfNotExists<T>(this List<T> list, T value)
    {
      if (list.Contains(value)) return false;
			
      list.Add(value);
      return true;
    }
    
    
    public static void EnableEmission(this ParticleSystem particles)
    {
      var particlesEmission = particles.emission;
      particlesEmission.enabled = true;
    }
		
    public static void DisableEmission(this ParticleSystem particles)
    {
      var particlesEmission = particles.emission;
      particlesEmission.enabled = false;
    }
    
    public static int GetSignForInterpolation(this float currentValue, float targetValue) => 
      targetValue > currentValue ? 1 : -1;
    
    public static Vector3 GetNavMeshSampledPosition(this Vector3 position)
    {
      NavMesh.SamplePosition(position, out NavMeshHit hit, float.MaxValue, NavMesh.AllAreas);
      return hit.position;
    }
  }
}