using System.Collections;
using UnityEngine;

namespace _CodeBase.Logic
{
  public class Chaser : MonoBehaviour
  {
    private Coroutine _chaseCoroutine;

    public void Chase(Transform target, float speed) => 
      _chaseCoroutine = StartCoroutine(ChaseCoroutine(target, speed));

    public void StopChasing()
    {
      if(_chaseCoroutine == null) return;
      StopCoroutine(_chaseCoroutine);
    }

    private IEnumerator ChaseCoroutine(Transform target, float speed)
    {
      while (true)
      {
        Vector3 direction = Vector3.Normalize(target.position - transform.position);
        transform.position += direction * speed * Time.deltaTime;
        yield return null;
      }
    }
  }
}