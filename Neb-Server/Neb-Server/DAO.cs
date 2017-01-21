using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Neb_Server
{
	class Dao
	{
		private static readonly Lazy<MongoClient> LazyClient = new Lazy<MongoClient>(() => new MongoClient(@"mongodb://localhost"));

		public static MongoClient Instance => LazyClient.Value;

		private static void insert(Media media)
		{
			var db = Instance.GetDatabase("Boilermake");
			var cl = db.GetCollection<BsonDocument>("ImageData");
			cl.InsertOne(media.ToBsonDocument());
		}

		private static void Main()
		{
			insert(new Media()
			{
				Attribution = new Attribution()
				{
					Name = "Hello"
				}
			});
		}
	}
}
