using System;
using System.IO;
using System.Linq;
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
                if (!args.Any())
                {
                    WriteHowToUse();
                    return;
                }

                foreach (string fileName in args)
                {
                    var file = new FileInfo(fileName);

                    Assembly assembly = Assembly.LoadFrom(file.FullName);
                    DocInfo doc = new DocInfo(assembly);
                    var document = new XDocument(doc.Build());

                    document.Save(Path.Combine(
                        file.DirectoryName,
                        Path.GetFileNameWithoutExtension(file.Name) + ".xml"));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex);
                Environment.ExitCode = 1;
                throw;
            }
        }

        private static void WriteHowToUse()
        {
            Console.WriteLine("コマンド ライン引数に生成対象の実行ファイル (EXE または DLL) を指定してください。");
            Console.WriteLine();
            Console.WriteLine("使用法:");
            string exeName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine($"    {exeName} 対象ファイル名1 [対象ファイル名2 ...]");
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
