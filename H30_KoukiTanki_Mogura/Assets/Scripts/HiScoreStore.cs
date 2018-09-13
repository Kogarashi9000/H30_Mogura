using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using UnityEngine;

/// <summary>
/// ハイスコアのファイルの読み込みと書き込み
/// 
/// 作成者:田中颯馬
/// 編集者:田中颯馬
/// 作成日時:2018/9/13
/// </summary>
public sealed class HiScoreStore
{
    private static HiScoreStore hiScoreStore;

    //文章保存
    private string[] hiScoreArray;

    //ハイスコア
    public int HiScore { get; set; }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <returns>このクラスのインスタンス</returns>
    public static HiScoreStore GetInstance()
    {
        if (hiScoreStore == null) hiScoreStore = new HiScoreStore();
        return hiScoreStore;
    }

    /// <summary>
    /// 書き込み用関数
    /// </summary>
    public void WriteFile()
    {
        //セーブ先のファイルパス
        string filepath = Application.dataPath + "/StreamingAssets/HiScore.txt";
        
        hiScoreArray[0] = HiScore.ToString();

        File.WriteAllLines(filepath,hiScoreArray , Encoding.GetEncoding(932));
    }

    /// <summary>
    /// 読み込み用関数
    /// </summary>
    public void ReadFile()
    {
        //AccountSaveを読み込ませる
        string filepath = Application.dataPath + "/StreamingAssets/HiScore.txt";
        if (filepath.Contains("://") || filepath.Contains("://"))
        {
            WWW www = new WWW(filepath);
            //yield return www;
            string hiScoreTxt = www.text;
        }
        else
        {
            //ReadAllLinesで改行ごとに配列の中身を作ってくれる
            hiScoreArray = File.ReadAllLines(filepath, Encoding.GetEncoding(932));

            if (hiScoreArray[0] != null)
            {
                HiScore = int.Parse(hiScoreArray[0]);
            }
        }
    }
}
