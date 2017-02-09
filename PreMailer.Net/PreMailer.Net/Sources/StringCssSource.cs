// No usings needed

using System.Threading.Tasks;

namespace PreMailer.Net.Sources
{
	public class StringCssSource : ICssSource
	{
		private readonly string _css;

		public StringCssSource(string css)
		{
			this._css = css;
		}

		public async Task<string> GetCssAsync()
		{
		    await Task.Yield();
			return _css;
		}
	}
}