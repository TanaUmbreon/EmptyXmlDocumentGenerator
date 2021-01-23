using System;

namespace EmptyXmlDocumentGenerator
{
    /// <summary>
    /// 無効なコマンド ライン引数が指定された場合に呼び出される例外です。
    /// </summary>
    public class InvalidCommandLineArgsException : Exception
    {
        /// <summary>
        /// <see cref="InvalidCommandLineArgsException"/> の新しいインスタンスを生成します。
        /// </summary>
        public InvalidCommandLineArgsException() :
            this("無効なコマンド ライン引数です。") { }

        /// <summary>
        /// <see cref="InvalidCommandLineArgsException"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message"></param>
        public InvalidCommandLineArgsException(string message) : 
            this(message, null) { }

        /// <summary>
        /// <see cref="InvalidCommandLineArgsException"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InvalidCommandLineArgsException(string message, Exception? innerException) :
            base(message, innerException) { }
    }
}
