using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfGeneration.Templating
{
    public class TemplateRender
    {
        public TemplateRender()
        {
            Initialize();
        }

        private void Initialize()
        {
            DotLiquid.Template.RegisterFilter(typeof(Extensibility.CustomFilters));
            DotLiquid.Liquid.UseRubyDateFormat = false;
            DotLiquid.Template.NamingConvention = new DotLiquid.NamingConventions.CSharpNamingConvention();
        }

        public void AddKnownType(params Type[] visibleTypes)
        {
            visibleTypes = visibleTypes ?? Enumerable.Empty<Type>().ToArray();
            foreach (var type in visibleTypes)
            {
                var typeProperties = type.GetProperties();
                DotLiquid.Template.RegisterSafeType(type, typeProperties.Select(property => property.Name).ToArray());
            }
        }

        public void RenderTemplate(string templateFilePath, string htmlFilePath, dynamic model)
        {
            using (Stream htmlStream = new FileStream(htmlFilePath, FileMode.OpenOrCreate))
                RenderTemplate(templateFilePath, htmlStream, model);
        }

        public void RenderTemplate(string templateFilePath, Stream htmlStream, dynamic model, bool hasToLeaveStreamOpen = false)
        {
            using (TextWriter htmlTextWriter = new StreamWriter(htmlStream, Encoding.Default, 4096, hasToLeaveStreamOpen))
            {
                RenderTemplate(templateFilePath, htmlTextWriter, model);
            }
        }

        public void RenderTemplate(string templateFilePath, TextWriter htmlTextWriter, dynamic model)
        {
            var template = DotLiquid.Template.Parse(File.ReadAllText(templateFilePath));
            var templateRenderParameters = new DotLiquid.RenderParameters();
            var directorySeparator = Path.DirectorySeparatorChar.ToString();
            var templateDirectory = Path.GetFullPath(
                (templateFilePath.StartsWith(directorySeparator, StringComparison.InvariantCultureIgnoreCase) || templateFilePath.StartsWith("." + directorySeparator, StringComparison.InvariantCultureIgnoreCase))
                ? Path.GetDirectoryName(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, templateFilePath))
                : Path.GetDirectoryName(templateFilePath)
            );

            DotLiquid.Template.FileSystem = new DotLiquid.FileSystems.LocalFileSystem(templateDirectory);
            templateRenderParameters.LocalVariables =
                model is System.Dynamic.ExpandoObject
                ? DotLiquid.Hash.FromDictionary(model as IDictionary<string, object>)
                : DotLiquid.Hash.FromAnonymousObject(model)
            ;
            template.Render(htmlTextWriter, templateRenderParameters);
            htmlTextWriter.Flush();
        }
    }
}
