namespace Exceptions_Homework.StudentExamSystem
{
    using System;

    public class CSharpExam : IExam
    {
        private readonly int minScore = 0;
        private readonly int maxScore = 100;

        private int score;
       
        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < this.minScore || this.maxScore < value)
                {
                    var message = string.Format("The score should be in the range [{0} ... {1}].", this.minScore, this.maxScore);

                    throw new ArgumentOutOfRangeException("score", message);
                }

                this.score = value;

                this.score = value;
            }
        }

       public ExamResult Check()
        {
            return new ExamResult(this.Score, this.minScore, this.maxScore, "Exam results calculated by score.");
        }
    }
}
