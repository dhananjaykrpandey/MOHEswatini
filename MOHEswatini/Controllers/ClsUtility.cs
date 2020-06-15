using Microsoft.AspNetCore.ResponseCompression;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOHEswatini.Models
{
    public class ClsUtility
    {
        public enum SitemapFrequency
        {
            Never,
            Yearly,
            Monthly,
            Weekly,
            Daily,
            Hourly,
            Always
        }

        public static IEnumerable<string> MimeTypes()
        {
            return new List<string>
                            {
                                 // General
                                 "text/plain",
                                 "text/html",
                                 "text/css",
                                 "font/woff2",
                                 "application/javascript",
                                 "image/x-icon",
                                 "image/png",
                                 "application/atom+xml" ,
                                 "application/javascript" ,
                                 "application/json" ,
                                 "application/ld+json" ,
                                 "application/manifest+json" ,
                                 "application/rdf+xml" ,
                                 "application/rss+xml" ,
                                 "application/schema+json" ,
                                 "application/vnd.geo+json" ,
                                 "application/vnd.ms-fontobject",
                                 "application/x-font-ttf" ,
                                 "application/x-font-woff",
                                 "application/x-font-woff2",
                                 "application/font-otf",
                                 "application/x-font-opentype" ,
                                 "application/x-font-truetype" ,
                                 "application/x-javascript" ,
                                 "application/x-web-app-manifest+json" ,
                                 "application/xhtml+xml" ,
                                 "application/xml" ,
                                 "font/collection" ,
                                 "font/eot" ,
                                 "font/opentype" ,
                                 "font/otf" ,
                                 "font/woff" ,
                                 "font/woff2",
                                 "font/ttf" ,
                                 "image/bmp" ,
                                 "image/svg+xml" ,
                                 "image/vnd.microsoft.icon" ,
                                 "image/x-icon" ,
                                 "text/cache-manifest" ,
                                 "text/javascript" ,
                                 "text/vcard" ,
                                 "text/vnd.rim.location.xloc" ,
                                 "text/vtt" ,
                                 "text/x-component" ,
                                 "text/x-cross-domain-policy" ,
                                 "text/xml",
                                  // WebAssembly
                                  "application/wasm",
                                  "image/svg+xml",
                                  "image/jpg",
                                  "image/jepg"
                             };
        }
    }
}
