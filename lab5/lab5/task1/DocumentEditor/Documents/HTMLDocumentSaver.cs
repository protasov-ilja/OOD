using System.Collections.Generic;
using task1.DocumentEditor.Documents.Items;
using System.Web;
using System.IO;
using System;

namespace task1.DocumentEditor.Documents
{
    public class HTMLDocumentSaver
    {
		public HTMLDocumentSaver(string path, List<DocumentItem> items, string title)
		{
			if (File.Exists(path))
			{
				Console.WriteLine($"File {path} already exist and will be deleted");
				File.Delete(path);
			}

			using (StreamWriter sW = new StreamWriter(path))
			{
				sW.WriteLine("<!DOCTYPE html>");
				sW.WriteLine("<head>");
				sW.WriteLine($"  <title>{ HttpUtility.HtmlEncode(title) } </title>");
				sW.WriteLine("</head>");
				sW.WriteLine("<body>");

				foreach (DocumentItem item in items)
				{
					IParagraph paragraph = item.Paragraph;
					IImage image = item.Image;
					if (paragraph != null)
					{
						sW.WriteLine($"<p>{ HttpUtility.HtmlEncode(paragraph.GetParagraphText()) }</p>");
					}
					else if (image != null)
					{
						var relativePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), image.Path);
						Console.WriteLine(relativePath);
						relativePath = relativePath.Replace("\\", "/");
						sW.WriteLine($"<img src=\"{ HttpUtility.HtmlEncode(relativePath) }\" width=\"{ image.Width }\" height=\"{ image.Height }\"/>");
					}
				}

				sW.WriteLine("</body>");
				sW.WriteLine("</html>");
				sW.Close();
			}
		}
    }
}
