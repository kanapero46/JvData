バージョン情報<br/>
・v00.00-03 ライブラリ対応<br/>
・v00.00-02 インターフェイス実装<br/>


クラス編成<br/>
<br/>
Main<br/>
  |--InterfaceDef(インターフェース定義)<br/>
  |         |-------iJvInit(DataLabとのやりとりI/F)<br/>
  |         |-------iDate(日付やスケジュール)<br/>
  |         |-------iJvConvert(開催場コードなど変換処理I/F)<br/>
  |         |-------iSoftWareDef(デバッグありなしなどソフト自身の定義)<br/>
  |         |-------iScsDef(使うか未定・処理振り分けのための定義)<br/>
  |--CommmonFunction(インターフェース共通処理)<br/>
  |         |-------JvInit.cs<br/>
  |         |-------Data.cs<br/>
  |         |-------JvConvert2String.cs(コード→文字列)<br/>
  |         |-------JvConvert2Integer.cs(文字列→コード)<br/>
  |--SoftCoreSystem(共通関数・処理振り分け)<br/>
  |--Form(画面生成処理（自動生成）)<br/>
  |         |-------Form1.cs。。。<br/>
  <br/>
