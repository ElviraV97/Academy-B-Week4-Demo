using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.Core.Model
{
    [DataContract]
    public class Loan
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string BookISBN{ get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public DateTime LoanDate { get; set; }

        [DataMember]
        public DateTime? ReturnDate { get; set; }

        public Book Book { get; set; }
    }
}
