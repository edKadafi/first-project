using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeleportersConfig", menuName = "TeleportersConfig")]
public class TeleportersConfig : ScriptableObject
{
    [SerializeField] List<GameObject> teleporters;
}
