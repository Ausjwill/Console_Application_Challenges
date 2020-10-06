using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public class ClaimItemsRepository
    {
        protected readonly List<ClaimItems> _claimDirectory = new List<ClaimItems>();
        //CRUD

        //CREATE NEW CLAIM
        public bool AddNewClaim(ClaimItems newClaim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(newClaim);
            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ ALL CLAIMS
        public List<ClaimItems> GetAllClaims()
        {
            return _claimDirectory;
        }

        //READ ONLY TOP CLAIM
        public ClaimItems GetNextClaim()
        {
            int count = 0;
            foreach (ClaimItems singleItem in _claimDirectory)
            {
                if (count == 0)
                {
                    return singleItem;
                }
            }
            return null;
        }

        //READ ONE
        public ClaimItems GetItemsById(int claimId)
        {
            foreach (ClaimItems singleItem in _claimDirectory)
            {
                if (singleItem.ClaimId == claimId)
                {
                    return singleItem;
                }
            }
            return null;
        }

        //DELETE CLAIM
        public bool RemoveClaim(ClaimItems claimId)
        {
            bool deleteResult = _claimDirectory.Remove(claimId);
            return deleteResult;
        }

    }
}
