using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    public partial class MimeType_oldQueries
	{
		#region Private Fields

		//private List<string> _officeOpenXmlContentTypes = new List<string> 
		//												{ "application/vnd.openxmlformats-package.relationships+xml"};
		private Dictionary<string,string> _allMimeTypes = new Dictionary<string,string>();
		private Dictionary<string,string> _adobe_MimeTypes = new Dictionary<string,string>();
        private Dictionary<string,string> _image_MimeTypes = new Dictionary<string,string>();
        private Dictionary<string,string> _presentationML_MimeTypes = new Dictionary<string,string>();
		private Dictionary<string,string> _spreadsheetML_MimeTypes = new Dictionary<string,string>();
		private Dictionary<string,string> _wordProcessingML_MimeTypes = new Dictionary<string,string>();

		#endregion

		#region Methods

		public Dictionary<string,string> GetAllMimeTypes()
		{
            Get_Image_MimeTypes();
			Get_PresentationML_MimeTypes();
			Get_SpreadsheetML_MimeTypes();
			Get_WordProcessingML_MimeTypes();

			return _allMimeTypes;
		}

		public Dictionary<string,string> Get_Adobe_MimeTypes()
		{
			_adobe_MimeTypes.Add("pdf", "application/pdf");
			_adobe_MimeTypes.Add("swf", "application/x-shockwave-flash");
			return _adobe_MimeTypes;
		}

        public Dictionary<string,string> Get_Image_MimeTypes()
        {
            _image_MimeTypes.Add("jpg", "image/jpg");
            _image_MimeTypes.Add("png", "image/png");
            return _image_MimeTypes;
        }

        public Dictionary<string,string> Get_PresentationML_MimeTypes()
		{
			_presentationML_MimeTypes.Add("pptx", "application/vnd.openxmlformatsofficedocument.presentationml.presentation.main+xml");
			_presentationML_MimeTypes.Add("ppt", "application/vnd.openxmlformatsofficedocument.presentationml.presentation.main+xml");
			return _presentationML_MimeTypes;
		}
		public Dictionary<string,string> Get_SpreadsheetML_MimeTypes()
		{
			//	"application/vnd.ms-excel"
			//	"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
			_spreadsheetML_MimeTypes.Add("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
			_spreadsheetML_MimeTypes.Add("xls", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
			return _spreadsheetML_MimeTypes;
		}
		public Dictionary<string,string> Get_WordProcessingML_MimeTypes()
		{
			//	"application/vnd.openxmlformats-officedocument.wordprocessingml.document"
			_wordProcessingML_MimeTypes.Add("docx", "application/vnd.openxmlformatsofficedocument.wordprocessingml.document.main+xml");
			_wordProcessingML_MimeTypes.Add("doc", "application/vnd.openxmlformatsofficedocument.wordprocessingml.document.main+xml");
			return _wordProcessingML_MimeTypes;
		}

		public string FileExtension_Get_ContentType(string fileExtension, string contentType)
		{
			string result = string.Empty;
			if ((!string.IsNullOrEmpty(fileExtension)) && (!string.IsNullOrEmpty(contentType)))
			{
				result = _allMimeTypes["xlsx"];
			}
			return result;
		}

		#endregion
	}
}
