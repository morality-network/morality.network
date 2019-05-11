using RateIt.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RateItWebApi.Models
{
    [Serializable]
    public class CommentUsers
    {
        [DataMember]
        public IList<User> Users = new List<User>();
        [DataMember]
        public IList<Comment> Comments = new List<Comment>();
        [DataMember]
        public int TotalComments { get; set; }
        [DataMember]
        public int TotalSubComments { get; set; }
    }
}