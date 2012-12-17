using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using ChecksAndBalances.Data.Models;

namespace ChecksAndBalances.Web.Formatters
{
    public class ArticleImageJpegFormatter : BufferedMediaTypeFormatter
    {
        public ArticleImageJpegFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpg"));
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
            return false;
        }
    }
}