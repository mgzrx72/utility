using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
public class HotKeys : ScriptableObject
{
    private static EditorWindow mouseOverWindow;

    [MenuItem("Edit/Toggle Lock &q")]
    private static void Inspector()
    {
        if (mouseOverWindow == null)
        {
            if (!EditorPrefs.HasKey("LockableInspectorIndex"))
            {
                EditorPrefs.SetInt("LockableInspectorIndex", 0);
            }
            int i = EditorPrefs.GetInt("LockableInspectorIndex");

            var type = Assembly
                .GetAssembly(typeof(Editor))
                .GetType("UnityEditor.InspectorWindow")
            ;

            var list = Resources.FindObjectsOfTypeAll(type);
            mouseOverWindow = list.ElementAtOrDefault(i) as EditorWindow;
        }

        if (mouseOverWindow != null && mouseOverWindow.GetType().Name == "InspectorWindow")
        {
            var type = Assembly
                .GetAssembly(typeof(Editor))
                .GetType("UnityEditor.InspectorWindow")
            ;

            var propertyInfo = type.GetProperty("isLocked");
            var value = (bool)propertyInfo.GetValue(mouseOverWindow, null);
            propertyInfo.SetValue(mouseOverWindow, !value, null);
            mouseOverWindow.Repaint();
        }
    }
    [MenuItem("Edit/Run _F5", priority = 140)]
    private static void Run()
    {
        EditorApplication.isPlaying = true;
    }

    [MenuItem("Edit/Run _F5", validate = true)]
    private static bool CanRun()
    {
        return !EditorApplication.isPlaying;
    }

    [MenuItem("Edit/Stop #_F5", priority = 141)]
    private static void Stop()
    {
        EditorApplication.isPlaying = false;
    }

    [MenuItem("Edit/Stop #_F5", validate = true)]
    private static bool CanStop()
    {
        return EditorApplication.isPlaying;
    }
}
