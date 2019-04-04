using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "JPT/Data/Profile")]
public class ProfileData : ScriptableObject
{
    public List<string> OpenedLevels;
}
