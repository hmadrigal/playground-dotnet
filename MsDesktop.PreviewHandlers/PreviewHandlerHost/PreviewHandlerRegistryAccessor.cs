using System;
using System.Collections.Generic;
using Microsoft.Win32;


namespace C4F.DevKit.PreviewHandler.PreviewHandlerHost
{
    /// <summary>
    /// Class used to traverse the registry to read all the file previewer registrations that exist on the system
    /// The majority of this code and logic comes from the Preview Handler Association Editor that Stephen Toub wrote
    /// and posted about on his blog.  http://blogs.msdn.com/toub/archive/2006/12/14/preview-handler-association-editor.aspx
    /// We made a few minor tweaks for our purposes, but the core of the logic is his.  Thanks to Stephen for sharing this code.
    /// </summary>
    internal class PreviewHandlerRegistryAccessor
    {
        private const string BaseRegistryKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PreviewHandlers";
        private const string BaseClsIDKey = @"HKEY_CLASSES_ROOT\{0}\shellex\{{8895b1c6-b41f-4c1c-a562-0d564250836f}}";
        private const string BaseClsIdKey2 = @"HKEY_CLASSES_ROOT\SystemFileAssociations\{0}\shellex\{{8895b1c6-b41f-4c1c-a562-0d564250836f}}";


        /// <summary>
        /// Read the registry to learn about the preview handlers that are available on this machine
        /// Return a structure containing 2 collections.  One of all the file extensions and whether we found a preview handler
        /// registered, and one of the preview handlers and their CLSIDs
        /// </summary>
        internal static RegistrationData LoadRegistrationInformation()
        {
            // Load and sort all preview handler information from registry
            List<PreviewHandlerInfo> handlers = new List<PreviewHandlerInfo>();
            using (RegistryKey handlersKey = Registry.LocalMachine.OpenSubKey(
                BaseRegistryKey))
            {
                foreach (string id in handlersKey.GetValueNames())
                {
                    PreviewHandlerInfo handler = new PreviewHandlerInfo();
                    handler.ID = id;
                    handler.Name = handlersKey.GetValue(id, null) as string;
                    handlers.Add(handler);
                }
            }
            handlers.Sort(delegate(PreviewHandlerInfo first, PreviewHandlerInfo second)
            {
                if (first.Name == null) return 1;
                else if (second.Name == null) return -1;
                else return first.Name.CompareTo(second.Name);
            });

            // Create a lookup table of preview handler ID -> PreviewHandlerInfo
            Dictionary<string, PreviewHandlerInfo> handlerMapping = new Dictionary<string, PreviewHandlerInfo>(handlers.Count);
            foreach (PreviewHandlerInfo handler in handlers)
            {
                handlerMapping.Add(handler.ID, handler);
            }

            // Get all classes/extensions from registry
            string[] extensions = Registry.ClassesRoot.GetSubKeyNames();

            // Find out what each extension is registered to be previewed with
            List<ExtensionInfo> extensionInfos = new List<ExtensionInfo>(extensions.Length);
            foreach (string extension in extensions)
            {
                if (extension.StartsWith("."))
                {
                    ExtensionInfo info = new ExtensionInfo();
                    info.Extension = extension;

                    string id = Registry.GetValue(
                        string.Format(BaseClsIDKey, extension),
                        null, null) as string;
                    if (id == null)
                        id = Registry.GetValue(
                        string.Format(BaseClsIdKey2, extension),
                        null, null) as string;
                    PreviewHandlerInfo mappedHandler;
                    if (id != null && handlerMapping.TryGetValue(id, out mappedHandler)) info.Handler = mappedHandler;

                    extensionInfos.Add(info);
                }
            }

            // Return the information
            RegistrationData data = new RegistrationData();
            data.Handlers = handlers;
            data.Extensions = extensionInfos;
            return data;
        }
    }
    internal class RegistrationData
    {
        public List<PreviewHandlerInfo> Handlers;
        public List<ExtensionInfo> Extensions;
    }

    internal class PreviewHandlerInfo
    {
        public string Name;
        public string ID;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name)) return ID;
            else return Name;
        }
    }

    internal class ExtensionInfo
    {
        public string Extension;
        public PreviewHandlerInfo Handler;
        public override string ToString() { return Extension; }
    }
}
