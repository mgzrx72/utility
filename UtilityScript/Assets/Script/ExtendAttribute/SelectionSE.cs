using UnityEngine;
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using System.IO;
#endif
/// <summary>
/// インスペクターからResources/SE内のaudioclipをpopupで選択できる拡張
/// stringのフィールにattribute SelectBGMをつけて使用する
/// /// </summary>
class SelectionSEAttribute : PropertyAttribute { }
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SelectionSEAttribute))]

public class SelectionSE : PropertyDrawer
{
    List<string> list;
    List<string> AllSEName
    {
        get
        {
            List<string> SENames = new List<string>();
             

            foreach (var s in Resources.LoadAll("SE"))
            {
                string n = s.ToString();
                SENames.Add(n.Replace(" (UnityEngine.AudioClip)", ""));
            }
            return SENames;
        }
        //[Resources/SE]フォルダからBGMを探す

    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
         if(list==null)list= AllSEName;
        if (list != AllSEName) list = AllSEName;
        var selectedIndex = list.FindIndex(item => item.Equals(property.stringValue));
        if (selectedIndex == -1)
        {
            selectedIndex = list.FindIndex(item => item.Equals(list[0]));
        }

        selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, list.ToArray());

        property.stringValue = list[selectedIndex];
    }

}

#endif



