﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{

    // 時間
    public float timeCount = 0;
    float hintSETTime = 0;
    // テキスト内容
    string hintText;
    // 表示フラグ
    bool isHideFlg = false;
    // テキストを変えるオブジェクト
    public Text textObject;
    // 生成するオブジェスト
    public GameObject hintPanel;
    [SerializeField]
    public List<GameObject> hintObjects = new List<GameObject>();
    // 表示中のオブジェクトを確認する
    public bool isActiveHint = false;
    // 要素数が多くなった場合の処理
    bool isListOver = false;

    // テスト作成用
    public bool isCreate = false;
    int createCount = 0;

    public enum State
    {
        Parent,
        Child,
    }
    public State HintState;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (HintState)
        {
            case State.Parent:
                {
                    // デバッグ用の処理*************************************************
                    //if (Input.GetKeyDown(KeyCode.A)){
                    //    isCreate = true;
                    //}
                    //if (isCreate)
                    //{
                    //    HintParent("テスト", 2);
                    //    isCreate = false;
                    //}

                    break;
                }
            case State.Child:
                {

                    if (isHideFlg)
                    {
                        GetComponent<Animator>().SetBool("HintFlg", true);
                        timeCount += Time.deltaTime;

                        if (hintSETTime < timeCount)
                        {
                            isHideFlg = false;
                            GetComponent<Animator>().SetBool("HintFlg", false);
                            //if (transform.parent.GetComponent<HintManager>().hintObjects.Contains(transform.gameObject))
                            //{
                            //    transform.parent.GetComponent<HintManager>().hintObjects.Remove(transform.gameObject);
                            //}
                        }
                    }
                    else
                    {
                        timeCount = 0;
                    }
                    break;
                }
        }

    }

    // テキストの内容を変更し、表示時間を指定する
    public void HintParent(string hintNaiyou, float hintTime)
    {
        isActiveHint = false;
        // オブジェクトを生成
        GameObject createHint = Instantiate(hintPanel);
        createHint.SetActive(true);
        createHint.transform.parent = transform;
        createHint.transform.localPosition = Vector3.zero;
        createHint.GetComponent<HintManager>().Hint(hintNaiyou, hintTime);

        //// 順番の要素が空なら入れる
        //if (hintObjects[createCount] == null)
        //{
        //    createHint.transform.localPosition = new Vector3(
        //                  0,
        //                  createCount * (-100),
        //                 0);
        //    hintObjects[createCount] = createHint;
        //    createCount++;
        //}
        //// 要素があるのなら空のものを探す
        //else
        //{
        int num = 0;
        while (!isActiveHint)
        {
            // 空の要素があった
            if (hintObjects[num] == null)
            {
                // 位置を調整
                createHint.transform.localPosition = new Vector3(
                   0,
                   num * (-100),
                  0);
                hintObjects[num] = createHint;
                createCount = 0;
                isActiveHint = true;
            }
            // 空の要素がなかった
            else
            {
                num++;
                // 空の要素が無かったら入れ替える
                if (num > hintObjects.Count - 1)
                {
                    createHint.transform.localPosition = new Vector3(
                         0,
                         createCount * (-100),
                        0);
                    hintObjects[createCount] = createHint;
                    createCount++;
                    isActiveHint = true;
                }
            }
        }
        // }

        if (createCount == 3)
        {
            createCount = 0;
        }
    }
    public void Hint(string hintNaiyou, float hintTime)
    {
        // アニメーションを起動
        isHideFlg = true;
        textObject.text = "" + hintNaiyou;
        hintSETTime = hintTime;
    }

    public void ObjectDes()
    {
        Destroy(transform.gameObject);
    }
}