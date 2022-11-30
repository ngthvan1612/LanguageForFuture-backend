using System;
using System.Collections.Generic;
using System.Text;

namespace LFF.Core.Entities.Supports
{
    public class StudentTestHistoryItem
    {
        public DateTime StartDate { get; set; }
        public int Score { get; set; } = -1;
        public Guid StudentTestId { get; set; }
    }

    public class StudentTestHistory
    {
        public Test? TestInfo { get; set; }
        public int TotalScore { get; set; } = -1;
        public ICollection<StudentTestHistoryItem>? Histories { get; set; }
    }
}
