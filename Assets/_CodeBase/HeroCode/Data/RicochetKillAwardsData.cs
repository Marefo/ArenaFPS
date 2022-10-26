using System.Collections.Generic;
using _CodeBase.Extensions;
using UnityEngine;

namespace _CodeBase.HeroCode.Data
{
  [CreateAssetMenu(fileName = "RicochetKillAwardsData", menuName = "StaticData/RicochetKillAwards")]
  public class RicochetKillAwardsData : ScriptableObject
  {
    public List<RicochetKillAward> Data;

    public RicochetKillAward GetRandomAward() => Data.GetRandomValue();
  }
}