﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper.Classes.Models;
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

		public static void insert(InstaMedia media)
		{
			var db = Instance.GetDatabase("Boilermake");
			var cl = db.GetCollection<BsonDocument>("ImageData");
			cl.InsertOne(media.ToBsonDocument());
		}
		
	}
}
