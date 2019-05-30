﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuizQuestionType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TypeDescription { get; set; }

        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
