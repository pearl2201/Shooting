using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
[Serializable]
public abstract class AbstractItem : ScriptableObject
{
    public TYPE_ITEM typeItem;
    public int id;
    
    public int cost;
    public string nameItem;

}

