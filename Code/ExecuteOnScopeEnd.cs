using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteKoLib
{
	/// <summary>
	/// Meant to execute an action when this object gets finialized
	/// Usage:
	/// void MyFunction()
	/// {
	///		ExecuteOnScopeEnd(() =>
	///		{
	///			// Execute the code code you want
	///		});
	/// }
	/// </summary>
	public class ExecuteOnScopeEnd : IDisposable
	{
		private Action Action = null;
		public ExecuteOnScopeEnd(Action InAction)
		{
			Action = InAction;
		}	

		~ExecuteOnScopeEnd()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (!disposed)
			{
				Action();
				disposed = true;
			}
		}

		private bool disposed = false;

	}
}
