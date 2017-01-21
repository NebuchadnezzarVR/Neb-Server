using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Neb_Server
{
	class Dao
	{
		private static readonly Lazy<MongoClient> LazyClient = new Lazy<MongoClient>(() => new MongoClient(@"mongodb://localhost"));

		public static MongoClient Instance => LazyClient.Value;
	}
}
