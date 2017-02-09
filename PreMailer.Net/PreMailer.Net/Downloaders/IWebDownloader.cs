using System;
using System.Threading.Tasks;

namespace PreMailer.Net.Downloaders
{
	public interface IWebDownloader
	{
		Task<string> DownloadStringAsync(Uri uri);
	}
}
