using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public static class Constants
    {
        // File extensions
        public static string[] VIDEO_EXTENSIONS = { "webm", "mkv", "flv", "vob", "ogv",
                                            "drc", "gifv", "mng", "avi", "mts", "mov",
                                            "qt", "wmv", "yuv", "rm", "rmvb", "amv", "mp4", "m4p",
                                            "m4v", "mpg", "mp2", "mpeg", "mpe", "mpv", "m2v", "svi",
                                            "3gp", "3g2", "mxf", "roq", "nsv", "f4v", "f4p", "f4a", "f4b"};

        public static string[] AUDIO_EXTENSIONS = { "3gp", "aa", "aac", "aax", "act", "aiff", "amr", "ape", "au", "awb",
                                             "dct", "dss", "dvf", "flac", "gsm", "iklax", "ivs", "m4a", "m4b", "m4p",
                                             " mmf", "mp3", "mpc", "msv", "nmf", "nsf", "ogg", "oga", "mogg", "opus",
                                             "ra", "rm", "raw", "sln", "tta", "vox", "wav", "wma", "wv", "webm", "8svx"};

        public static string[] DOCUMENT_EXTENSIONS = {"1st", "asc", "csv", "doc", "docm", "docx", "dot", "dotx", "epub", "gdoc",
                                                        "htm", "html", "log", "mcw", "mobi", "odm", "odt", "ott", "pdf", "rtf",
                                                        "sdw", "tex", "nfo", "info", "txt", "wri", "xhtml", "xml", "xps", "ps", "msg",
                                                        "gslides", "key", "keynote", "odp", "otp", "pot", "pps", "ppt", "pptx", "sdd",
                                                        "sti", "sxi", "mpp", "bib", "enl", "gsheet", "ods", "odt", "tvs", "tab", "xls",
                                                        "xlsb", "xlsm", "xlsx", "xlt", "vsd", "vsdx"};

        public static string[] IMAGE_EXTENSION = {"bmp", "exif", "gif", "ico", "jpg", "jpeg", "jp2", "jps", "pdn", "psd", "pdd", "raw", "tga",
                                                    "tiff", "eps", "svg"};

        public static string[] ARCHIVE_EXTENSIONS = {"cab", "7z", "ace", "apk", "arc", "arj", "bin", "bzip2", "cab", "dmg", "gzip", "gz",
                                                        "lha", "rar", "rpm", "skb", "tar", "tgz", "zip"};


        // Label Text
        public static string FILE_COUNT_DEFAULT = "Files: 0";
        public static string SELECTED_DEFAULT = "Selected: 0";
        public static string FILES_PREFIX = "Files: ";
        public static string SELECTED_PREFIX = "Selected: ";
        public static string SCRAPE_TIME_PREFIX = "Duration: ";
        public static string SCRAPE_TIME_SUFFIX = " seconds";


        // Statuses
        public static string SCRAPING_STARTED = "Scraping started";
        public static string PROCESSING_PREFIX = "Processing: ";
        public static string STATUS_STOPPED = "Status: Stopped";
        public static string STATUS_SCRAPE_SAVED = "Status: Scrape file saved";

        // File names
        public static string HISTORY_FILEPATH = "history.txt";
        public static string SCRAPEFILE_FOLDER = "Scrapes";

    }
}
