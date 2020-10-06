using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public enum ClaimType { Car, Home, Theft }
    public class ClaimItems
    {
        public int ClaimId { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                double value = (DateOfClaim - DateOfAccident).TotalDays;
                if (value <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ClaimItems() { }
        public ClaimItems(int claimId, ClaimType type, string description, float amount, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }
    }
}
