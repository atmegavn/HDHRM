using HD.Profiles.Locations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Profiles
{
    public class IdCard : Entity<Guid>
    {
        public CardType Type { get; set; }
        public string Number { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset DateOfBith { get; set; }
        public DateTimeOffset DateOfExpiry { get; set; }
        public National Nationality { get; set; }
        public Location PlaceOfOrigin { get; set; }
        public Location PlaceOfResidence { get; set; }
        public string PersonalIdentification { get; set; }
        public DateTimeOffset DateOfProvided { get; set; }
        public Guid ProfileId { get; set; }
    }
}
