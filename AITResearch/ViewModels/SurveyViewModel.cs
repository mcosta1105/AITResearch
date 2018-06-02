using AITResearch.Models;
using System.Collections.Generic;

namespace AITResearch.ViewModels
{
    public class SurveyViewModel
    {
        public Question Question { get; set; }

        public Answer Answer { get; set; }

        public List<CheckBoxViewModel> CheckBoxAnswers { get; set; }

    }
}