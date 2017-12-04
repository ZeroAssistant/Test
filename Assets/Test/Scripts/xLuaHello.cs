using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
using System;

[LuaCallCSharp]
enum EnemyType
{
    Normal,
    Hard,
    NB
}

public class xLuaHello : MonoBehaviour
{

    //通过xLua插件运行lua程序
 //   private LuaEnv luaenv;

	//// Use this for initialization
	//void Start ()
 //   {
 //       luaenv = new LuaEnv();

 //       //luaenv.DoString("print('Hello World!')");
 //       luaenv.DoString("CS.UnityEngine.Debug.Log('Hello world')");

 //       //luaenv.Dispose();
	//}
	
	//private void OnDestroy()
 //   {
 //       luaenv.Dispose();
 //   }
    
    //通过内置loader加载lua源文件
    //void Start()
    //{
    //    //TextAsset ta = Resources.Load<TextAsset>("helloworld.lua");

    //    LuaEnv env = new LuaEnv();
    //    //env.DoString(ta.text);

    //    env.DoString("require 'helloworld'");
    //    env.Dispose();
    //}

    //通过自定义Loader加载指定目录访问lua
    //void Start()
    //{
    //    LuaEnv env = new LuaEnv();

    //    env.AddLoader(MyLoader);

    //    env.DoString("require 'test'");

    //    env.Dispose();
    //}

    //private byte[] MyLoader(ref string filePath)
    //{
    //    //print(filePath);
    //    //string s = "print(123)";
    //    print(Application.streamingAssetsPath);

    //    string absPath = Application.streamingAssetsPath + "/" + filePath + ".lua.txt";
    //    return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    //}

    ////通过C#访问lua
    //void Start()
    //{
    //    LuaEnv luaenv = new LuaEnv();

    //    luaenv.DoString("require 'CSharpCallLua'");

    //    //Person p = luaenv.Global.Get<Person>("person");

    //    //print(p.name + " " + p.age);

    //    //通过class
    //    //int a = luaenv.Global.Get<Person>("a");
    //    //print(a);
    //    //string str = luaenv.Global.Get<string>("str");
    //    //print(str);
    //    //bool isDie = luaenv.Global.Get<bool>("isDie");
    //    //print(isDie);

    //    //通过interface
    //    //IPerson p = luaenv.Global.Get<IPerson>("person");
    //    //print(p.name+"-"+p.age);
    //    //p.name = "Sikiedu.com";
    //    //luaenv.DoString("print(person.name)");
    //    //p.eat(1,2);

    //    //通过Dictionary、List
    //    //Dictionary<string, object> dict = luaenv.Global.Get<Dictionary<string, object>>("person");
    //    //foreach(string key in dict.Keys)
    //    //{
    //    //    print(key + "-" + dict[key]);
    //    //}

    //    //List<object> list = luaenv.Global.Get<List<object>>("person");
    //    //foreach (object o in list)
    //    //{
    //    //    print(o);
    //    //}

    //    //通过LuaTable
    //    //LuaTable tab = luaenv.Global.Get<LuaTable>("person");
    //    //print(tab.Get<string>("name"));
    //    //print(tab.Get<int>("age"));
    //    //print(tab.Length);

    //    //访问Lua中的全局函数
    //    //Action<int,int> act1 = luaenv.Global.Get<Action<int,int>>("add");
    //    //act1(30,70);
    //    //act1 = null;

    //    //1.映射到delegate
    //    //Add add = luaenv.Global.Get<Add>("add");
    //    //int resa = 0,resb = 0;
    //    //int res = add(30, 70,out resa,out resb);
    //    //print(res);
    //    //print(resa);
    //    //print(resb);
    //    //add = null;

    //    //2.映射到luafunction
    //    LuaFunction func = luaenv.Global.Get<LuaFunction>("add");
    //    object[] os = func.Call(1,2);
    //    foreach(object o in os)
    //    {
    //        print(o);
    //    }

    //    luaenv.Dispose();
    //}

    //Lua与c#交互
    void Start()
    {
        LuaEnv luaenv = new LuaEnv();

        luaenv.DoString("require 'LuaCallCSharp'");

        luaenv.Dispose();
    }

    //[CSharpCallLua]
    //delegate int Add(int a, int b, out int resa, out int resb);

    class Person
    {
        public string name;
        public int age;
        public int age2;
    }

    [CSharpCallLua]
    interface IPerson
    {
        string name { get; set; }
        int age { get; set; }
        void eat(int a,int b);//在lua里需要多一个变量arg，但在c#里可以不用
    }
}
