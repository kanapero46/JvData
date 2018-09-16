クラス編成<br/>
<br/>
Main<br/>
  |--InterfaceDef(インターフェース定義)<br/>
  |         |-------iJvInit(DataLabとのやりとりI/F)<br/>
  |         |-------iDate(日付やスケジュール)<br/>
  |         |-------iJvConvert(開催場コードなど変換処理I/F)<br/>
  |         |-------iSoftQareDef(デバッグありなしなどソフト自身の定義)<br/>
  |         |-------iScsDef(使うか未定・処理振り分けのための定義)<br/>
  |--CommmonFunction(インターフェース共通処理)<br/>
  |         |-------JvInit.cs<br/>
  |         |-------Data.cs<br/>
  |         |-------JvConveret.cs<br/>
  |--SoftCoreSystem(共通関数・処理振り分け)<br/>
  |--Form(画面生成処理（自動生成）)<br/>
  |         |-------Form1.cs。。。<br/>
  <br/>
