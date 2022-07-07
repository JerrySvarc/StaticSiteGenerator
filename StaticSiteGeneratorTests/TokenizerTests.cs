using StaticSiteGenerator;
namespace StaticSiteGeneratorTests
{
    public class TokenizerTests
    {

        [Test]
        public void TokenizeTextNotNUll()
        {
            string text = "# This is a test.";
            Tokenizer tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(text);
            Assert.NotNull(tokens);
        }

        [Test]
        public void TokenizeTextNoText()
        {
            string text = "";
            Tokenizer tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(text);
            Assert.NotNull(tokens);
            Assert.That(tokens.Count, Is.EqualTo(1)); //EOF tag
        }

        [Test]
        public void TokenizeTextCountMoreThanZero()
        {
            string text = "# Test text!";
            Tokenizer tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(text);
            Assert.NotNull(tokens);
            Assert.That(tokens.Count, Is.EqualTo(4));
        }

        [Test]
        public void TokenizeNullString()
        {
            string text = null;
            Tokenizer tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(text);
            Assert.Null(tokens);
        }
    }
}