using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgeItems
    {
        public int BadgeId { get; set; }
        public string DoorName { get; set; }

        public BadgeItems() { }
        public BadgeItems(int badgeId, string doorName)
        {
            BadgeId = badgeId;
            DoorName = doorName;
        }
    }
}
