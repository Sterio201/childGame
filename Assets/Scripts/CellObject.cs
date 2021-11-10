using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCellObject", menuName = "CellData")]
public class CellObject : ScriptableObject
{
    [SerializeField] string _value;
    [SerializeField] Sprite _sprite;

    [HideInInspector]
    public string value => _value;
    [HideInInspector]
    public Sprite sprite => _sprite;
}