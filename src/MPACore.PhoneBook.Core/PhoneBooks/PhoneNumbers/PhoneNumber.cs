using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBooks.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.PhoneBooks.PhoneNumbers
{
    public class PhoneNumber :Entity<long>, IHasCreationTime
    {
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }

        public PhoneType type { get; set; }

        //public virtual int PersonId { get; set; }
        public int PersonId { get; set; }

        //public virtual Person Person { get; set; }
        public Person Person { get; set; }


        public DateTime CreationTime { get; set; }
    }
}
