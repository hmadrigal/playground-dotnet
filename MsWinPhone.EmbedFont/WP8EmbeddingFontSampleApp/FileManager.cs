namespace WP8EmbeddingFontSampleApp
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;

    public sealed class FileManager
    {

        public async Task<Stream> OpenFile(string packedFile)
        {
            var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(packedFile));
            var randomAccessStream = await storageFile.OpenReadAsync();
            var stream = randomAccessStream.AsStreamForRead();
            return stream;
        }

        public async Task<string> ToBase64String(Stream stream)
        {
            var buffer = new byte[stream.Length];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            var base64String = ToBase64String(buffer);
            return base64String;
        }

        public string ToBase64String(byte[] buffer)
        {
            var base64String = Convert.ToBase64String(buffer);
            return base64String;
        }

        public async Task<string> GetBase64String(string packedFile)
        {
            using (var stream = await OpenFile(packedFile))
            {
                return await ToBase64String(stream);
            }
        }

        public async Task<string> LoadHtmlPage(string packedFiles, Dictionary<string, string> placeHolderValues)
        {
            var fileContent = await ReadToEnd(packedFiles);
            var htmlPage = fileContent.ReplaceStringTemplate(placeHolderValues);
            return htmlPage;
        }

        public async Task<string> ReadToEnd(string packedFiles)
        {
            using (var stream = await OpenFile(packedFiles))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var fileContent = await streamReader.ReadToEndAsync();
                    return fileContent;
                }
            }
        }

        private void InitializeFileManager()
        {
        }

        #region Singleton Pattern w/ Constructor
        private FileManager()
            : base()
        {
            InitializeFileManager();
        }
        public static FileManager Instance
        {
            get
            {
                return SingletonFileManagerCreator._Instance;
            }
        }
        private class SingletonFileManagerCreator
        {
            private SingletonFileManagerCreator() { }
            public static FileManager _Instance = new FileManager();
        }
        #endregion
    }


}
