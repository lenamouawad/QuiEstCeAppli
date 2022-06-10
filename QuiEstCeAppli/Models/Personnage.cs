using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuiEstCeAppli.Models
{
    public class Personnage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonProperty("genre")]
        [BsonRepresentation(BsonType.String)]
        public string genre { get; set; }
        [JsonProperty("prenom")]
        [BsonRepresentation(BsonType.String)]
        public string prenom { get; set; }
        [JsonProperty("espece")]
        [BsonRepresentation(BsonType.String)]
        public string espece { get; set; }
        [JsonProperty("couleurYeux")]
        [BsonRepresentation(BsonType.String)]
        public string couleurYeux { get; set; }
        [JsonProperty("couleurCheveux")]
        [BsonRepresentation(BsonType.String)]
        public string couleurCheveux { get; set; }
        public bool hasLunettes { get; set; }

        public bool hasChapeau { get; set; }
        public bool isWizard { get; set; }
        public string urlPhoto { get; set; }

    }
}
