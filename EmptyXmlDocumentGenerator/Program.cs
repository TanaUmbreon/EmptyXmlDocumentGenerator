using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using EmptyXmlDocumentGenerator.Elements;

namespace EmptyXmlDocumentGenerator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var options = Options.ParseFrom(args);

                var targetFile = new FileInfo(options.TargetExecutionFilePath);
                Assembly targetAssembly = Assembly.LoadFrom(targetFile.FullName);
                var target = new DocElementInfo(targetAssembly, options.ExcludeTypePatterns, options.IncludeTypePatterns);

                if (!string.IsNullOrEmpty(options.MergeBaseXmlDocumentPath))
                {
                    XDocument mergeBaseDoc = XDocument.Load(options.MergeBaseXmlDocumentPath);
                    var mergeBase = new DocElementInfo(mergeBaseDoc);
                    target.Merge(mergeBase);
                }

                var targertDocument = new XDocument(target.ToXElement());
                targertDocument.Save(Path.Combine(
                    targetFile.DirectoryName,
                    Path.GetFileNameWithoutExtension(targetFile.Name) + ".xml"));
            }
            catch (InvalidCommandLineArgsException)
            {
                WriteHowToUse();
            }
            catch (Exception ex)
            {
                WriteError(ex);
                Environment.ExitCode = 1;
            }
        }

        private static void WriteHowToUse()
        {
            Console.WriteLine("コマンド ライン引数に生成対象の実行ファイル (EXE または DLL) を指定してください。");
            Console.WriteLine();
            Console.WriteLine("使用法:");
            string exeName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine($"    {exeName} 対象ファイル名");
            Console.WriteLine($"        [--ExcludeTypes 除外パターン1 [除外パターン2 ...]]");
            Console.WriteLine();
            Console.WriteLine("オプション:");
            Console.WriteLine("    --ExcludeTypes 除外パターン");
            Console.WriteLine("        正規表現で記述します。このパターン文字列が完全な型名に含まれる場合、");
            Console.WriteLine("        その型情報を生成から除外します。");
            Console.WriteLine();
        }

        private static void WriteError(Exception ex)
        {
            var saved = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("実行中に問題が発生したため、アプリケーションは中断しました。");
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = saved;
            Console.WriteLine(ex.StackTrace);
        }
    }
}
