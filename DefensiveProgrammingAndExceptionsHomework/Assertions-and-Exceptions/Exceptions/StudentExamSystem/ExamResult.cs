namespace Exceptions_Homework.StudentExamSystem
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minimumGrade;
        private int maximumGrade;
        private string comment;

        public ExamResult(int grade, int minimumGrade, int maximumGrade, string comment)
        {
            this.CheckGradesRange(minimumGrade, maximumGrade);

            this.Grade = grade;
            this.MinimumGrade = minimumGrade;
            this.MaximumGrade = maximumGrade;
            this.Comment = comment;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("grade", "the grade can not be negative number");
                }

                this.grade = value;
            }
        }

        public int MinimumGrade
        {
            get
            {
                return this.minimumGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("minimum grade", "the grade can not be negative number");
                }

                this.minimumGrade = value;
            }
        }

        public int MaximumGrade
        {
            get
            {
                return this.maximumGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("maximum grade", "the grade can not be negative number");
                }

                this.maximumGrade = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Comment", "Can not be empty comments");
                }

                this.comment = value;
            }
        }

        private void CheckGradesRange(int minGrade, int maxGrade)
        {
            if (maxGrade <= minGrade)
            {
                throw new ArgumentOutOfRangeException("Minimum and maximum grades", "The Minimum Grade have to be smaller then maximum grade");
            }
        }
    }
}
