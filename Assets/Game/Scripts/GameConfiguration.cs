﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Runner/GameConfiguration", order = 1)]
public class GameConfiguration : ScriptableObject
{
    public float speed;
    public float minRangeObstacleGenerator;
    public float maxRangeObstacleGenerator;
}
