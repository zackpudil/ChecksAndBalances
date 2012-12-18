using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using ChecksAndBalances.Data.Models;

namespace ChecksAndBalances.Web.Formatters
{
    public class ArticleImageFormatter : BufferedMediaTypeFormatter
    {
        public ArticleImageFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/gif"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {
            var articleImage = value as ArticleImage;

            if (articleImage == null)
                return;

            var bytes = Convert.FromBase64String(articleImage.Image);
            writeStream.Write(bytes, 0, (int)bytes.Length);
        }

        public override bool CanReadType(Type type)
        {
            return typeof(ArticleImage).Equals(type);
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(ArticleImage).Equals(type);
        }
    }
}