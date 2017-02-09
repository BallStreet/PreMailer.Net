﻿using System.Threading.Tasks;

namespace PreMailer.Net.Sources
{
    /// <summary>
    /// Arbitrary source of CSS code/defintions.
    /// </summary>
    public interface ICssSource
    {
        Task<string> GetCssAsync();
        //string GetCss();
    }
}