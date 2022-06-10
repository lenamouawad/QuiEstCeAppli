using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuiEstCeAppli.Models
{
    public class QuestionReponse
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonProperty("question")]
        [BsonRepresentation(BsonType.String)]
        public string question { get; set; }
        public string reponse { get; set; }
        public bool asked { get; set; }

    }
}
