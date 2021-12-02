# セットアップ方法
## Unityのインストール
1. [UnityHub](<https://unity3d.com/jp/get-unity/download>)をインストール。
<img width="550" alt="スクリーンショット 2021-12-02 113859" src="https://user-images.githubusercontent.com/72001573/144347599-1c0f6b01-6f05-4900-91ee-c7bcec353a68.png">

2. [こちら](https://unity3d.com/unity/qa/lts-releases)のサイトからver 2020.3.18f1を探しUnityHub経由でインストールを行う。
<img width="854" alt="スクリーンショット 2021-12-02 115606" src="https://user-images.githubusercontent.com/72001573/144349414-1586b399-2a6b-4e56-b7d8-97aff0649e73.png">

3. WebGLを選択してインストール。
<img width="416" alt="スクリーンショット 2021-12-02 114304" src="https://user-images.githubusercontent.com/72001573/144347975-084af527-495d-4e0b-abbf-8dc72299f73b.png">

## WebGLへビルド,Netlifyへ公開

1. <https://github.com/igakilab/team_Jiwa>にアクセスする。
    ![1](https://user-images.githubusercontent.com/89173987/144359948-e1fcb97a-e4fd-4e38-a578-78aba5934832.jpg)
2. codeのDownload Zipをクリックして、ダウンロードする。
    ![2](https://user-images.githubusercontent.com/89173987/144359950-f7e4b9dd-083f-4a0e-8369-c844a9e055f1.jpg)
3. ダウンロードしたzipファイルを解凍する。
4. unityを開く。
    ![3](https://user-images.githubusercontent.com/89173987/144359951-792736f4-fdf6-40fa-a351-c95f471f750b.jpg)
5. リストに追加で、４で解凍したファイルから、RoguLikeActionRPGを追加する。
    ![4](https://user-images.githubusercontent.com/89173987/144359953-5ba05862-2fea-4671-9b7e-7acca425d065.jpg)
6. プロジェクト名にRoguLikeActionRPGが追加されたのを確認して開く。
    ![5](https://user-images.githubusercontent.com/89173987/144359954-4c09a0cd-d7e8-4099-b2f7-0a4f07c5cfbe.jpg)


7. FileからBuild Settingsを開き、Web GLを選択する。
    ![6](https://user-images.githubusercontent.com/89173987/144360641-61015cc2-9bf0-4e4d-bcd9-4dfbf9f9117b.jpg)
    ![7](https://user-images.githubusercontent.com/89173987/144360646-42c94374-b882-4a23-8fbe-7033ff691a98.jpg)

8. PlayerSetting -> Publish Settings　に進み
    Compression Formatを**Broti**に、**Decompression Fallback**にチェックを入れる
    ![スクリーンショット 2021-12-02 151401](https://user-images.githubusercontent.com/72001573/144367958-8b2b40c7-4e1d-4267-b9d6-a09dda153270.png)
8. Build And Runをクリック
    ![8](https://user-images.githubusercontent.com/89173987/144360647-62ce80f5-60df-4f65-a979-404b514960b6.jpg)

8. ゲームを置く場所を指定するウィンドウが開くので、なるべくunityとは離れた場所(ディレクトリまたはフォルダ)に指定する。
    ※指定する場所のパスに全角が入ってないものを選ぶ。
9. Buildしたフォルダ内に3つのファイルが入っていることを確認する。
    ![9](https://user-images.githubusercontent.com/89173987/144360082-62c99b6e-eefa-4c40-95d7-cbb0585c9c60.jpg)
10. githubに適当にリポジトリを作る。
    ![10](https://user-images.githubusercontent.com/89173987/144360087-603c2ece-8cbf-4947-88cb-b7d510df4c9e.jpg)

11. 先程作成したリポジトリにBuildした３つのファイルを追加し、コミットする。（方法は問いません。Gitクライアントを用いることをおすすめします。）    
    ![スクリーンショット 2021-12-02 150056](https://user-images.githubusercontent.com/72001573/144366583-8766c7f7-941f-404d-8b99-f183997adbb9.png)
12. githubを閉じる。
13. ブラウザでNetlifyを開く。
14. ログイン画面が出るので、githubアカウントでログインする。
    ![12](https://user-images.githubusercontent.com/89173987/144360090-3b2e276f-e6f7-4beb-86ff-e267fbc4c8d1.jpg)
15. New site from Gitをクリックし、GitHubを選択する。
    ![13](https://user-images.githubusercontent.com/89173987/144360097-f31301ab-2229-4900-852a-263cf5a74c75.jpg)
    ![14](https://user-images.githubusercontent.com/89173987/144360101-0d8048ea-278e-4c2d-bf17-5bff347de95d.jpg)
16. Buildしたファイルが入ったリポジトリを選択する。
    ![15](https://user-images.githubusercontent.com/89173987/144360104-9e3d1768-3976-45aa-9342-3a75c15e7779.jpg)
17. Deploy siteをクリックする。
18. サイトが作成されたことを確認し、そのURLにアクセスするとゲームができる。
    ![17](https://user-images.githubusercontent.com/89173987/144360108-439a59f0-5bd4-440e-94cb-27d7038f619b.jpg)
    ![title](https://user-images.githubusercontent.com/89173987/143883724-bc29719b-df47-4ba0-92d4-7ecaa548351f.jpg)

# ユーザマニュアル

## ルール

* 襲い掛かってくるモンスターを薙ぎ払うゲームです。
* ステージは３つあります。制限時間はステージ１から順に60秒、90秒、120秒となりプレイヤーはそのうちの１つを選んでプレイします。
* モンスターを倒すと経験値・スコアが獲得でき、加えてかなりの低確率で回復アイテムをドロップします。
* プレイヤーは初期状態で回復アイテムを１つ所持しています。回復アイテムを所持している状態で回復ボタンを押すとプレイヤーのHPを回復します。
* 回復アイテムは同時に最大１つまで所持できます。
* 経験値を一定値獲得すると、最大HP、攻撃力、防御力のうちいずれか一つが上昇します。
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
