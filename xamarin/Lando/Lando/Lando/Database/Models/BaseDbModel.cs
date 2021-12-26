using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lando.Database.Models
{
    public abstract class BaseDbModel : BindableObject
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
