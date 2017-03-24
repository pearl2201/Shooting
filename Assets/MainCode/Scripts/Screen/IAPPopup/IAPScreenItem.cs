using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class IAPScreenItem : MonoBehaviour
{
    public TYPE_IAP type;
    public bool isEnablePurchase;
    public DescriptionIAP decs;
    public void Setup()
    {
        
    }

    public void Click()
    {
        iapManager.DisplayInfoItem(this);
    }

    public IAPScreenManager iapManager;
}


public class DescriptionIAP
{
    public string name;
    public string description;
    public string costDecs;


    public DescriptionIAP(string name, string description, string costDecs)
    {
        this.name = name;
        this.description = description;
        this.costDecs = costDecs;

    }
}