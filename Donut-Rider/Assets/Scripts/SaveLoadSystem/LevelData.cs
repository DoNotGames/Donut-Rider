using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData : MonoBehaviour
{
    public string levelName;
    public bool isUnlocked;
    public float time;
    public int health;
}
