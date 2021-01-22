using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;

namespace EmptyXmlDocumentGenerator
{
    /// <summary>
    /// コマンドの実行オプション セットを格納します。
    /// </summary>
    public class CommandOptionSet
    {
        /// <summary>
        /// XML ドキュメントの生成対象となる実行ファイルのパスを取得または設定します。
        /// </summary>
        [Option(longName: "Target", Required = true)]
        public string TargetExecutionFilePath { get; set; } = "";

        /// <summary>
        /// メッセージ本文として使用するマージ元の XML ドキュメントのパスを取得または設定します。
        /// </summary>
        [Option(longName: "MergeBase", Required = false)]
        public string MergeBaseXmlDocumentPath { get; set; } = "";

        /// <summary>
        /// 型情報の生成から除外する型名のパターンのコレクションを取得または設定します。
        /// </summary>
        [Option(longName: "ExcludeTypes", Required = false)]
        public IEnumerable<string> ExcludeTypePatterns { get; set; } = Array.Empty<string>();

        /// <summary>
        /// <see cref="CommandOptionSet"/> の新しいインスタンスを生成します。
        /// </summary>
        public CommandOptionSet() { }

        /// <summary>
        /// 指定したコマンド ライン引数を解析して、
        /// <see cref="CommandOptionSet"/> のインスタンスに変換して返します。
        /// </summary>
        /// <param name="args">コマンド ライン引数。</param>
        /// <returns>コマンド ライン引数から解析されたコマンドの実行オプション セット。</returns>
        public static CommandOptionSet ParseFrom(IEnumerable<string> args)
        {
            // 未定義の引数は無視する
            using var p = new Parser(config => config.IgnoreUnknownArguments = true);

            CommandOptionSet result = p.ParseArguments<CommandOptionSet>(args).MapResult(
                options => options,
                _ => throw new InvalidCastException("コマンド ライン引数の変換に失敗しました。")
                );

            return result;
        }
    }
}
