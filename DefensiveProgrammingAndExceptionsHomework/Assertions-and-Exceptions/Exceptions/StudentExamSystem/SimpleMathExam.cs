namespace Exceptions_Homework.StudentExamSystem
{
    using System;

    public class SimpleMathExam : IExam
    {
        private readonly int minGrade = 2;
        private readonly int maxGrade = 6;
        private readonly int minimumProblemsSolved = 0;
        private readonly int maximumProblemsSolved = 10;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
           this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < this.minimumProblemsSolved || this.maximumProblemsSolved < value)
                {
                    var message = string.Format(
                        "The number of problems solved must be in the range [{0} ... {1}].",
                        this.minimumProblemsSolved,
                        this.maximumProblemsSolved);

                    throw new ArgumentOutOfRangeException("problemsSolved", message);
                }

                this.problemsSolved = value;
            } 
        }

        public ExamResult Check()
        {
            switch (this.ProblemsSolved)
            {
                case 1:
                case 2:
                    return new ExamResult(2, this.minGrade, this.maxGrade, "Bad result: nothing done.");
                case 3:
                case 4:
                    return new ExamResult(3, this.minGrade, this.maxGrade, "Poor result: few problems solved.");
                case 5: 
                case 6: 
                    return new ExamResult(4, this.minGrade, this.maxGrade, "Average result: some problems solved.");
                case 7: 
                case 8: 
                    return new ExamResult(5, this.minGrade, this.maxGrade, "Good result: most problems solved.");
                case 9: 
                case 10:
                    return new ExamResult(6, this.minGrade, this.maxGrade, "Excellent result: most or all problems solved.");
                default:
                    throw new ArgumentOutOfRangeException("problemsSolved", "The number of problems solved is invalid.");
            }
        }
    }
}

