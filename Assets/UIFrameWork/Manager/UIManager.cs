using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager
{
    //单例模式
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    private Transform canvasTransform;

    private Transform CanvasTransform
    {
        get
        {
            if(canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }

    //存储所有的面板Prefab路径
    private Dictionary<UIPanelType, string> panelPathDict;
    private Dictionary<UIPanelType, string> panelIdDict;
    private Dictionary<UIPanelType, BasePanel> panelDict;
    //解析Json
    private UIManager()
    {
        ParseUIPanelTypeJson();
    }

    public BasePanel GetPanel(UIPanelType panelType)
    {
        if(panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel panel;
        panelDict.TryGetValue(panelType, out panel);//TODO

        if(panel == null)
        {
            string path;
            panelPathDict.TryGetValue(panelType, out path);
            //实例化
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform);//TODO
            panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }
    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }

    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();
        panelIdDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            //Debug.Log(info.panelType + " " + info.Path);
            panelPathDict.Add(info.panelType, info.Path);
            panelIdDict.Add(info.panelType, info.id);
        }
    }

    public void Test()
    {
        string Path;
        string id;
        GameObject Cube;
        //Cube = GameObject.Find("Cube");
        panelPathDict.TryGetValue(UIPanelType.MainMenu, out Path);
        panelIdDict.TryGetValue(UIPanelType.MainMenu, out id);
        Debug.Log(Path);
        Debug.Log(id);
        //foreach (string a in panelIdDict.Values)
        //{
        //    if (a == "1")
        //    {
        //        Cube.gameObject.GetComponent<BoxCollider>().enabled = false;
        //    }
        //}
    }
}