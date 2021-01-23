using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;

namespace EmptyXmlDocumentGenerator
{
    /// <summary>
    /// コマンドの実行オプションを格納します。
    /// </summary>
    public class Options
    {
        /// <summary>
        /// XML ドキュメントの生成対象となる実行ファイルのパスを取得または設定します。
        /// </summary>
        [Option(longName: "Target", Required = true)]
        public string TargetExecutionFilePath { get; set; } = "";

        /// <summary>
        /// メッセージ本文のマージ元として使用する XML ドキュメントのパスを取得または設定します。
        /// </summary>
        [Option(longName: "MergeBase", Required = false)]
        public string MergeBaseXmlDocumentPath { get; set; } = "";

        /// <summary>
        /// 型情報の生成から除外する型名のパターンのコレクションを取得または設定します。
        /// </summary>
        [Option(longName: "ExcludeTypes", Required = false)]
        public IEnumerable<string> ExcludeTypePatterns { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 型情報の生成に含める型名のパターンのコレクションを取得または設定します。
        /// </summary>
        [Option(longName: "IncludeTypes", Required = false)]
        public IEnumerable<string> IncludeTypePatterns { get; set; } = Array.Empty<string>();

        /// <summary>
        /// <see cref="Options"/> の新しいインスタンスを生成します。
        /// </summary>
        public Options() { }

        /// <summary>
        /// 指定したコマンド ライン引数を解析して、
        /// <see cref="Options"/> のインスタンスに変換して返します。
        /// </summary>
        /// <param name="args">コマンド ライン引数。</param>
        /// <returns>コマンド ライン引数から解析されたコマンドの実行オプション セット。</returns>
        public static Options ParseFrom(IEnumerable<string> args)
        {
            // 未定義の引数は無視する
            using var p = new Parser(config => config.IgnoreUnknownArguments = true);

            Options result = p.ParseArguments<Options>(args).MapResult(
                options => options,
                _ => throw new InvalidCommandLineArgsException("コマンド ライン引数の変換に失敗しました。")
                );
            if (result.ExcludeTypePatterns.Any() && result.IncludeTypePatterns.Any())
            {
                throw new InvalidCommandLineArgsException("オプション --ExcludeTypes と --IncludeTypes は片方のみ指定できます。");
            }

            return result;
        }
    }
}
