using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class Survey
    {
        public long ContentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? EndCount { get; set; }
        public string MainQuestion { get; set; }
        public string CreatorName { get; set; }
        public long CreatorId { get; set; }
        public List<QuestionAnswer> QuestionAnswers { get; set; }
        public long ParticipantCount { get; set; }
        public string Conclusion { get; set; }
    }

    public class SurveyAnswer
    {
        public string ChoiceText { get; set; }
        public long VoteForChoiceCount { get; set; }
    }

    public class QuestionAnswer
    {
        public string Question { get; set; }
        public List<SurveyAnswer> Answers { get; set; }
    }
}
