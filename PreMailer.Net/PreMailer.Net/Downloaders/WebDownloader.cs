using System;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PreMailer.Net.Downloaders
{
	public class WebDownloader : IWebDownloader
	{
	    private static HttpClient _client = new HttpClient();
		private static IWebDownloader _sharedDownloader;

		public static IWebDownloader SharedDownloader
		{
			get
			{
				if (_sharedDownloader == null)
				{
					_sharedDownloader = new WebDownloader();
				}

				return _sharedDownloader;
			}
			set
			{
				_sharedDownloader = value;
			}
		}

		public async Task<string> DownloadStringAsync(Uri uri)
		{
		    return await _client.GetStringAsync(uri);
		}
	}
}