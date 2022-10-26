﻿using UnityEngine;

namespace _CodeBase.EnemyCode.Data
{
  [CreateAssetMenu(fileName = "SpawnerSettings", menuName = "Settings/Spawner")]
  public class SpawnerSettings : ScriptableObject
  {
    public float StartDelay;
    public float MinDelay;
    public float MinDelayApplyTime;
    public int FliersPerBoss;
  }
}