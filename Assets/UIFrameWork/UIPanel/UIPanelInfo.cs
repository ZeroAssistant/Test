using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;
    public string PanelTypeString;
    public string Path;
    public string id;

    public void OnAfterDeserialize()
    {
        //Debug.Log(PanelTypeString);
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), PanelTypeString);
        panelType = type;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
