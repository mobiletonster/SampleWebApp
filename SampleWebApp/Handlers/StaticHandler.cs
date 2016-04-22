using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace SampleWebApp.Handlers
{
    public class StaticHandler : IHttpHandler
    {
        string _basePath = string.Empty;
        bool _isSinglePageApp = false;
        bool _isHttpProxy = false;
        bool IHttpHandler.IsReusable
        {
            get
            {
                return true;
            }
        }

        public StaticHandler()
        {
            _basePath = GetStaticProxyBasePath();

            _isSinglePageApp = CheckSinglePageAppConfig();

            _isHttpProxy = (_basePath.StartsWith("http"));
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            if (_isHttpProxy)
            {
                ProxyHttp(context);
            }else
            {
                ProcessStaticFile(context);
            }

        }
        private void ProxyHttp(HttpContext context)
        {
            var uri = context.Request.Url;
            var url = uri.AbsolutePath;
            var path = _basePath + url;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_basePath);
            var result = client.GetByteArrayAsync(path).Result;
            context.Response.BinaryWrite(result);  
        }
        private void ProcessStaticFile(HttpContext context)
        {
            var uri = context.Request.Url;
            string path = string.Empty;

            try
            {
                path = FindStaticFile(uri);
            }
            catch
            {
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "File Not Found";
                return;
            }

            // Find the MIME type
            string mimeType = MimeMapping.GetMimeMapping(path);
            context.Response.ContentType = mimeType;
            context.Response.WriteFile(path);
        }
        private string FindStaticFile(Uri uri)
        {
            var url = uri.AbsolutePath;

            if (uri.Segments.Last().Trim().EndsWith("/"))
            {
                string[] defaultDocuments = { "index.html", "default.htm", "index.htm", "default.html" };
                foreach (var d in defaultDocuments)
                {
                    if (_isSinglePageApp)
                    {
                        var path = _basePath + d;
                        if (File.Exists(path))
                        {
                            return path;
                        }
                    }
                    else
                    {
                        var path = _basePath + url + d;
                        if (File.Exists(path))
                        {
                            return path;
                        }
                    }
                }
            }
            else
            {
                var path = _basePath + url;
                if (File.Exists(path))
                {
                    return path;
                }
            }
            throw new Exception("Default Document not found.");
        }
        private string GetStaticProxyBasePath()
        {
            var basePath = ConfigurationManager.AppSettings["StaticProxyBasePath"];
            if (basePath == null)
            {
                throw new Exception("StaticProxyBasePath not found in AppSettings in Web.config.");
            }
            return basePath.ToString();
        }
        private bool CheckSinglePageAppConfig()
        {
            var singlePageApp = ConfigurationManager.AppSettings["IsSinglePageApp"];
            if (singlePageApp == null)
            {
                return false;
            }
            else
            {
                return (singlePageApp == "true");
            }
        }
    }
}