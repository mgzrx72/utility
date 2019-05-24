using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputForMobile
{
    /// <summary>
    /// タッチされている数
    /// </summary>
    /// <returns></returns>
    public static int GetTouchCount()
    {
        return Input.touchCount;
    }
    /// <summary>
    /// タッチされているか？
    /// </summary>
    /// <returns></returns>
    public static bool IsTouching()
    {
        if (0 < Input.touchCount)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// タッチの初めの判定
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool IsTouchBigin(int num = 0)
    {
        if (!IsTouching()) return false;

        Touch touch = Input.GetTouch(num);

        if (touch.phase == TouchPhase.Began)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// タッチの移動中
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool IsTouchMoveing(int num = 0)
    {
        if (!IsTouching()) return false;

        Touch touch = Input.GetTouch(num);

        if (touch.phase == TouchPhase.Moved)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// タッチの終了時
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool IsTouchEnd(int num = 0)
    {
        if (!IsTouching()) return false;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Ended)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// タッチの位置の取得
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static Vector2 GetPosition(int num = 0)
    {
        if (!IsTouching()) return new Vector2(0, 0);

        Touch touch = Input.GetTouch(num);

        return touch.position;
    }
    /// <summary>
    /// タッチの移動量
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static Vector2 GetDeltaPosition(int num = 0)
    {
        if (!IsTouching()) return new Vector2(0, 0);

        Touch touch = Input.GetTouch(num);
        Vector2 result = touch.deltaPosition;

        var min = new Vector2(0.01f, 0.01f);

        if (result.x <= min.x && result.y <= min.y)
        {
            result = Vector2.zero;
        }

        return result;
    }
}
