namespace SteKoLib
{
    public class TextUtil
	{
		public static bool IsRtfText(string text)
		{
			// First validate the text
			if (string.IsNullOrEmpty(text))
				return false;

			// Return right data
			if (text.StartsWith(@"{\rtf"))
				return true;

			// Return default
			return false;
		}
	}
}
