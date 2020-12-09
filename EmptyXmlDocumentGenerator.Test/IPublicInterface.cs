namespace EmptyXmlDocumentGenerator.Test
{
    /// <summary></summary>
    public interface IPublicInterface
    {
        /// <summary></summary>
        static int field;

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <returns></returns>
        int Method(int arg1);

        /// <summary></summary>
        int Property { get; set; }
    }
}
