using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Badges_Repository
{
    public class BadgeItemsRepository
    {
        protected readonly List<BadgeItems> _badgeDirectory = new List<BadgeItems>();
        //CRUD

        //CREATE NEW BADGE
        public bool AddNewBadge(BadgeItems newBadge)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(newBadge);
            bool wasAdded = (_badgeDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ ALL BADGES
        public List<BadgeItems> GetAllBadges()
        {
            return _badgeDirectory;
        }

        //UPDATE DOORS ON BADGE

        //ADD DOOR TO BADGE

        //DELETE DOOR FROM BADGE

        //DELETE ALL DOORS FROM BADGE

    }
}
