using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class DataAchivement : ScriptableObject
{
    [SerializeField]
    private List<Achivement> achivement;

    public Achivement GetDataAchivement(TYPE_ACHIVEMENT type)
    {
        return achivement[(int) type];
    }
}

