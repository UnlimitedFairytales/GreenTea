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
### 昔はもうちょっと違ったような？

```text
はい、かつてプロジェクトテンプレート目的として作りました。
ただし単なるライブラリとして考えるとまともに使えないことに気づきました。
そのため、そちらは一旦放棄してライブラリ部分を取り出して再編成しました。
テンプレートは気が向いたら調整してslnテンプレートとして公開するかもしれません。

旧GreenTeaとの比較

廃止					UnlimitedFairytales.GreenTea.Data.DbConfig
廃止					UnlimitedFairytales.GreenTea.Data.DbConnectionHelper
log4net拡張に再編成済	UnlimitedFairytales.GreenTea.Data.SimpleDbProfiler
廃止					UnlimitedFairytales.GreenTea.Exceptions.CanceledException
廃止					UnlimitedFairytales.GreenTea.Exceptions.NegativeResponseException
廃止					UnlimitedFairytales.GreenTea.Exceptions.NoDataFoundException
何らかの形で再編成済	UnlimitedFairytales.GreenTea.Extensions.*
廃止					UnlimitedFairytales.GreenTea.Resources.StringResource
CsvHelper拡張に再編成済	UnlimitedFairytales.GreenTea.Utilities.CodePage
CsvHelper拡張に再編成済	UnlimitedFairytales.GreenTea.Utilities.Csv
廃止					UnlimitedFairytales.GreenTea.Utilities.Http
廃止					UnlimitedFairytales.GreenTea.Utilities.Mail
```