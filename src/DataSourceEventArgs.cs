using System;

namespace Crow
{
	public class DataSourceEventArgs: EventArgs
	{
		public object OldDataSource;
		public object NewDataSource;

		public DataSourceEventArgs (object oldDataSource, object  newDataSource) : base()
		{
			OldDataSource = oldDataSource;
			NewDataSource = newDataSource;
		}
	}
}

