using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Week4.Core.Model
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string Author { get; set; }

        public List<Loan> Loans { get; set; }
    }
}
