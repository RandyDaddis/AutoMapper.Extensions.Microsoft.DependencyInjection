using System.Collections.Generic;
using System.Collections.Specialized;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
	public partial class OfficeOpenXmlStuff
	{
		#region Private Fields

		List<string> OfficeOpenXmlContentTypes = new List<string> { "application/vnd.openxmlformats-package.relationships+xml",
																	"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml"};
		#endregion

		#region Public Properties

		public string FileExtension_Get_OfficeOpenXmlContentType(string fileExtension)
		{
			string contentType = "";
			StringDictionary x = new StringDictionary();
			x.Add("docx", "application/vnd.openxmlformatsofficedocument.wordprocessingml.document.main+xml");
			x.Add("doc", "application/vnd.openxmlformatsofficedocument.wordprocessingml.document.main+xml");
			x.Add("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
			x.Add("xls", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
			x.Add("pptx", "application/vnd.openxmlformatsofficedocument.presentationml.presentation.main+xml");
			x.Add("ppt", "application/vnd.openxmlformatsofficedocument.presentationml.presentation.main+xml");

			if (!string.IsNullOrEmpty(fileExtension))
			{
				contentType = x["xlsx"];
			}
			return contentType;
		}
	}

	public enum OfficeOpenXmlMarkupLanguageEnum
	{
		WordprocessingML = 0,
		SpreadsheetML,
		PresentationML,
		DrawingML
	}

	public enum OfficeOpenXmlPrimaryLanguageEnum
	{
		WordprocessingML = 0,
		PresentationML,
		SpreadsheetML
	}

	public enum OfficeOpenXmlStrictEnum
	{
		WML = 0,	// Wordprocessing
		SML,	// Spreadsheet
		PML		// Presentation
	}

	public enum OfficeOpenXmlApplicationDescriptionEnum
	{
		Base = 0,	// has semantic understanding of at least one feature within its conformance class - http://purl.oclc.org/ooxml/descriptions/base
		Full	// has semantic understanding of every feature within its conformance class - http://purl.oclc.org/ooxml/descriptions/full
	}

	#endregion
}
