using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgeItemsRepository
    {
        //DICTIONARY
        Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();

        //CRUD

        //CREATE NEW BADGE
        public bool AddNewBadge(BadgeItems newContent)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(newContent.BadgeId, newContent.DoorName);
            bool wasAdded = (_badgeDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ ALL BADGES
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDirectory;
        }

        //READ ONE
        public BadgeItems GetBadgeById(int badgeId)
        {
            var singleContent = new BadgeItems(badgeId, _badgeDirectory[badgeId]);
            if (singleContent.BadgeId == badgeId)
            {
                return singleContent;
            }
            else
            {
                return null;
            }
        }

    }
}
