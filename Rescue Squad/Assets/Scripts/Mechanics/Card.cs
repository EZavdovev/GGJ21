using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;

public class Card : MonoBehaviour
{

    [SerializeField]
    private OperativeSO _thisOperative;

    public OperativeSO ThisOperative
    {
        get { return _thisOperative; }
        set { _thisOperative = value; }
    }

}
