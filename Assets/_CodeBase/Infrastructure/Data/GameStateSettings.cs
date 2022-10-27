using UnityEngine;

namespace _CodeBase.Infrastructure.Data
{
  [CreateAssetMenu(fileName = "GameStateSettings", menuName = "Settings/GameState")]
  public class GameStateSettings : ScriptableObject
  {
    public float FinishScreenShowDelay;
  }
}