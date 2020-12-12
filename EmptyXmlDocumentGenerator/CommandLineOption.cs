using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmptyXmlDocumentGenerator
{
    /// <summary>
    /// コマンド ラインの実行オプションを表します。
    /// </summary>
    public class CommandLineOption
    {
        /// <summary>
        /// 実行オプションが何も指定されていないことを表す値を取得します。
        /// </summary>
        public bool IsEmpty { get; }

        /// <summary>
        /// 生成対象のファイル名を取得します。
        /// </summary>
        public string TargetFileName { get; }

        /// <summary>
        /// 型情報の生成から除外する型名のパターンのコレクションを取得します。
        /// </summary>
        public IEnumerable<string> ExcludeTypePatterns { get; }

        /// <summary>
        /// <see cref="CommandLineOption"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="args">コマンド ライン引数。</param>
        public CommandLineOption(IEnumerable<string> args)
        {
            const string ExcludeTypesKey = "--ExcludeTypes";

            IsEmpty = !args.Any();
            TargetFileName = args.FirstOrDefault() ?? "";

            ExcludeTypePatterns = Array.Empty<string>();
            if (args.Contains(ExcludeTypesKey))
            {
                ExcludeTypePatterns = args.SkipWhile(a => a != ExcludeTypesKey);
            }
        }

        /// <summary>
        /// 生成対象のファイルが存在しない場合に例外をスローします。
        /// </summary>
        public void ThrowIfTargetFileNotFound()
        {
            if (!File.Exists(TargetFileName))
            {
                throw new FileNotFoundException($"ファイル '{TargetFileName}' が見つかりません。");
            }
        }
    }
}
