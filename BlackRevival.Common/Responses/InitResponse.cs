namespace BlackRevival.Common.Responses;

    public class InitResult
	{
		public bool hideLabyrinth{ get; set; }
		public string assetDownloadUrlChn{ get; set; }
		public bool hideContents{ get; set; }

		public Dictionary<string, string> url { get; set; }
		public bool showTransferContents{ get; set; }
		public bool updateRecommended{ get; set; }
		public bool hideUnpack{ get; set; }
		public bool retryRequestPopup{ get; set; }
		public bool hideDownload{ get; set; }
		public bool hideProgress{ get; set; }
		
		public string assetDownloadUrlBase{ get; set; }

		public string assetDownloadUrlAws{ get; set; }

		public List<string> exceptionAreaList{ get; set; }

	
	}