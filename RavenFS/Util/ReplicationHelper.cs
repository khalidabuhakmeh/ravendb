namespace RavenFS.Util
{
	public static class ReplicationHelper
	{
		public static string SyncConfigNameForFile(string fileName)
		{
			return string.Format("Syncing-{0}", fileName);
		}

        public static string ConflictConfigNameForFile(string fileName)
        {
            return string.Format("Conflicted-{0}", fileName);
        }

        public static string SyncResultNameForFile(string fileName)
        {
            return string.Format("SyncResult-{0}", fileName);
        }

	    public static string DownloadingFileName(string fileName)
        {
            return fileName + ".downloading";
        }
	}
}