using System.Reflection;
using UnityEditor;

public static class Example
{
    [MenuItem("Tools/Web")]
    private static void Show()
    {
        var type = typeof(Editor)
            .Assembly
            .GetType("UnityEditor.Web.WebViewEditorWindowTabs")
        ;

        var attr =
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy
        ;

        var methodInfo = type
            .GetMethod("Create", attr)
            .MakeGenericMethod(type)
        ;

        methodInfo.Invoke(null, new object[]
        {
            "Web", // ウィンドウのタイトル
            "https://trello.com/", // URL
            300, // 横幅（最小）
            300, // 縦幅（最小）
            500, // 横幅（最大）
            500 // 縦幅（最大）
        });
    }
}