using System.Threading.Tasks;
using AngleSharp.Dom;

namespace PreMailer.Net.Sources
{
	public class DocumentStyleTagCssSource : ICssSource
	{
		private readonly IElement _node;

        public DocumentStyleTagCssSource(IElement node)
		{
			_node = node;
		}

		public async Task<string> GetCssAsync()
		{
		    await Task.Yield();
			return _node.InnerHtml;
		}
	}
}