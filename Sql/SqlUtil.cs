using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SteKoLib
{
	public class SqlUtil
	{
		#region Public Properties

		public static string Server
		{
			get { return server; }
		}

		public static string Database
		{
			get { return db; }
		}

		public static string ConnectionString
		{
			get { return string.Format("Data Source = '{0}';Initial Catalog = '{1}';Integrated Security=true;Connection Timeout={2}", server, db, timeout); }
		}

		#endregion

		#region Public Methods

		public static SqlConnection GetConnection()
		{
			// TODO: Replace with user password
			return new SqlConnection(ConnectionString);
		}

		public static bool TestConnection(string sqlServer, string database)
		{
			server = sqlServer;
			db = database;
			SqlConnection conTest = new SqlConnection(ConnectionString);
			try
			{
				conTest.Open();
				db = conTest.Database;
				return true;
			}
			catch (Exception)
			{
				//Error.Log(ex.Message);
				return false;
			}
			finally
			{
				conTest.Close();
			}
		}

		#endregion

		#region Member

		static string server = ".\\SQLEXPRESS";
		static string db = "TelerealDocuments";
		static int timeout = 10;

		#endregion
	}
}
