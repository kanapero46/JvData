クラス編成

Main
  |--InterfaceDef(インターフェース定義)
  |         |-------iJvInit(DataLabとのやりとりI/F)
  |         |-------iDate(日付やスケジュール)
  |         |-------iJvConvert(開催場コードなど変換処理I/F)
  |         |-------iSoftQareDef(デバッグありなしなどソフト自身の定義)
  |         |-------iScsDef(使うか未定・処理振り分けのための定義)
  |--CommmonFunction(インターフェース共通処理)
  |         |-------JvInit.cs
  |         |-------Data.cs
  |         |-------JvConveret.cs
  |--SoftCoreSystem(共通関数・処理振り分け)
  |--Form(画面生成処理（自動生成）)
  |         |-------Form1.cs。。。
  
