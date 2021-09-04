# GreenTea - Utility Extensions
________________________________________
## これは何ですか？
________________________________________
GreenTeaは、.NET5向けのユーティリティ関数をまとめたライブラリです。

________________________________________
## UnlimitedFairytales.GreenTea
________________________________________
### CollectionExtensions

Dictionary<>などに対する拡張メソッドを追加します。

### FileSystemExtensions

文字列(ファイルパス)やStreamやファイル操作に関する拡張メソッドを追加します。

### ObjectExtensions

Clone拡張メソッドを追加します。

### StringExtensions

半角や文字列日付に関する拡張メソッドを追加します。

### TestExtensions

ホワイトボックステストをどうしてもやりたい時のために、Reflectionによるメンバの書き換えを行う拡張メソッドを追加します。

________________________________________
## UnlimitedFairytales.GreenTea.CsvHelper
________________________________________
OSSのCsvHelper27.1.1を利用した、よく使用する構成を前提にした拡張メソッドを追加します。

CsvHelperの本家は、こちらを参照してください。

https://joshclose.github.io/CsvHelper/

________________________________________
## UnlimitedFairytales.GreenTea.log4net
________________________________________
OSSのlog4net2.0.12を利用した、よく使用する構成を前提にした拡張メソッドを追加します。

log4netの本家は、こちらを参照してください。

https://logging.apache.org/log4net/

OSSのMiniProfiler.Shared4.2.22を利用したDbConnectionのロギングを実現するためのIDbProfilerのシンプルな実装クラスも提供します。

MiniProfilerの本家は、こちらを参照してください。

https://miniprofiler.com/

________________________________________
## UnlimitedFairytales.GreenTea.log4net.SQLite
________________________________________
SimpleDbProfilerをOSSのSystem.Data.SQLiteに対して使用する時、Parametersをダウンキャストしてログ出力できるようにします。

SQLiteの本家は、こちらを参照してください。

https://www.sqlite.org/index.html

________________________________________
## UnlimitedFairytales.GreenTea.Windows
________________________________________
### FileSystemExtensions

Windowsシステム専用です。ファイルオーナーを取得する拡張メソッドを追加します。

________________________________________
## その他
________________________________________
### 昔はなんかもうちょっと違ったような？

```text
はい、昔プロジェクトテンプレート目的として作り、Nugetにそのバージョンを公開していました。
冷静に考えたら単なるライブラリとして追加されるNugetでうまく使える訳もないのでそちらは一旦放棄して、ライブラリ部分を取り出して再編成しました。
テンプレートは気が向いたら再度公開するかもしれません。
```