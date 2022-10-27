using UnityEngine;

namespace _CodeBase.Services
{
  public class TimeService : MonoBehaviour
  {
    public void Stop() => SetTimeScale(0);
    public void Normalize() => SetTimeScale(1);

    private void SetTimeScale(float value)
    {
      Time.timeScale = value;
      Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
  }
}