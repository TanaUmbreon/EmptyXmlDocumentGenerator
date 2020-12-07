namespace EmptyXmlDocumentGenerator.Test
{
    /// <summary>
    /// public interface PublicInterface
    /// </summary>
    public interface IPublicInterface
    {
        /// <summary>static int field</summary>
        static int field;

        /// <summary>
        /// int Property { get; set; }
        /// </summary>
        int Property { get; set; }

        /// <summary>
        /// int Method(int arg1)
        /// </summary>
        /// <param name="arg1">int arg1</param>
        /// <returns>returns int</returns>
        int Method(int arg1);
    }
}
