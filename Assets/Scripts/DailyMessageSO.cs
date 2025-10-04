using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DailyMessageSO", order = 1)]
public class DailyMessageSO : ScriptableObject
{
    public List<string> messages;
}
