# セットアップ方法
## Unityのインストール
## WebGLへビルド,Netlifyへ公開

1. <https://github.com/igakilab/team_Jiwa>にアクセスする。
    ![1](https://user-images.githubusercontent.com/89173987/143882988-5f77cfe6-e1e7-47b6-9f5e-97c3a5739f8e.jpg)
2. codeのDownload Zipをクリックして、ダウロードする。
    ![2](https://user-images.githubusercontent.com/89173987/143883411-5340cf86-c192-43d0-8833-d3152f409ac3.jpg)
4. ダウンロードしたzipファイルを解凍する。
6. unityを開く。
    ![3](https://user-images.githubusercontent.com/89173987/143883416-797452c3-e598-4131-a9c6-9d5af36e4e45.jpg)
8. リストに追加で、４で解凍したファイルから、RoguLikeActionRPGを追加する。
    ![4](https://user-images.githubusercontent.com/89173987/143883422-a0f66b2a-9e57-4025-94c0-6204e0e11671.jpg)
10. プロジェクト名にRoguLikeActionRPGが追加されたのを確認して開く。
    ![5](https://user-images.githubusercontent.com/89173987/143883424-385b7fd5-5700-4066-b688-cdaffb3ab0b1.jpg)
12. FileからBuild Settingsを開き、Web GLを選択し、Build And Runをクリックする。
    ![6](https://user-images.githubusercontent.com/89173987/143883425-b7b0e493-9bcd-456f-ba2d-4044182f120f.jpg)
    ![7](https://user-images.githubusercontent.com/89173987/143883427-dc29ce1b-f9b4-44a9-80e0-385c21728727.jpg)
    ![8](https://user-images.githubusercontent.com/89173987/143883431-dea2ea43-5e65-4421-ac2e-faffac6d2949.jpg)
14. ゲームを置く場所を指定するウィンドウが開くので、なるべくunityとは離れた場所(ディレクトリまたはフォルダ)に指定する。
    ※指定する場所のパスに全角が入ってないものを選ぶ。
9. Buildしたフォルダ内に3つのファイルが入っていることを確認する。
    ![9](https://user-images.githubusercontent.com/89173987/143883435-82965483-4442-45ea-85dc-a1e9a4426501.jpg)
11. githubに適当にリポジトリを作る。
    ![10](https://user-images.githubusercontent.com/89173987/143883439-e9f5b86b-1562-4437-bbb4-1ad08eeb31dd.jpg)
    ![11](https://user-images.githubusercontent.com/89173987/143883659-b49efc69-59b3-4ab7-9f95-b0a7026b86b8.jpg)
13. リポジトリでAdd fileのUpload filesをクリックし、先ほどの3つのファイルをドラッグ&ドロップし、コミットする。
    (Desktop.data.unitywebはデータ容量が大きくgithubにアップロードできないため、Onedrive上に置く)
13. githubを閉じる。
14. ブラウザでNetlifyを開く。
    ![12](https://user-images.githubusercontent.com/89173987/143883662-54a127a3-7be4-4289-a476-5822a1aed616.jpg)
16. ログイン画面が出るので、githubアカウントでログインする。
18. New site from Gitをクリックし、GitHubを選択する。
    ![13](https://user-images.githubusercontent.com/89173987/143883688-a70301d5-13d8-41ea-8b24-2a6aeed00cd1.jpg)
    ![14](https://user-images.githubusercontent.com/89173987/143883693-967cd8d0-1f8b-4433-801b-fa113489242e.jpg)
20. Buildしたファイルが入ったリポジトリを選択する。
    ![15](https://user-images.githubusercontent.com/89173987/143883698-b98ccf14-3b9e-4232-88f4-e083890ccc45.jpg)
22. Deploy siteをクリックする。
23. サイトが作成されたことを確認し、そのURLにアクセスするとゲームができる。
    ![17](https://user-images.githubusercontent.com/89173987/143883709-604fc08d-5c67-4cef-a4d7-80e203e81f25.jpg)
    ![title](https://user-images.githubusercontent.com/89173987/143883724-bc29719b-df47-4ba0-92d4-7ecaa548351f.jpg)

# ユーザマニュアル

## ルール

* 襲い掛かってくるモンスターを薙ぎ払うゲームです。
* ステージは３つあります。制限時間はステージ１から順に60秒、90秒、120秒となりプレイヤーはそのうちの１つを選んでプレイします。
* モンスターを倒すと経験値・スコアが獲得でき、加えてかなりの低確率で回復アイテムをドロップします。
* プレイヤーは初期状態で回復アイテムを１つ所持しています。回復アイテムを所持している状態で回復ボタンを押すとプレイヤーのHPを回復します。
* 回復アイテムは同時に最大１つまで所持できます。
* 経験値を1定値獲得すると、最大HP、攻撃力、防御力のうちいずれか一つが上昇します。
* プレイヤーの攻撃は低確率でクリティカルヒットします。クリティカルヒットした場合、敵に与えるダメージが増加します。
* モンスターから攻撃を受けてHPが０になった場合、ゲームオーバーとなります。
* 制限時間終了時にプレイヤーが生き残っていればゲームクリアとなります。

## 操作方法


### キーボードでの操作方法


* A,Dキーもしくは矢印の左右キー：移動
* 移動中にShiftキー：向いてる方向へダッシュ
* Vキーもしくは左クリック：攻撃
* SPACEキー：ジャンプ
* 回復アイテムがある状態でBキー：体力を回復(アイテムは消費されます)


### Xboxコントローラーでの操作方法


* 左スティック：移動(押し込みでダッシュ)
* Xボタン：攻撃
* Aボタン：ジャンプ
* 回復アイテムがある状態でBボタン：体力を回復(アイテムは消費されます)
