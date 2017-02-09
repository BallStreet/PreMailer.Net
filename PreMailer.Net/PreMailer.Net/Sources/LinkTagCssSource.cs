using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;
using PreMailer.Net.Downloaders;

namespace PreMailer.Net.Sources
{
	public class LinkTagCssSource : ICssSource
	{
		private readonly Uri _downloadUri;
		private string _cssContents;

		public LinkTagCssSource(IElement node, Uri baseUri)
		{
			// There must be an href
			var href = node.Attributes.First(a => a.Name.Equals("href", StringComparison.OrdinalIgnoreCase)).Value;

			if (Uri.IsWellFormedUriString(href, UriKind.Relative) && baseUri != null)
			{
				_downloadUri = new Uri(baseUri, href);
			}
			else
			{
				// Assume absolute
				_downloadUri = new Uri(href);
			}
		}

		public async Task<string> GetCssAsync()
		{
			if (IsSupported(_downloadUri.Scheme))
			{
				return _cssContents ?? (_cssContents = await WebDownloader.SharedDownloader.DownloadStringAsync(_downloadUri));
			}
			return string.Empty;
		}

		private bool IsSupported(string scheme)
		{
		    return Uri.CheckSchemeName(scheme);
		}
	}
}