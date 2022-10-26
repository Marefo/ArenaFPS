using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _CodeBase.EnemyCode.Data
{
  [CreateAssetMenu(fileName = "EnemiesData", menuName = "StaticData/Enemies")]
  public class EnemiesData : ScriptableObject
  {
    public List<EnemyData> Data;

    public GameObject GetPrefab(EnemyType type) => 
      Data.First(other => other.Type == type).Prefab;

    public int GetEnergyAward(EnemyType type) => 
      Data.First(other => other.Type == type).EnergyAward;
  }

  [Serializable]
  public class EnemyData
  {
    public EnemyType Type;
    public int EnergyAward;
    [Space(10)]
    public GameObject Prefab;
  }
}