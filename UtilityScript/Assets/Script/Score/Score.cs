using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 中野 
/// スコアUIは別クラスで行う
/// </summary>
public static class Score
{
    private static int score;//スコアの変数
                              
    /// <summary>
    /// スコア加算のメソッド
    /// </summary>
    /// <param name="addPoint"></param>
    public static void AddScore(int addPoint) => score += addPoint;
   
    /// <summary>
    /// スコアをゲットする
    /// </summary>
    /// <returns></returns>
    public static int GetScore=>score;
    /// <summary>
    /// スコア減らす
    /// </summary>
    /// <param name="reducePoint"></param>
    public static void Reduce(int reducePoint) => score -= reducePoint;
    /// <summary>
    /// スコアをリセットする
    /// </summary>
    public static void ScoreReset()=> score = 0;
    



}
