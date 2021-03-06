# Empty XML Document Generator

.NET の実行ファイル (EXE や DLL) から本文が空の XML ドキュメントを生成するツールです。

## 想定用途

開発に必要な DLL だけどその XML ドキュメントが用意されていない！　でもエディタ上 (インテリセンス) でヘルプを参照したい！　という人向けです。

インテリセンスで認識させるための要素や属性の構成はこのアプリで生成するので、あとは使用者自身の手で本文のヘルプメッセージを記入して使用してください。

## 使用法

以下のように、コマンドラインアプリとして使用します。

```txt
EmptyXmlDocumentGenerator --Target 対象ファイル名 [--MergeBase マージ元ファイル名] [--ExcludeTypes 除外パターン1 [除外パターン2 ...]] [--IncludeTypes 対象パターン1 [対象パターン2 ...]]
```

- `--Target 対象ファイル名`
  - XML ドキュメントの生成対象となる実行ファイルのパスを指定します。
- `--MergeBase マージ元ファイル名`
  - メッセージ本文のマージ元として使用する XML ドキュメントのパスを指定します。
- `--ExcludeTypes 除外パターン`
  - 正規表現で記述します。このパターン文字列が名前空間を含めた完全型名に含まれる場合、その型情報を生成から除外します。`--IncludeTypes` オプションと同時に指定することはできません。
- `--IncludeTypes 対象パターン`
  - 正規表現で記述します。このパターン文字列が名前空間を含めた完全型名に含まれる場合のみ、その型情報を生成します。`--ExcludeTypes` オプションと同時に指定することはできません。

## 動作環境

.NET Core 3.1 がインストールされた端末。

## バージョン履歴

### Version 1.1.1 (2021/2/14)

- 入れ子クラスが出力できなかった問題を修正。

### Version 1.1.0 (2021/1/23)

- コマンドオプションの指定方法を変更。
- ホワイトリスト形式で生成する型を指定できる機能を追加。
- メッセージ本文のマージ機能を追加。

### Version 1.0.0 (2020/12/12)

- 初回バージョン。
