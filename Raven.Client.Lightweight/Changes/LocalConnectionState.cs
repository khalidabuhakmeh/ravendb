using System;
using System.Threading;
using System.Threading.Tasks;
using Raven.Abstractions.Data;
using Raven.Database.Util;

namespace Raven.Client.Changes
{
	internal class LocalConnectionState
	{
		private readonly Action onZero;
		private readonly Task task;
		private int value;
		public Task Task
		{
			get { return task; }
		}

		public LocalConnectionState(Action onZero, Task task)
		{
			value = 0;
			this.onZero = onZero;
			this.task = task;
		}

		public void Inc()
		{
			lock (this)
			{
				value++;
			}

		}

		public void Dec()
		{
			lock(this)
			{
				if(--value == 0)
					onZero();
			}
		}

		public event Action<DocumentChangeNotification> OnDocumentChangeNotification;

		public event Action<IndexChangeNotification> OnIndexChangeNotification;

		public event Action<Exception> OnError;

		public void Send(DocumentChangeNotification documentChangeNotification)
		{
			var onOnDocumentChangeNotification = OnDocumentChangeNotification;
			if (onOnDocumentChangeNotification != null)
				onOnDocumentChangeNotification(documentChangeNotification);
		}

		public void Send(IndexChangeNotification indexChangeNotification)
		{
			var onOnIndexChangeNotification = OnIndexChangeNotification;
			if (onOnIndexChangeNotification != null)
				onOnIndexChangeNotification(indexChangeNotification);
		}

		public void Error(Exception e)
		{
			var onOnError = OnError;
			if (onOnError != null)
				onOnError(e);
		}
	}
}