﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHoukoku_Ctrl_08 : MonoBehaviour
{

    public GameCtrl_PanelChange GP;
    public PanelCrossChan_Ctrl PCC;
    public GameCtrl_ClearCheck_08 GCC;
    public GameObject ButtonSeikai;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if (GCC.get_clearflg() == true)
        {
            ButtonSeikai.SetActive(true);
        }
    }

    public void GameGamenhe_Button()
    {
        //GP.change_panel (GameCtrl_PanelChange.panel.Game);
        this.gameObject.SetActive(false);
    }

    public void huseikai()
    {
        string daimei, section, syousai;

        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);

        daimei = "残念だったね。。";
        section = "・次回からはこんな観点で挑戦してね！";
        syousai = "欲しいキャラが出なかった時に、「今のガチャの結果なかったことに出来ないかな？」と思わずしちゃいそうな操作を考えてみてね！";
        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game, "リトライ");
    }

    public void seikai()
    {
        string daimei, section, syousai;

        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);
        daimei = "クリアおめでとう～♪";
        section = "　・今回の不具合は";
        syousai = "ガチャをひいて、結果がわかった後にサスペンド / レジューム(サスレジ)すると、コインが減ってない状態でまたガチャがひけてしまうバグだよ！\n"
                    + "本番のQAではコインだけ減ってキャラを取得できないといったこともないか確認してね！\n"
                    + "サスレジ以外にネットワーク切断やブラウザバック等で問題発生することもあるから注意だよ！";
        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

        /* セレクト画面でClear表示 */
        PlayerPrefs.SetInt("ClearStat8", 1);
    }
}
