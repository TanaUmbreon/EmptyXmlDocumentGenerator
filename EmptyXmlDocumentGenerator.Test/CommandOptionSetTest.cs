using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace EmptyXmlDocumentGenerator.Test
{
    [TestFixture]
    class CommandOptionSetTest
    {
        [Test(Description = "")]
        public void ParseFrom_Error()
        {
            Assert.That(() => { CreateCommandOptionSet(); }, Throws.Exception);
            Assert.That(() => { CreateCommandOptionSet("aaa.xml"); }, Throws.Exception);
            Assert.That(() => { CreateCommandOptionSet("--Target"); }, Throws.Exception);
            Assert.That(() => { CreateCommandOptionSet("--target", "aaa.xml"); }, Throws.Exception);
            Assert.That(() => { CreateCommandOptionSet("--MergeBase", "bbb.xml", "--ExcludeTypes", "BlackyPeroPero", "IBlackyPeroPero"); }, Throws.Exception);
        }

        [Test]
        public void ParseFrom_Complete()
        {
            {
                var opt = CreateCommandOptionSet("--Target", "aaa.xml");
                Assert.That(opt.TargetExecutionFilePath, Is.EqualTo("aaa.xml"));
                Assert.That(opt.MergeBaseXmlDocumentPath, Is.Empty);
                Assert.That(opt.ExcludeTypePatterns, Is.Empty);
            }
            {
                var opt = CreateCommandOptionSet("--Target", "aaa.xml", "--MergeBase", "bbb.xml", "--ExcludeTypes", "BlackyPeroPero", "IBlackyPeroPero");
                Assert.That(opt.TargetExecutionFilePath, Is.EqualTo("aaa.xml"));
                Assert.That(opt.MergeBaseXmlDocumentPath, Is.EqualTo("bbb.xml"));
                Assert.That(opt.ExcludeTypePatterns, Is.EqualTo(new[] { "BlackyPeroPero", "IBlackyPeroPero" }));
            }
        }

        private CommandOptionSet CreateCommandOptionSet(params string[] args)
        {
            return CommandOptionSet.ParseFrom(args);
        }
    }
}
